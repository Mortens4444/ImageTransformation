using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseBlueTransformator : Transformator
    {
        public InverseBlueTransformator(Image img)
            : base(img)
        { }

        public InverseBlueTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = (byte)(Byte.MaxValue - this[i]);
            }
        }
    }
}
