using System;
using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class NormalizedTransformator : Transformator
    {
        public NormalizedTransformator(Image img)
            : base(img)
        { }

        public NormalizedTransformator(Bitmap bmp)
            : base(bmp)
        { }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                var rgb = ColorExtensions.GetNormalizedValue(this[i + RedIndex], this[i + GreenIndex], this[i]);
                if (rgb.Red < 0.2 || rgb.Red > 0.46 || rgb.Green > 2 * rgb.Red - 0.4 && rgb.Red <= 0.46 || rgb.Red > 0.8 || rgb.Green > 1 - rgb.Red)
                {
					if (i + AlphaIndex < Length)
					{
						this[i + AlphaIndex] = Byte.MinValue;
					}
                }
                /*else
                {
                    var rgbSum = rgb.Red + rgb.Green + rgb.Blue;
                    this[i] = (byte)Math.Round(rgb.Blue / rgbSum);
                    this[i + 1] = (byte)Math.Round(rgb.Green / rgbSum);
                    this[i + 2] = (byte)Math.Round(rgb.Red / rgbSum);
                }*/
            }
        }
    }
}
