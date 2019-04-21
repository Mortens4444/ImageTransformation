using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class HarrisCornerDetectionTransformator : CornerDetectionTransformator
    {
        private const double AlphaHarris = 0.1;

        public HarrisCornerDetectionTransformator(Image img)
            : base(img)
        { }

        public HarrisCornerDetectionTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var trAndDet = GetTrAndDet(index);
			var tr = trAndDet.Tr;
			var det = trAndDet.Det;
            return (Math.Abs((int)Math.Min(det - AlphaHarris * tr * tr, Int32.MaxValue)) / 1000 > 0) ? Byte.MaxValue : Byte.MinValue;
        }
    }
}
