using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class ModifiedHarrisCornerDetectionTransformator : CornerDetectionTransformator
    {
        private const double AlphaHarris = 0.1;

        public ModifiedHarrisCornerDetectionTransformator(Image img)
            : base(img)
        { }

        public ModifiedHarrisCornerDetectionTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var trAndDet = GetTrAndDet(index);
            var tr = trAndDet.Tr;
			var det = trAndDet.Det;
            var result = (byte)(Math.Abs((int)Math.Min(det - AlphaHarris * tr * tr, Int32.MaxValue)) / 1000);
            return ((this[index] * result) / 15000 > 0) ? Byte.MaxValue : Byte.MinValue;
        }
    }
}