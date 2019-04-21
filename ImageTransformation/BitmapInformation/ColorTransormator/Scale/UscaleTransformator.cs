using System;
using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class UscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public UscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public UscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public UscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public UscaleTransformator(Bitmap bmp, byte componentValue)
            : base(bmp)
        {
            this.componentValue = componentValue;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var yuvColor = new YuvColor(this[i + RedIndex], this[i + GreenIndex], this[i], ColorSpaceType.RGB);
                var x = this[i] - yuvColor.Y;
                var value = (x < 0) ? (byte)(Byte.MaxValue + x) : (byte)x;
                this[i] = value;
                this[i + GreenIndex] = componentValue;
                this[i + RedIndex] = componentValue;
            }
        }
    }
}