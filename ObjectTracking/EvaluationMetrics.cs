using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTracking
{
	class EvaluationMetrics
	{
		public enum EEvaluationType { EMSE, EMAD }
		public enum EExecutionType { ESerial, EParallel }

		static EEvaluationType mEvaluationType = 0;
		static EExecutionType mExecutionType = 0;

		static public void setEvaluationType( EEvaluationType aEvaluationType )
		{
			mEvaluationType = aEvaluationType;
		}

		static public void setExecutionType( EExecutionType aExecutionType )
		{
			mExecutionType = aExecutionType;
		}

		static public double calculate( RawImage aCurrentMacroBlock, RawImage aReferenceMacroBlock )
		{
			if ( mEvaluationType == EEvaluationType.EMAD )
				return calculateMeanAbsoluteDifference( aCurrentMacroBlock, aReferenceMacroBlock );
			else
				return calculateMeanSquaredError( aCurrentMacroBlock, aReferenceMacroBlock );
		}

		static public double calculateMeanAbsoluteDifference( RawImage aCurrentMacroBlock, RawImage aReferenceMacroBlock )
		{
			if ( aReferenceMacroBlock == null )
				return double.MaxValue; // means error

			double MAD = 0;

			if ( aCurrentMacroBlock.Height != aReferenceMacroBlock.Height || aCurrentMacroBlock.Width != aReferenceMacroBlock.Width )
			{
				throw new Exception( "Image dimension mismatch. Mean Absolute Difference calculation failed." );
			}

			int width = aCurrentMacroBlock.Width;
			int height = aCurrentMacroBlock.Height;

			if ( mExecutionType == EExecutionType.ESerial )
			{
				for ( int x = 0; x < width; ++x )
				{
					for ( int y = 0; y < height; ++y )
					{
						MAD += Math.Abs( aCurrentMacroBlock.getPixel( x, y ).MeanPixelValue() - aReferenceMacroBlock.getPixel( x, y ).MeanPixelValue() );

					}
				};
			}
			else
			{
				//Parallel.For( 0, width, x =>
				for ( int x = 0; x < width; ++x )
				{
					//for ( int y = 0; y < height; ++y )
					Parallel.For( 0, height, y =>
					{
						MAD += Math.Abs( aCurrentMacroBlock.getPixel( x, y ).MeanPixelValue() - aReferenceMacroBlock.getPixel( x, y ).MeanPixelValue() );

					} );
				};
			}
			

			MAD = MAD / ( width * height );
#if DEBUG
			Console.WriteLine( "MAD: " + MAD.ToString() );
#endif
			return MAD;
		}

		static public double calculateMeanSquaredError( RawImage aCurrentMacroBlock, RawImage aReferenceMacroBlock )
		{
			if ( aReferenceMacroBlock == null )
				return double.MaxValue; // means error
			
			double MSE = 0;

			if ( aCurrentMacroBlock.Height != aReferenceMacroBlock.Height || aCurrentMacroBlock.Width != aReferenceMacroBlock.Width )
			{
				throw new Exception( "Image dimension mismatch. Mean Absolute Difference calculation failed." );
			}

			int width = aCurrentMacroBlock.Width;
			int height = aCurrentMacroBlock.Height;

			if ( mExecutionType == EExecutionType.ESerial )
			{
				for ( int x = 0; x < width; ++x )
				{
					for ( int y = 0; y < height; ++y )
					{
						MSE += Math.Pow( aCurrentMacroBlock.getPixel( x, y ).MeanPixelValue() - aReferenceMacroBlock.getPixel( x, y ).MeanPixelValue(), 2 );
					}
				}
			}
			else
			{
				for ( int x = 0; x < width; ++x )
				//Parallel.For( 0, width, x =>
				{
					Parallel.For( 0, height, y =>
					//for ( int y = 0; y < height; ++y )
					{
						MSE += Math.Pow( aCurrentMacroBlock.getPixel( x, y ).MeanPixelValue() - aReferenceMacroBlock.getPixel( x, y ).MeanPixelValue(), 2 );
					} );
				};
			}

			MSE = MSE / ( width * height );
#if DEBUG
			Console.WriteLine( "MSE: " + MSE.ToString() );
#endif
			return MSE;
		}
	}
}
