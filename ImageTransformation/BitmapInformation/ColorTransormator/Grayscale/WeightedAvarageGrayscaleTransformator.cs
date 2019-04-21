using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class WeightedAvarageGrayscaleTransformator : RgbChangerTransformator
    {
        public WeightedAvarageGrayscaleTransformator(Image img)
            : base(img)
        { }

        public WeightedAvarageGrayscaleTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round((double)(3 * this[index + RedIndex] + 2 * this[index + GreenIndex] + 4 * this[index]) / 9);
        }
    }
}