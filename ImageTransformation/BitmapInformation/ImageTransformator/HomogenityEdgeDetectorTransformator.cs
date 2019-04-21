using System;
using System.Drawing;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class HomogenityEdgeDetectorTransformator : RgbChangerTransformator
    {
        public HomogenityEdgeDetectorTransformator(Image img)
            : base(img)
        { }

        public HomogenityEdgeDetectorTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Max(this[index] - this[index, Direction.NorthWest], 0);
        }
    }
}
