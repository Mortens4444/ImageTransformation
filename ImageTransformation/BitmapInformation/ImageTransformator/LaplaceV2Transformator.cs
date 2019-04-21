using System;
using System.Drawing;
using ImageTransformation.Extensions;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class LaplaceV2Transformator : RgbChangerTransformator
    {
        public LaplaceV2Transformator(Image img)
            : base(img)
        { }

        public LaplaceV2Transformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var x = Math.Abs(this[index, Direction.North] + this[index, Direction.South] + this[index, Direction.West]
                + this[index, Direction.East] + this[index, Direction.NorthWest] + this[index, Direction.NorthEast]
                + this[index, Direction.SouthWest] + this[index, Direction.SouthEast] - 8 * this[index]);
            return (byte)x.LimitMe(Byte.MinValue, Byte.MaxValue);
        }
    }
}
