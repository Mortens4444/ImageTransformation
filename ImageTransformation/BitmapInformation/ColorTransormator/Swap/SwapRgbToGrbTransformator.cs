using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    /// <summary>
    /// RGB => GRB
    /// </summary>
    public class SwapRgbToGrbTransformator : Transformator
    {
        public SwapRgbToGrbTransformator(Image img)
            : base(img)
        { }

        public SwapRgbToGrbTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                ByteExtensions.Swap(ref RgbBytes[i + GreenIndex], ref RgbBytes[i + RedIndex]);
            }
        }
    }
}
