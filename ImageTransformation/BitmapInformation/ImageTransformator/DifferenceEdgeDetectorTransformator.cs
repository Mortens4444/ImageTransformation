using System;
using System.Drawing;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class DifferenceEdgeDetectorTransformator : RgbChangerTransformator
    {
        public DifferenceEdgeDetectorTransformator(Image img)
            : base(img)
        { }

        public DifferenceEdgeDetectorTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Max(this[index, Direction.NorthWest] - this[index, Direction.SouthEast], 0);
        }
    }
}
