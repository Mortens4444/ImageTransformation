using System;
using System.Drawing;
using ImageTransformation.Enums;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class MortensV1Transformator : RgbChangerTransformator
    {
        public MortensV1Transformator(Image img)
            : base(img)
        { }

        public MortensV1Transformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var x = this[index, Direction.NorthEast] + this[index, Direction.SouthEast] - this[index, Direction.NorthWest]
                - this[index, Direction.SouthWest] + 2 * (this[index, Direction.East] - this[index, Direction.West]);
            return (byte)x.LimitMe(Byte.MinValue, Byte.MaxValue);
        }
    }
}
