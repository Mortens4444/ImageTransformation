using System;
using System.Drawing;
using ImageTransformation.Enums;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class RobertsEdgeDetectorTransformator : RgbChangerTransformator
    {
        public RobertsEdgeDetectorTransformator(Image img)
            : base(img)
        { }

        public RobertsEdgeDetectorTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var d = Math.Sqrt(this[index, Direction.NorthWest] - this[index] * this[index, Direction.NorthWest] - this[index]
                + this[index, Direction.North] + this[index, Direction.West] * this[index, Direction.North] + this[index, Direction.West]);
            return (byte)d.LimitMeWithRound(Byte.MinValue, Byte.MaxValue);
        }
    }
}
