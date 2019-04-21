using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseGreenBlueTransformator : Transformator
    {
        public InverseGreenBlueTransformator(Image img)
            : base(img)
        { }

        public InverseGreenBlueTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = (byte)(Byte.MaxValue - this[i]);
                this[i + GreenIndex] = (byte)(Byte.MaxValue - this[i + GreenIndex]);
            }
        }
    }
}
