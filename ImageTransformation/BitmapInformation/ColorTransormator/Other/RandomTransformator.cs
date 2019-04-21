using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class RandomTransformator : Transformator
    {
        readonly Random random = new Random((int)(DateTime.UtcNow.Ticks % Int32.MaxValue));

        public RandomTransformator(Image img)
            : base(img)
        { }

        public RandomTransformator(Bitmap bmp)
            : base(bmp)
        { }


        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                this[i] = GetRandomByte();
                this[i + GreenIndex] = GetRandomByte();
                this[i + RedIndex] = GetRandomByte();
            }
        }

        private byte GetRandomByte()
        {
            return (byte)random.Next(Byte.MinValue, Byte.MaxValue);
        }
    }
}
