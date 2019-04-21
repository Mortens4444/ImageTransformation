using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    /// <summary>
    /// RGB => RBG
    /// </summary>
    public class SwapRgbToRbgTransformator : Transformator
    {
        public SwapRgbToRbgTransformator(Image img)
            : base(img)
        { }

        public SwapRgbToRbgTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                ByteExtensions.Swap(ref RgbBytes[i], ref RgbBytes[i + GreenIndex]);
            }
        }
    }
}
