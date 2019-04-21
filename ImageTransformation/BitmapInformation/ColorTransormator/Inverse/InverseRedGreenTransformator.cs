using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseRedGreenTransformator : Transformator
    {
        public InverseRedGreenTransformator(Image img)
            : base(img)
        { }

        public InverseRedGreenTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i + GreenIndex] = (byte)(Byte.MaxValue - this[i + GreenIndex]);
                this[i + RedIndex] = (byte)(Byte.MaxValue - this[i + RedIndex]);
            }
        }
    }
}
