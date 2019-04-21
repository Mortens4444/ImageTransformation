using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseTransformator : Transformator
    {
        public InverseTransformator(Image img)
            : base(img)
        { }

        public InverseTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = (byte)(Byte.MaxValue - this[i]);
                this[i + GreenIndex] = (byte)(Byte.MaxValue - this[i + GreenIndex]);
                this[i + RedIndex] = (byte)(Byte.MaxValue - this[i + RedIndex]);
            }
        }
    }
}
