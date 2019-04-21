using System.Drawing;
using ImageTransformation.Enums;
using ImageTransformation.Other;

namespace ImageTransformation.BitmapInformation
{
    public abstract class CornerDetectionTransformator : RgbChangerTransformator
    {
        protected CornerDetectionTransformator(Image img)
            : base(img)
        { }

        protected CornerDetectionTransformator(Bitmap bmp)
            : base(bmp)
        { }

		protected TrAndDet GetTrAndDet(int index)
        {
            int pgx = this[index, Direction.West];
            int pgy = this[index, Direction.North];
            var fx = this[index] - pgx;
            var fy = this[index] - pgy;
            var fxy = fx * fy;
            fx *= fx;
            fy *= fy;
            var tr = fy + fx;
            var det = fx * fy - fxy * fxy;
			return new TrAndDet(tr, det);
        }
    }
}

