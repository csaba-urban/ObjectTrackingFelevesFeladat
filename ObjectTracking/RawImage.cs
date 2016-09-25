using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace ObjectTracking
{
	class RawImage
	{
		/// <summary>
		/// Represents an image in a raw format and provide a fast (faster then the .NET's Bitmap class) access to the pixels.
		/// </summary>
		
		private PixelData[ , ] mPixelData = null;
		private BitmapConverter mBitmapConverter = new BitmapConverter();
		private PixelFormat mPixelFormat = new PixelFormat();

		private const int mDefaultWidth = 640;
		private const int mDefaultHeight = 480;

		private int mWidth;
		private int mHeight;

		public int Width
		{
			get { return mWidth; }
			private set { mWidth = value; }
		}
		
		public int Height
		{
			get { return mHeight; }
			private set { mHeight = value; }
		}
		
		public RawImage( int aWidth, int aHeight )
		{
			mPixelData = new PixelData[ aWidth, aHeight ];
			mWidth = aWidth;
			mHeight = aHeight;
		}

		public RawImage()
		{
			mPixelData = new PixelData[ mDefaultWidth, mDefaultHeight ];
			mWidth = mDefaultWidth;
			mHeight = mDefaultHeight;
		}

		public PixelFormat PixelFormat
		{
			get;
			private set;
		}

		public bool fromBitmap( ref Bitmap aImage )
		{
			mPixelFormat = aImage.PixelFormat;
			return mBitmapConverter.toPixelData( mPixelData, ref aImage );
		}

		public Bitmap toBitmap()
		{
			return mBitmapConverter.toBitmap( mPixelData, mPixelFormat );
		}

		public PixelData getPixel( int aX, int aY )
		{
			return mPixelData[ aX, aY ];
		}

		public RawImage subImage( int aStartX, int aEndX, int aStartY, int aEndY )
		{
			if ( aStartX < 0 || aStartY < 0 || aEndX > this.Width || aEndY > this.Height )
				return null;

			RawImage subImage = new RawImage( aEndX - aStartX, aEndY - aStartY );
			subImage.mPixelFormat = this.mPixelFormat;

			for ( int x = aStartX; x < aEndX; ++x )
			{
				for ( int y = aStartY; y < aEndY; ++y )
				{
					subImage.mPixelData[ x -aStartX , y - aStartY ] = this.mPixelData[ x, y ];
				}
			}

			return subImage;
		}
	}
}
