using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class RedBluescaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public RedBluescaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public RedBluescaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public RedBluescaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public RedBluescaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i + GreenIndex] = componentValue;
            }
        }
    }
}