using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class Bt709GrayscaleTransformator : RgbChangerTransformator
    {
        public Bt709GrayscaleTransformator(Image img)
            : base(img)
        { }

        public Bt709GrayscaleTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round(((0.2125 * this[index + RedIndex]) + (0.7154 * this[index + GreenIndex])) + (0.0721 * this[index]));
        }
    }
}