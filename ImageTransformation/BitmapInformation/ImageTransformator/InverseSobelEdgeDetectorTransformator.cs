using System;
using System.Drawing;

namespace ImageTransformation.BitmapInformation
{
    public class InverseSobelEdgeDetectorTransformator : SobelEdgeDetectorTransformator
    {
        public InverseSobelEdgeDetectorTransformator(Image img)
            : base(img)
        { }

        public InverseSobelEdgeDetectorTransformator(Bitmap bmp)
            : base(bmp)
        { }

        protected override byte GetValue(int index)
        {
            var value = (byte)(Byte.MaxValue - base.GetValue(index));
            return (value < 180) ? Byte.MinValue : Byte.MaxValue;
        }
    }
}
