using System;
using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class BlackAndWhiteTransformator : RgbChangerTransformator
    {
        public BlackAndWhiteTransformator(Image img)
            : base(img)
        { }

        public BlackAndWhiteTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            //return (Math.Round((double)(this[index + RedIndex] + this[index + GreenIndex] + this[index]) / 3) < 128)
            return (ColorExtensions.GetBt601Value(this[index + RedIndex], this[index + GreenIndex], this[index]) < 128)
                ? Byte.MinValue : Byte.MaxValue;
        }
    }
}