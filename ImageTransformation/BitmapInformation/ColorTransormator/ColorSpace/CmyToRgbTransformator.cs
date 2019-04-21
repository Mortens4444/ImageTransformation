using System.Drawing;
using ImageTransformation.Colors;

namespace ImageTransformation.BitmapInformation
{
    public class CmyToRgbTransformator : Transformator
    {
        private const int CyanIndex = RedIndex;
        private const int YellowIndex = GreenIndex;
        //private const int MagentaIndex = 0;

        public CmyToRgbTransformator(Image img)
            : base(img)
        { }

        public CmyToRgbTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var cmyColor = new CmyColor(this[i + CyanIndex], this[i + YellowIndex], this[i]);
                this[i] = (byte)cmyColor.Blue;
                this[i + YellowIndex] = (byte)cmyColor.Green;
                this[i + CyanIndex] = (byte)cmyColor.Red;
            }
        }
    }
}
