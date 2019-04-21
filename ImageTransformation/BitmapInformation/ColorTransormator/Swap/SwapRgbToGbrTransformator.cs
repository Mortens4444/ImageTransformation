using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    /// <summary>
    /// RGB => RBG => GBR
    /// </summary>
    public class SwapRgbToGbrTransformator : Transformator
    {
        public SwapRgbToGbrTransformator(Image img)
            : base(img)
        { }

        public SwapRgbToGbrTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                ByteExtensions.Swap(ref RgbBytes[i], ref RgbBytes[i + GreenIndex]);
                ByteExtensions.Swap(ref RgbBytes[i], ref RgbBytes[i + RedIndex]);
            }
        }
    }
}
