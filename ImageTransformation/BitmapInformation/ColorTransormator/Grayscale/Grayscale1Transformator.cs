using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class Grayscale1Transformator : RgbChangerTransformator
    {
        public Grayscale1Transformator(Image img)
            : base(img)
        { }

        public Grayscale1Transformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round((double)(77 * this[index + RedIndex] + 150 * this[index + GreenIndex] + 28 * this[index]) / Byte.MaxValue);
        }
    }
}