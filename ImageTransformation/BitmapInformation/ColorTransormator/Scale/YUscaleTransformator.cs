using System;
using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class YUscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public YUscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public YUscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public YUscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public YUscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var yuvColor = new YuvColor(this[i + RedIndex], this[i + GreenIndex], this[i], ColorSpaceType.RGB);
                this[i] = componentValue;
                this[i + GreenIndex] = yuvColor.U;
                this[i + RedIndex] = yuvColor.Y;
            }
        }
    }
}