using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class GreenscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public GreenscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public GreenscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public GreenscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public GreenscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = componentValue;
                this[i + RedIndex] = componentValue;
            }
        }
    }
}
