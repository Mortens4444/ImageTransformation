using System;
using System.Drawing;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class MagentaYellowscaleTransformator: Transformator
    {
        private readonly byte componentValue;
		
		public MagentaYellowscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public MagentaYellowscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public MagentaYellowscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public MagentaYellowscaleTransformator(Bitmap bmp, byte componentValue)
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
                this[i + GreenIndex] = (byte)cmyColor.Magenta;
                this[i + RedIndex] = componentValue;
            }
        }
    }
}