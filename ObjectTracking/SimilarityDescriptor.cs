using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTracking
{
	class SimilarityDescriptor : IComparable<SimilarityDescriptor>
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public double Cost { get; set; }

		public System.Drawing.Rectangle Rectangle()
		{
			return new System.Drawing.Rectangle( X, Y, Width, Height );
		}

		int IComparable<SimilarityDescriptor>.CompareTo( SimilarityDescriptor other )
		{
			if ( other.Cost > this.Cost )
				return -1;
			else if ( other.Cost == this.Cost )
				return 0;
			else
				return 1;
		}
	}
}
