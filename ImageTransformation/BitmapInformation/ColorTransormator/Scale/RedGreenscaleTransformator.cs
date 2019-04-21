using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class RedGreenscaleTransformator : Transformator
    {
        private readonly byte componentValue;

		public RedGreenscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public RedGreenscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public RedGreenscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public RedGreenscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = componentValue;
            }
        }
    }
}