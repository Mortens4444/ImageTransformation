using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseRedBlueTransformator : Transformator
    {
        public InverseRedBlueTransformator(Image img)
            : base(img)
        { }

        public InverseRedBlueTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = (byte)(Byte.MaxValue - this[i]);
                this[i + RedIndex] = (byte)(Byte.MaxValue - this[i + RedIndex]);
            }
        }
    }
}
