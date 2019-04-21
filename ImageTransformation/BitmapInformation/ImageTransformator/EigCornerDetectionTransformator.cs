using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class EigCornerDetectionTransformator : CornerDetectionTransformator
    {
        public EigCornerDetectionTransformator(Image img)
            : base(img)
        { }

        public EigCornerDetectionTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var trAndDet = GetTrAndDet(index);
            var tr = trAndDet.Tr;
            var det = trAndDet.Det;
            var lambda1 = 0.5 * (tr + Math.Sqrt(tr * tr - 4 * det));
            var lambda2 = 0.5 * (tr - Math.Sqrt(tr * tr - 4 * det));
            var x = (int)Math.Min(lambda1 < lambda2 ? lambda1 : lambda2, Int32.MaxValue);
            return (x > 0) ? Byte.MaxValue : Byte.MinValue;
        }
    }
}
