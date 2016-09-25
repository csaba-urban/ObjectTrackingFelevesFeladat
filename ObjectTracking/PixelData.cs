namespace ObjectTracking
{
	/// <summary>
	/// This struct represent a pixel data in a raw format
	/// </summary>
	public struct PixelData
	{
		public byte Blue;
		public byte Green;
		public byte Red;
		public byte Alpha;

		public PixelData( byte aRed, byte aGreen, byte aBlue, byte aAlpha )
		{
			this.Red = aRed;
			this.Green = aGreen;
			this.Blue = aBlue;
			this.Alpha = aAlpha;
		}

		public double MeanPixelValue()
		{
			return ( Red + Green + Blue ) / 3;
		}
	}

}