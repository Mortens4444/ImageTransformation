using System;
using System.Drawing;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class CyanMagentascaleTransformator: Transformator
    {
        private readonly byte componentValue;

        public CyanMagentascaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public CyanMagentascaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }
		
		public CyanMagentascaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public CyanMagentascaleTransformator(Bitmap bmp, byte componentValue)
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
                this[i + GreenIndex] = (byte)cmyColor.Magenta;
                this[i + RedIndex] = (byte)cmyColor.Cyan;
            }
        }
    }
}