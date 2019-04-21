using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class GreenBluescaleTransformator: Transformator
    {
        private readonly byte componentValue;
		
		public GreenBluescaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public GreenBluescaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public GreenBluescaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public GreenBluescaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i + RedIndex] = componentValue;
            }
        }
    }
}