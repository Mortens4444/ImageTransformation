using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class Grayscale2Transformator : RgbChangerTransformator
    {
        public Grayscale2Transformator(Image img)
            : base(img)
        { }

        public Grayscale2Transformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round((double)(222 * this[index + RedIndex] + 707 * this[index + GreenIndex] + 71 * this[index]) / 1000);
        }
    }
}