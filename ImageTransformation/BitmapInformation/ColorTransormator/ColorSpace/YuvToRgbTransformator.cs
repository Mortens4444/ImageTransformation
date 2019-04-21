using System.Drawing;
using ImageTransformation.Enums;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class YuvToRgbTransformator : Transformator
    {
        private const int YIndex = RedIndex;
        private const int UIndex = GreenIndex;
        //private const int VIndex = 0;

        public YuvToRgbTransformator(Image img)
            : base(img)
        { }

        public YuvToRgbTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var yuvColor = new YuvColor(this[i + YIndex], this[i + UIndex], this[i], ColorSpaceType.YUV);
                this[i] = yuvColor.Blue;
                this[i + UIndex] = yuvColor.Green;
                this[i + YIndex] = yuvColor.Red;
            }
        }
    }
}

