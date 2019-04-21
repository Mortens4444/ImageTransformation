using System;
using System.Drawing;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class SobelEdgeDetectorTransformator : RgbChangerTransformator
    {
		public SobelEdgeDetectorTransformator(Image img)
            : base(img)
        { }

		public SobelEdgeDetectorTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var p1 = this[index, Direction.NorthWest];
            var p2 = this[index, Direction.North];
            var p3 = this[index, Direction.NorthEast];
            var p4 = this[index, Direction.East];
            var p6 = this[index, Direction.West];
            var p7 = this[index, Direction.SouthWest];
            var p8 = this[index, Direction.South];
            var p9 = this[index, Direction.SouthEast];

            return (byte)(Math.Abs(p1 + 2 * p2 + p3 - p7 - 2 * p8 - p9) + Math.Abs(p3 + 2 * p6 + p9 - p1 - 2 * p4 - p7));
        }
    }
}
