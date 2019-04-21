using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseGreenTransformator : Transformator
    {
        public InverseGreenTransformator(Image img)
            : base(img)
        { }

        public InverseGreenTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i + GreenIndex] = (byte)(Byte.MaxValue - this[i + GreenIndex]);
            }
        }
    }
}
