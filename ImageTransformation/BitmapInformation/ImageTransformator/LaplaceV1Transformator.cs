using System;
using System.Drawing;
using ImageTransformation.Enums;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class LaplaceV1Transformator : RgbChangerTransformator
    {
        public LaplaceV1Transformator(Image img)
            : base(img)
        { }

        public LaplaceV1Transformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var x = Math.Abs(this[index, Direction.North] + this[index, Direction.South] + this[index, Direction.West]
                + this[index, Direction.East] - 4 * this[index]);
            return (byte)x.LimitMe(Byte.MinValue, Byte.MaxValue);
        }
    }
}
