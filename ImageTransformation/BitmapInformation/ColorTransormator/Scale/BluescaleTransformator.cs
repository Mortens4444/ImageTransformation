using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class BluescaleTransformator: Transformator
    {
        private readonly byte componentValue;

        public BluescaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public BluescaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }
		
		public BluescaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public BluescaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i + GreenIndex] = componentValue;
                this[i + RedIndex] = componentValue;
            }
        }
    }
}