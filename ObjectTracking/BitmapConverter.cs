using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using System.Windows.Forms;

namespace ObjectTracking
{
	class BitmapConverter
	{
		/// <summary>
		/// This class provide a converter between the .NET's Bitmap type and the RawImage type.
		/// </summary>
		
		private IntPtr mIptr = IntPtr.Zero;
		private BitmapData mBitmapData;

		private static readonly object mLockObject = new object();
		private static readonly object mUnlockObject = new object();

		public byte[] Pixels { get; set; }
		public int Depth { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		public BitmapConverter()
		{
		}

		/// <summary>
		/// Copies the content, data of the aSource to the Pixels byte array
		/// </summary>
		/// <param name="aSource">The source bitmap</param>
		private void LockBits( ref Bitmap aSource )
		{
			try
			{
				lock ( mLockObject )
				{
					// Get width and height of bitmap
					Width = aSource.Width;
					Height = aSource.Height;

					// get total locked pixels count
					var pixelCount = Width * Height;

					// Create rectangle to lock
					var rect = new Rectangle( 0, 0, Width, Height );

					// get source bitmap pixel format size
					Depth = Image.GetPixelFormatSize( aSource.PixelFormat );

					// Check if bpp (Bits Per Pixel) is 8, 24, or 32
					if ( Depth != 8 && Depth != 24 && Depth != 32 )
					{
						throw new ArgumentException( "Only 8, 24 and 32 bpp images are supported." );
					}

					// Lock bitmap and return bitmap data
					mBitmapData = aSource.LockBits( rect, ImageLockMode.ReadWrite, aSource.PixelFormat );

					// create byte array to copy pixel values
					var step = Depth / 8;
					Pixels = new byte[ pixelCount * step ];
					mIptr = mBitmapData.Scan0;

					// Copy data from pointer to array
					Marshal.Copy( mIptr, Pixels, 0, Pixels.Length );
				}
			}
			catch( Exception e )
			{
				MessageBox.Show( e.Message );
			}

		}//LockBits

		/// <summary>
		/// Unlocks the aSource's Bitmapdata
		/// </summary>
		/// <param name="aSource"></param>
		private void UnlockBits( ref Bitmap aSource )
		{
			try
			{
				lock ( mUnlockObject )
				{
					// Copy data from byte array to pointer
					Marshal.Copy( Pixels, 0, mIptr, Pixels.Length );

					// Unlock bitmap data
					aSource.UnlockBits( mBitmapData );
				}
			}
			catch ( Exception e )
			{
				MessageBox.Show( e.Message );
			}
		}//UnlockBits

		/// <summary>
		/// Copies the content of the aSource Bitmap into the aPixeData 2D array.
		/// </summary>
		/// <param name="aPixelData">The destination data structure to store the aSource content</param>
		/// <param name="aSource">The source Bitmap</param>
		/// <returns></returns>
		public bool toPixelData( PixelData[ , ] aPixelData, ref Bitmap aSource )
		{
			LockBits( ref aSource );

			try
			{
				// Get color components count
				var cCount = Depth / 8;

				Parallel.For( 0, Width, x =>
				//for ( int x = 0; x < Width; ++x )
				{
					for ( int y = 0; y < Height; ++y )
					{
						// Get start index of the specified pixel
						var i = ( ( y * Width ) + x ) * cCount;

						if ( i > Pixels.Length - cCount )
						{
							throw new Exception();
						}

						if ( Depth == 32 ) // For 32 BPP get Red, Green, Blue and Alpha
						{
							aPixelData[ x, y ].Blue = Pixels[ i ];
							aPixelData[ x, y ].Green = Pixels[ i + 1 ];
							aPixelData[ x, y ].Red = Pixels[ i + 2 ];
							aPixelData[ x, y ].Alpha = Pixels[ i + 3 ];
						}
						else if ( Depth == 24 ) // For 24 BPP get Red, Green and Blue
						{
							aPixelData[ x, y ].Blue = Pixels[ i ];
							aPixelData[ x, y ].Green = Pixels[ i + 1 ];
							aPixelData[ x, y ].Red = Pixels[ i + 2 ];
						}
						else if ( Depth == 8 ) // For 8 BPP get color value (Red, Green and Blue values are the same)
						{
							aPixelData[ x, y ].Blue = Pixels[ i ];
							aPixelData[ x, y ].Green = Pixels[ i ];
							aPixelData[ x, y ].Red = Pixels[ i ];
						}
					}
				} );
			}
			catch ( Exception exception )
			{
				return false;
			}
			finally
			{
				UnlockBits( ref aSource );
			}

			return true;
		}//toPixelData

		/// <summary>
		/// Converts the raw aPixeldata array into a Bitmap
		/// </summary>
		/// <param name="aPixelData">The raw pixeldata</param>
		/// <param name="aPixelFormat">The format of the raw pixeldata</param>
		/// <returns>Bitmap constructed from the aPixelData</returns>
		public Bitmap toBitmap( PixelData[ , ] aPixelData, PixelFormat aPixelFormat )
		{
			int depth = Image.GetPixelFormatSize( aPixelFormat );
			var cCount = depth / 8;

			Width = aPixelData.GetLength( 0 );
			Height = aPixelData.GetLength( 1 );

			Bitmap image = new Bitmap( Width, Height, aPixelFormat );

			var pixelCount = Width * Height;
			Pixels = new byte[ pixelCount * cCount ];

			try
			{
				//Parallel.For( 0, Width, x =>
				for ( int x = 0; x < Width; ++x )
				{
					for ( int y = 0; y < Height; ++y )
					{
						var i = ( ( y * Width ) + x ) * cCount;

						if ( i > Pixels.Length - cCount )
						{
							throw new Exception();
						}

						if ( depth == 32 ) // For 32 BPP get Red, Green, Blue and Alpha
						{
							Pixels[ i ] = aPixelData[ x, y ].Blue;
							Pixels[ i + 1 ] = aPixelData[ x, y ].Green;
							Pixels[ i + 2 ] = aPixelData[ x, y ].Red;
							Pixels[ i + 3 ] = aPixelData[ x, y ].Alpha;
						}
						else if ( depth == 24 ) // For 24 BPP get Red, Green and Blue
						{
							Pixels[ i ] = aPixelData[ x, y ].Blue;
							Pixels[ i + 1 ] = aPixelData[ x, y ].Green;
							Pixels[ i + 2 ] = aPixelData[ x, y ].Red;
						}
						else if ( depth == 8 ) // For 8 BPP get color value (Red, Green and Blue values are the same)
						{
							Pixels[ i ] = aPixelData[ x, y ].Blue;
							Pixels[ i ] = aPixelData[ x, y ].Green;
							Pixels[ i ] = aPixelData[ x, y ].Red;
						}

					}//y
				};//x

				var boundsRect = new Rectangle( 0, 0, Width, Height );
				BitmapData bmpData = image.LockBits( boundsRect, ImageLockMode.WriteOnly, image.PixelFormat );
				IntPtr ptr = bmpData.Scan0;

				Marshal.Copy( Pixels, 0, ptr, Pixels.Length );
				image.UnlockBits( bmpData );
			}
			catch ( Exception exception )
			{
				return null;
			}
		
			return image;
		}
	}

}
