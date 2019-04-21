using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class RmyGrayscaleTransformator : RgbChangerTransformator
    {
        public RmyGrayscaleTransformator(Image img)
            : base(img)
        { }

        public RmyGrayscaleTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round(((0.5 * this[index + RedIndex]) + (0.419 * this[index + GreenIndex])) + (0.081 * this[index]));
        }
    }
}