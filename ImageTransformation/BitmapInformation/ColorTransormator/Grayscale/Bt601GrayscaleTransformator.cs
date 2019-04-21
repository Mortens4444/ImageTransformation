using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    /// <summary>
    /// NTSC, PAL
    /// </summary>
    public class Bt601GrayscaleTransformator : RgbChangerTransformator
    {
        public Bt601GrayscaleTransformator(Image img)
            : base(img)
        { }

        public Bt601GrayscaleTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            return (byte)Math.Round(0.299 * this[index + RedIndex] + 0.587 * this[index + GreenIndex] + 0.114 * this[index]);
        }
    }
}