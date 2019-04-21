using System;
using System.Drawing;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class CyanscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public CyanscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public CyanscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public CyanscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public CyanscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var cmyColor = new CmyColor(Color.FromArgb(this[i + RedIndex], this[i + GreenIndex], this[i]));
                this[i] = componentValue;
                this[i + GreenIndex] = componentValue;
                this[i + RedIndex] = (byte)(cmyColor.Cyan);
            }
        }
    }
}