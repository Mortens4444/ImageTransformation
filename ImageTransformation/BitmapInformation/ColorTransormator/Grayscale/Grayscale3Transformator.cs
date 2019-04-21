using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class Grayscale3Transformator : RgbChangerTransformator
    {
        public Grayscale3Transformator(Image img)
            : base(img)
        { }

        public Grayscale3Transformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round(((0.197 * this[index + RedIndex]) + (0.701 * this[index + GreenIndex])) + (0.07 * this[index]));
        }
    }
}