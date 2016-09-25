using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.VideoSurveillance;
using Emgu.Util;

namespace ObjectTracking
{
	public partial class MainForm : Form
	{
		//private variables
		private Capture mCapture;
		private Mat mFrame;
		private Bitmap mCapturedBitmap;
		private RawImage mCapturedRawImage = null;
		List<SimilarityDescriptor> mFoundedTemplateCoordinates = new List<SimilarityDescriptor>();

		private bool mCaptureStopped = false;
		private bool mOnTracking = false;

		//variables for selecting a template image 
		private bool mOnSelecting = false;
		private Point mTemplateImageStartPoint;
		private Rectangle mTemplateImageRectangle = new Rectangle();
		private Brush mSelectionBrush = new SolidBrush( Color.FromArgb( 128, 72, 145, 220 ) );

		//stores the templates to be tracked on the video stream 
		private List<RawImage> mTemplateRawImages;

		private ObjectTracker mObjectTracker;
		private EAlgorythmType mAlgorythmType = 0;

		private EvaluationMetrics.EEvaluationType mEvaluationType = 0;
		private EvaluationMetrics.EExecutionType mEvaluationExecutionType = 0;

		private int mCountOfSelectedTemplates = 0;

		private Stopwatch mTrackerStopwatch = new Stopwatch();

		// delegates to update the GUI controls from a thread
		public delegate void UpdateEllapsedMilisecToFindObjectLabelDelegate( long aEllapsedMiliSec );

		public MainForm()
		{
			InitializeComponent();
			initCapture();
		}

		/// <summary>
		/// Initializes the mCapture object
		/// </summary>
		public void initCapture()
		{
			if ( mCapture == null )
			{
				try
				{
					mCapture = new Capture();
					mCapturedRawImage = new RawImage( mCapture.Width, mCapture.Height );
				}
				catch ( NullReferenceException aException )
				{
					MessageBox.Show( aException.Message );
				}
			}

			if ( mCapture != null )
			{
				mCapture.ImageGrabbed += ProcessFrame;
				mCapture.Start();
			}
		}
		
		/// <summary>
		/// Process the current video frame retrieved from the mCapture object.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProcessFrame( object sender, EventArgs e )
		{ 
			try
			{
				if ( mFrame == null )
					mFrame = new Mat();

				mCapture.Retrieve( mFrame );

				// save the captured frame into a standard .NET Bitmap, then convert it to a raw image in order to be independent from the EmguCV's representation
				mCapturedBitmap = mFrame.Bitmap;

				bool retVal = mCapturedRawImage.fromBitmap( ref mCapturedBitmap );

				if ( mTemplateRawImages != null && mTemplateRawImages.Count > 0 )
				{
					// entry point of the tracking process
					trackObject( mAlgorythmType, mEvaluationType, mEvaluationExecutionType );

					if ( mFoundedTemplateCoordinates.Count > 0 )
					{
						using ( var graphics = Graphics.FromImage( mCapturedBitmap ) )
						{
							int count = 0;
							foreach ( var desc in foundedTemplateCoordinates() )
							{
								if ( desc != null )
								{
									++count;
									graphics.DrawRectangle( Pens.Yellow, desc.Rectangle() );
									graphics.DrawString( "Obj" + count.ToString(), Font, Brushes.White, ( float )desc.X, ( float )desc.Y );
									
									if ( count == 1 )
										uiFoundedTemplatePictureBox1.Image = mCapturedBitmap.Clone( desc.Rectangle(), PixelFormat.Format24bppRgb );
									if ( count == 2 )
										uiFoundedTemplatePictureBox2.Image = mCapturedBitmap.Clone( desc.Rectangle(), PixelFormat.Format24bppRgb );
								}
							}
						}
					}
					else
					{
						uiFoundedTemplatePictureBox1.Image = null;
						uiFoundedTemplatePictureBox2.Image = null;
					}
				}
			}
			catch ( Exception exception )
			{
				MessageBox.Show( exception.Message );
			}

			uiCameraPictureBox.Image = new Bitmap( mCapturedBitmap );
		}

		private void uiCameraPictureBox_MouseDown( object sender, MouseEventArgs e )
		{
			if ( mCountOfSelectedTemplates == 2 )
				return;

			mOnSelecting = true;
			mTemplateImageStartPoint = e.Location;

			// to "freeze" the picturebox during the selection
			stopCapture();
			//mCapture.Stop();

			Invalidate();
		}

		private void uiCameraPictureBox_MouseMove( object sender, MouseEventArgs e )
		{
			if ( e.Button != MouseButtons.Left )
				return;

			if ( mCountOfSelectedTemplates == 2 )
				return;

			Point templateImageEndPoint = e.Location;

			mTemplateImageRectangle.Location = new Point(
				Math.Min( mTemplateImageStartPoint.X, templateImageEndPoint.X ),
				Math.Min( mTemplateImageStartPoint.Y, templateImageEndPoint.Y ) );

			mTemplateImageRectangle.Size = new Size(
				Math.Abs( mTemplateImageStartPoint.X - templateImageEndPoint.X ),
				Math.Abs( mTemplateImageStartPoint.Y - templateImageEndPoint.Y
				/*Math.Abs( mTemplateImageStartPoint.X - templateImageEndPoint.X*/ ) );

			uiCameraPictureBox.Invalidate();
		}

		private void uiCameraPictureBox_Paint( object sender, PaintEventArgs e )
		{
			if ( !mOnSelecting )
				return;

			if ( uiCameraPictureBox.Image != null )
			{
				if ( mTemplateImageRectangle != null && mTemplateImageRectangle.Width > 0 && mTemplateImageRectangle.Height > 0 )
				{
					e.Graphics.FillRectangle( mSelectionBrush, mTemplateImageRectangle );
				}
			}
		}

		private void uiCameraPictureBox_MouseUp( object sender, MouseEventArgs e )
		{
			if ( !mOnSelecting )
				return;

			mOnSelecting = false;

			if ( e.Button == MouseButtons.Left )
			{
				Point templateImageEndPoint = e.Location;

				if ( mTemplateRawImages == null )
					mTemplateRawImages = new List<RawImage>();

				// save the selected area from the current frame into a list of bitmaps
				Bitmap temp = mCapturedBitmap.Clone( mTemplateImageRectangle, mCapturedBitmap.PixelFormat );
				RawImage templateRawImage = new RawImage( temp.Width, temp.Height );
				templateRawImage.fromBitmap( ref temp );

				mTemplateRawImages.Add( templateRawImage );
				++mCountOfSelectedTemplates;

				uiClearTemplatesButton.Enabled = true;
				uiBlockMatchingAlgorithmsGroupBox.Enabled = false;
				uiEvalMetricsGroupBox.Enabled = false;

				// setup the block matching algorithm type
				if ( uiSerialBlockMatchingRadioButton.Checked )
					mAlgorythmType = EAlgorythmType.ESerial;
				else if ( uiParalellBlockMatchingRadioButton.Checked )
					mAlgorythmType = EAlgorythmType.EParallel;
				else
					mAlgorythmType = EAlgorythmType.ETss;

				// setup the evaluation metrics type
				if ( uiMeanAbbsDiffRadioButton.Checked )
					mEvaluationType = EvaluationMetrics.EEvaluationType.EMAD;
				else
					mEvaluationType = EvaluationMetrics.EEvaluationType.EMSE;

				//setup the evaluation metrics execution type
				if ( uiEvalMetricsParallelRadioButton.Checked )
					mEvaluationExecutionType = EvaluationMetrics.EExecutionType.EParallel;
				else
					mEvaluationExecutionType = EvaluationMetrics.EExecutionType.ESerial;

				if ( mCountOfSelectedTemplates== 1 )
					uiSelectedTemplatePictureBox1.Image = new Bitmap( temp, uiSelectedTemplatePictureBox1.Width, uiSelectedTemplatePictureBox1.Height );
				if ( mCountOfSelectedTemplates == 2 )
					uiSelectedTemplatePictureBox2.Image = new Bitmap( temp, uiSelectedTemplatePictureBox2.Width, uiSelectedTemplatePictureBox2.Height );
			}

			startCapture();
			//mCapture.Start();
		}

		/// <summary>
		/// Find the template image(s) in the mCapturedRawImage and mark it
		/// </summary>
		private void trackObject( EAlgorythmType aType, EvaluationMetrics.EEvaluationType aEvaluationType, EvaluationMetrics.EExecutionType aExecutionType )
		{
			if ( mObjectTracker == null )
				mObjectTracker = new ObjectTracker();

			EvaluationMetrics.setEvaluationType( aEvaluationType );
			EvaluationMetrics.setExecutionType( aExecutionType );

			mTrackerStopwatch.Start();

			mObjectTracker.trackObject( ref mCapturedRawImage, ref mTemplateRawImages, aType );
			
			mTrackerStopwatch.Stop();

			//update the labels
			uiEllapsedMilisecToFindObjectsLabel.Invoke( new UpdateEllapsedMilisecToFindObjectLabelDelegate( UpdateEllapsedMilisecToFindObjectLabel ),
				new object[] { mTrackerStopwatch.ElapsedMilliseconds } );

			mTrackerStopwatch.Reset();

			mFoundedTemplateCoordinates = mObjectTracker.foundedObjectCordinate();
		}

		private void stopCapture()
		{
			if ( ! mCaptureStopped )
			{
				mCapture.Stop();
				mCaptureStopped = true;
			}
		}

		private void startCapture()
		{
			if ( mCaptureStopped )
			{
				mCapture.Start();
				mCaptureStopped = false;
			}
		}

		private List<SimilarityDescriptor> foundedTemplateCoordinates()
		{
			return mFoundedTemplateCoordinates;
		}

		private void uiClearTemplatesButton_Click( object sender, EventArgs e )
		{
			mTemplateRawImages.Clear();

			uiClearTemplatesButton.Enabled = false;
			uiBlockMatchingAlgorithmsGroupBox.Enabled = true;
			uiEvalMetricsGroupBox.Enabled = true;

			//clear the related labels
			uiEllapsedMilisecToFindObjectsLabel.Text = "-";

			mCountOfSelectedTemplates = 0;

			uiSelectedTemplatePictureBox1.Image = null;
			uiSelectedTemplatePictureBox2.Image = null;

			uiFoundedTemplatePictureBox1.Image = null;
			uiFoundedTemplatePictureBox2.Image = null;
		}

		public void UpdateEllapsedMilisecToFindObjectLabel( long aEllapsedMiliSec )
		{
			uiEllapsedMilisecToFindObjectsLabel.Text = aEllapsedMiliSec.ToString();
		}

	}
}
