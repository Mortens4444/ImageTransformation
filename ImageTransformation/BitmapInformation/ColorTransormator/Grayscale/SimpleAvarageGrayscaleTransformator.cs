using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class SimpleAvarageGrayscaleTransformator : RgbChangerTransformator
    {
        public SimpleAvarageGrayscaleTransformator(Image img)
            : base(img)
        { }

        public SimpleAvarageGrayscaleTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round((double)(this[index + RedIndex] + this[index + GreenIndex] + this[index]) / 3);
        }
    }
}