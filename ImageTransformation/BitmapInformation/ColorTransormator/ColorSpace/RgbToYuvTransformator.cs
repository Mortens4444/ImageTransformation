using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Enums;

namespace ImageTransformation.BitmapInformation
{
    public class RgbToYuvTransformator : Transformator
    {
        public RgbToYuvTransformator(Image img)
            : base(img)
        { }

        public RgbToYuvTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var yuvColor = new YuvColor(this[i + RedIndex], this[i + GreenIndex], this[i], ColorSpaceType.RGB);
                this[i] = yuvColor.V;
                this[i + GreenIndex] = yuvColor.U;
                this[i + RedIndex] = yuvColor.Y;
            }
        }
    }
}
