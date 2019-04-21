using System;
using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class UVscaleTransformator: Transformator
    {
        private readonly byte componentValue;

		public UVscaleTransformator(Image img)
            : this(img, Byte.MinValue)
        { }

        public UVscaleTransformator(Bitmap bmp)
            : this(bmp, Byte.MinValue)
        { }

        public UVscaleTransformator(Image img, byte componentValue)
            : base(img)
        {
            this.componentValue = componentValue;
        }

        public UVscaleTransformator(Bitmap bmp, byte componentValue)
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
                this[i + GreenIndex] = yuvColor.U;
                this[i + RedIndex] = componentValue;
            }
        }
    }
}