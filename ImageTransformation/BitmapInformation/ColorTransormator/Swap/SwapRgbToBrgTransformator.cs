using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    /// <summary>
    /// RGB => BGR => BRG
    /// </summary>
    public class SwapRgbToBrgTransformator : Transformator
    {
        public SwapRgbToBrgTransformator(Image img)
            : base(img)
        { }

        public SwapRgbToBrgTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                ByteExtensions.Swap(ref RgbBytes[i], ref RgbBytes[i + RedIndex]);
                ByteExtensions.Swap(ref RgbBytes[i], ref RgbBytes[i + GreenIndex]);
            }
        }
    }
}
