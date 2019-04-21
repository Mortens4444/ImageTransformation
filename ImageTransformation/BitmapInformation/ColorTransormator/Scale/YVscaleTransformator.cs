using System;
using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class YVscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public YVscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public YVscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public YVscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public YVscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var yuvColor = new YuvColor(this[i + RedIndex], this[i + GreenIndex], this[i], ColorSpaceType.RGB);
                this[i] = yuvColor.V;
                this[i + GreenIndex] = componentValue;
                this[i + RedIndex] = yuvColor.Y;
            }
        }
    }
}