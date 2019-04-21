using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseRedTransformator : Transformator
    {
        public InverseRedTransformator(Image img)
            : base(img)
        { }

        public InverseRedTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i + RedIndex] = (byte)(Byte.MaxValue - this[i + RedIndex]);
            }
        }
    }
}
