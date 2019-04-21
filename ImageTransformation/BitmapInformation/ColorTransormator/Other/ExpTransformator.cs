using System;
using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class ExpTransformator : Transformator
    {
        public ExpTransformator(Image img)
            : base(img)
        { }

        public ExpTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = GetValue(i);
                this[i + GreenIndex] = GetValue(i + GreenIndex);
                this[i + RedIndex] = GetValue(i + RedIndex);
            }
        }

        byte GetValue(int index)
        {
            return ((byte)(Math.Round(Math.Exp(this[index]) % Byte.MaxValue))).LimitMe();
        }
    }
}
