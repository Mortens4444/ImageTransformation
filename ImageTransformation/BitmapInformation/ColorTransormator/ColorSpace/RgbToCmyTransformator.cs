using System.Drawing;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class RgbToCmyTransformator : Transformator
    {
        public RgbToCmyTransformator(Image img)
            : base(img)
        { }

        public RgbToCmyTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var cmyColor = new CmyColor(Color.FromArgb(this[i + RedIndex], this[i + GreenIndex], this[i]));
                this[i] = (byte)cmyColor.Magenta;
                this[i + GreenIndex] = (byte)cmyColor.Yellow;
                this[i + RedIndex] = (byte)cmyColor.Cyan;
            }
        }
    }
}

