using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    /// <summary>
    /// RGB => BGR
    /// </summary>
    public class SwapRgbToBgrTransformator : Transformator
    {
        public SwapRgbToBgrTransformator(Image img)
            : base(img)
        { }

        public SwapRgbToBgrTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                ByteExtensions.Swap(ref RgbBytes[i], ref RgbBytes[i + RedIndex]);
            }
        }
    }
}
