using System;
using System.Drawing;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class CyanYellowscaleTransformator : Transformator
    {
        private readonly byte componentValue;

		public CyanYellowscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public CyanYellowscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public CyanYellowscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public CyanYellowscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var cmyColor = new CmyColor(Color.FromArgb(this[i + RedIndex], this[i + GreenIndex], this[i]));
                this[i] = (byte)cmyColor.Yellow;
                this[i + GreenIndex] = componentValue;
                this[i + RedIndex] = (byte)cmyColor.Cyan;
            }
        }
    }
}