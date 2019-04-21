using System;
using System.Drawing;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class YellowscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public YellowscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public YellowscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public YellowscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public YellowscaleTransformator(Bitmap bmp, byte componentValue)
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
                this[i + RedIndex] = componentValue;
            }
        }
    }
}