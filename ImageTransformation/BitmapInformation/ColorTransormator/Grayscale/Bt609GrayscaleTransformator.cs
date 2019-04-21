using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class Bt609GrayscaleTransformator : RgbChangerTransformator
    {
        public Bt609GrayscaleTransformator(Image img)
            : base(img)
        { }

        public Bt609GrayscaleTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round(((0.21 * this[index + RedIndex]) + (0.71 * this[index + GreenIndex])) + (0.08 * this[index]));
        }
    }
}