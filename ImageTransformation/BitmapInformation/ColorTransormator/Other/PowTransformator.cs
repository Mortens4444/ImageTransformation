using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class PowTransformator : Transformator
    {
        public PowTransformator(Image img)
            : base(img)
        { }

        public PowTransformator(Bitmap bmp)
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
            return (byte)Math.Max(Math.Min(Math.Round(Math.Pow(this[index], Math.PI * Math.E) * Math.Sin(45)), Byte.MaxValue), 0);
        }
    }
}
