using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public abstract class RgbChangerTransformator : Transformator
    {
        protected RgbChangerTransformator(Image img)
            : base(img)
        { }

        protected RgbChangerTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            var result = new byte[Length];
            for (var i = 0; i < Length; i += ByteCount)
            {
                result[i] = GetValue(i);
                result[i + GreenIndex] = result[i];
                result[i + RedIndex] = result[i];
            }
            RgbBytes = result;
        }

        protected abstract byte GetValue(int index);
    }
}
