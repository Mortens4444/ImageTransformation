using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public abstract class ArgbChangerTransformator : Transformator
    {
        protected ArgbChangerTransformator(Image img)
            : base(img)
        { }

        protected ArgbChangerTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
			var result = new byte[Length];
            for (var i = 0; i < Length; i += ByteCount)
            {
                result[i] = GetValue(i);
                result[i + GreenIndex] = this[i];
                result[i + RedIndex] = this[i];
				result[i + AlphaIndex] = Byte.MaxValue;
            }
			RgbBytes = result;
        }

        protected abstract byte GetValue(int index);
    }
}
