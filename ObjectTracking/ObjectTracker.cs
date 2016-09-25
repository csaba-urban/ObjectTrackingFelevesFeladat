using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectTracking
{
	enum EAlgorythmType { ESerial, EParallel, ETss }
	class ObjectTracker
	{
		//private variables
		private RawImage mReferenceImage;
		private List<RawImage> mTemplateImages;
		private List<Task> mWorkerTasks;
		private List<SimilarityDescriptor> mFoundedObjectCoordinates = new List<SimilarityDescriptor>();
		private double mStepMax;
		private double mStepSize;

		private static double mTypicalMacroBlockSize = 16;	//based on literature
		private static double mTypicalSearchParameter = 7;	//based on literature

		static private object lockObject = new object();

		static CancellationTokenSource mCancellationTokenSource = new CancellationTokenSource();
		CancellationToken mCancellationToken = mCancellationTokenSource.Token;

		/// <summary>
		/// Constuctor
		/// </summary>
		/// <param name="aMaxNumOfWorkerTasks"> The number of the maximal available threads/tasks</param>
		public ObjectTracker( int aMaxNumOfWorkerTasks = 1 )
		{
			mWorkerTasks = new List<Task>( aMaxNumOfWorkerTasks );
			mStepMax = 60;
		}

		/// <summary>
		/// Strart tracking the objects
		/// </summary>
		/// <param name="aReferenceImage">The captured image/frame</param>
		/// <param name="aTemplateImage">A list of template images which must be found on the reference image</param>
		/// <param name="aFoundedObjectCoordinates">The coordinates of the founded objects/template images</param>
		public void trackObject( ref RawImage aReferenceImage, ref List<RawImage> aTemplateImages, EAlgorythmType aType )
		{
			mReferenceImage = aReferenceImage;
			mTemplateImages = aTemplateImages;

			doTrackObject( aType );
		}

		/// <summary>
		/// Iterates over the template images and assigns every template image to a Task to
		/// run the calculation in parallel
		/// </summary>
		/// <param name="aType">The type of the selected algorythm</param>
		private void doTrackObject( EAlgorythmType aType )
		{
			foreach ( RawImage templateImage in mTemplateImages )
			{
				mWorkerTasks.Add( Task.Factory.StartNew( () => calculateObjectCoordinate( templateImage, aType ) ) );
			}

			Task.WaitAll( mWorkerTasks.ToArray() );
		}

		/// <summary>
		/// The calculation function which runs parallely by a task
		/// </summary>
		/// <param name="aTemplateImage">The image which we want to find, selected by the user on the GUI</param>
		/// <param name="aType">The type of the selected algorythm</param>
		private void calculateObjectCoordinate( object aTemplateImage, object aType )
		{
			RawImage templateImage = aTemplateImage as RawImage;
			EAlgorythmType type = ( EAlgorythmType )aType;

			if ( templateImage == null )
				return;

			SimilarityDescriptor coordinate = null;
			switch ( type )
			{
				case EAlgorythmType.ESerial:
					coordinate = findObjectWithSerialAlgorithm( ref templateImage );
					break;
				case EAlgorythmType.EParallel:
					coordinate = findObjectWithParallelAlgorithm( templateImage, 3 );
					break;
				case EAlgorythmType.ETss:
					coordinate = findObjectWithThreeStepSearch( ref templateImage );
					break;
				default:
					break;
			}
 
			if ( coordinate != null )
				appenFoundedObjectCordinate( coordinate );
		}

		/// <summary>
		/// Serial algorithm to find the aTemplateImage in the video frames represented by the mReferenceImage
		/// This is a full search algorithm.
		/// </summary>
		/// <param name="aTemplateImage">The template image selected by the user on the GUI</param>
		/// <returns>The coordinates(contains by the SimilarityDescriptor) of the sub founded object.</returns>
		private SimilarityDescriptor findObjectWithSerialAlgorithm( ref RawImage aTemplateImage )
		{
			List<SimilarityDescriptor> mCosts = new List<SimilarityDescriptor>();

			RawImage refImage = null;
			SimilarityDescriptor simDesc = null;

			int x;
			int y;

			for ( int i = 0; i < mReferenceImage.Height - aTemplateImage.Height + 1; i += aTemplateImage.Height )
			{
				for ( int j = 0; j < mReferenceImage.Width - aTemplateImage.Width + 1; j += aTemplateImage.Width )
				{
					x = j;
					y = i;

					refImage = mReferenceImage.subImage( j, j + aTemplateImage.Width, i, i + aTemplateImage.Height );

					if ( refImage == null )
						continue;

					simDesc = new SimilarityDescriptor();
					simDesc.X = x;
					simDesc.Y = y;
					simDesc.Width = aTemplateImage.Width;
					simDesc.Height = aTemplateImage.Height;

					simDesc.Cost = EvaluationMetrics.calculate( aTemplateImage, refImage );

					mCosts.Add( simDesc );
				}
			}

			SimilarityDescriptor min = mCosts.Min();
			return min;
		}

		/// <summary>
		/// Parallel algorithm to find the aTemplateImage in the current video frame represented by the mReferenceImage.
		/// It starts Tasks and assigns a worker function( dofindObjectWithParallelAlgorithm(...) ) to every Task.
		/// Every worker function process a part of the current video frame.
		/// </summary>
		/// <param name="aTemplateImage">The template image selected by the user</param>
		/// <param name="aPartCount">Defines the part count of the current video frame</param>
		/// <returns>The coordinates(contains by the SimilarityDescriptor) of the sub founded object.</returns>
		private SimilarityDescriptor findObjectWithParallelAlgorithm( RawImage aTemplateImage, int aPartCount )
		{
			List<SimilarityDescriptor> costs = new List<SimilarityDescriptor>();
			Task<SimilarityDescriptor>[] tasks = new Task<SimilarityDescriptor>[ 3 ];

			//for ( int i = 0; i < aPartCount; ++i )
			//{
			//	tasks[ i ] = Task.Factory.StartNew<SimilarityDescriptor>( () => dofindObjectWithParallelAlgorithm( mReferenceImage, aTemplateImage, aPartCount, i ) );
			//}

			//for ( int i = 0; i < 2; ++i )
			//{
			//	tasks[ i ] = new Task<SimilarityDescriptor>( () => dofindObjectWithParallelAlgorithm( mReferenceImage, aTemplateImage, aPartCount, i ) );
			//}
			//
			//for ( int i = 0; i < 2; ++i )
			//{
			//	tasks[ i ].Start();
			//}

			tasks[ 0 ] = Task.Factory.StartNew<SimilarityDescriptor>( () => dofindObjectWithParallelAlgorithm( mReferenceImage, aTemplateImage, aPartCount, 0 ) );
			tasks[ 1 ] = Task.Factory.StartNew<SimilarityDescriptor>( () => dofindObjectWithParallelAlgorithm( mReferenceImage, aTemplateImage, aPartCount, 1 ) );
			tasks[ 2 ] = Task.Factory.StartNew<SimilarityDescriptor>( () => dofindObjectWithParallelAlgorithm( mReferenceImage, aTemplateImage, aPartCount, 2 ) );
			
			Task.WaitAll( tasks );

			foreach ( var task in tasks )
			{
				costs.Add( task.Result );
			}

			return costs.Min();
		}

		/// <summary>
		/// Worker function to find the aTemplateImage in the aReferenceImage. Called from the findObjectWithParallelAlgorithm(...) function in parellel
		/// </summary>
		/// <param name="aReferenceImage">The current video frame</param>
		/// <param name="aTemplateImage">The user selected image.</param>
		/// <param name="aPartCount">The number of the partition of the aReferenceImage</param>
		/// <param name="aActualPartNum">The current part of the aReferenceImage processed by the algorithm</param>
		/// <returns>The coordinates(contains by the SimilarityDescriptor) of the sub founded object.</returns>
		private SimilarityDescriptor dofindObjectWithParallelAlgorithm( RawImage aReferenceImage, RawImage aTemplateImage, int aPartCount, int aActualPartNum )
		{
			List<SimilarityDescriptor> mCosts = new List<SimilarityDescriptor>();
			SimilarityDescriptor simDesc = null;
			RawImage refImage = null;

			Console.WriteLine( "Actual Part Number: " + aActualPartNum.ToString() );

			int maxWidth = ( ( ( aActualPartNum + 1 ) * aReferenceImage.Width ) / aPartCount );// -aTemplateImage.Width + 1;
			int maxHeight = ( ( ( aActualPartNum + 1 ) * aReferenceImage.Height ) / aPartCount );// -aTemplateImage.Height + 1;

			for ( int i = aActualPartNum * ( aReferenceImage.Height / aPartCount ); i < maxHeight && ( i + aTemplateImage.Height < aReferenceImage.Height ); i += aTemplateImage.Height )
			{
				for ( int j = aActualPartNum * ( aReferenceImage.Width / aPartCount ); j < maxWidth && ( j + aTemplateImage.Width < aReferenceImage.Width ); j += aTemplateImage.Width )
				{
					int x = j;
					int y = i;

					refImage = aReferenceImage.subImage( j, j + aTemplateImage.Width, i, i + aTemplateImage.Height );

					if ( refImage == null )
						continue;

					simDesc = new SimilarityDescriptor();
					simDesc.X = x;
					simDesc.Y = y;
					simDesc.Width = aTemplateImage.Width;
					simDesc.Height = aTemplateImage.Height;

					simDesc.Cost = EvaluationMetrics.calculate( aTemplateImage, refImage );

					mCosts.Add( simDesc );
				}
			}

			return mCosts.Min();
		}

		/// <summary>
		/// A customized and simplified Three Step Search algorithm to find the aTempaleImage
		/// </summary>
		/// <param name="aTemplateImage">The user selected image</param>
		/// <returns></returns>
		private SimilarityDescriptor findObjectWithThreeStepSearch( ref RawImage aTemplateImage )
		{
			List<SimilarityDescriptor> costs = new List<SimilarityDescriptor>();
			RawImage refImage = null;
			SimilarityDescriptor simDesc = null;

			mStepSize = mStepMax;

			int x = mReferenceImage.Width / 2;
			int y = mReferenceImage.Height / 2;

			while ( mStepSize >= 20 )
			{
				costs.Clear();
				for ( int m = -( int )mStepSize; m <= mReferenceImage.Width; m += ( int )mStepSize )
				{
					int refBlockHorizontalCoordinate = x + m;
					if ( refBlockHorizontalCoordinate + aTemplateImage.Width > mReferenceImage.Width )
						continue;

					for ( int n = -( int )mStepSize; n <= mReferenceImage.Height; n += ( int )mStepSize )
					{
						int refBlockVerticalCoordinate = y + n;

						if ( refBlockVerticalCoordinate + aTemplateImage.Height > mReferenceImage.Height )
							continue;

						refImage = mReferenceImage.subImage( refBlockHorizontalCoordinate, refBlockHorizontalCoordinate + aTemplateImage.Width,
							refBlockVerticalCoordinate, refBlockVerticalCoordinate + aTemplateImage.Height );

						if ( refImage == null )
							continue;

						simDesc = new SimilarityDescriptor();
						simDesc.X = refBlockHorizontalCoordinate;
						simDesc.Y = refBlockVerticalCoordinate;
						simDesc.Width = aTemplateImage.Width;
						simDesc.Height = aTemplateImage.Height;

						simDesc.Cost = EvaluationMetrics.calculate( aTemplateImage, refImage );
						costs.Add( simDesc );
					}
				}

				mStepSize = mStepSize / 2;

				if ( costs.Count > 0 )
				{
					SimilarityDescriptor min = costs.Min();
					x = min.X + ( min.Width / 2 );
					y = min.Y + ( min.Height / 2 );
				}
			}
			return costs.Min();
		}

		/// <summary>
		/// Appends a new SimilarityDescriptor object into a list.
		/// </summary>
		/// <param name="aNewCoordinate">The descriptor of the coordinate of the founded object</param>
		private void appenFoundedObjectCordinate( SimilarityDescriptor aNewCoordinate )
		{
			lock( lockObject )
			{
				mFoundedObjectCoordinates.Add( aNewCoordinate );
			}
		}

		/// <summary>
		/// Getter function to get the coordinates of the founded object(s)
		/// </summary>
		/// <returns>List of the founded object coordinates</returns>
		public List<SimilarityDescriptor> foundedObjectCordinate()
		{
			lock ( lockObject )
			{
				List<SimilarityDescriptor> temp = new List<SimilarityDescriptor>( mFoundedObjectCoordinates );
				mFoundedObjectCoordinates.Clear();
				return temp;
			}
		}
	}
}
