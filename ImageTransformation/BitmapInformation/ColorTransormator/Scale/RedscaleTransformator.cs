using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class RedscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public RedscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public RedscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public RedscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public RedscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = componentValue;
                this[i + GreenIndex] = componentValue;
            }
        }
    }
}
