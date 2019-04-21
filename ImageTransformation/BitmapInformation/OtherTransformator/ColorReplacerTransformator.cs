using System;
using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class ColorReplacerTransformator : Transformator
    {
        private Color from;
        private Color to;
        private Color replace;

        public ColorReplacerTransformator(Image img, Color from, Color to, Color replace)
            : base(img)
        {
            Initialize(from, to, replace);
        }

        public ColorReplacerTransformator(Bitmap bmp, Color from, Color to, Color replace)
            : base(bmp)
        {
            Initialize(from, to, replace);
        }

        private void Initialize(Color fromColor, Color toColor, Color replaceColor)
        {
            from = fromColor;
            to = toColor;
            replace = replaceColor;
        }

        public override void Transform()
        {
            for (var i = 0; i < Length; i += ByteCount)
            {
                Color c;
                switch (ByteCount)
                {
                    case 3:
                        c = Color.FromArgb(this[i + RedIndex], this[i + GreenIndex], this[i]);
                        break;
                    case 4:
                        c = Color.FromArgb(this[i + AlphaIndex], this[i + RedIndex], this[i + GreenIndex], this[i]);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                if (!c.IsColorBetweenColors(from, to))
                {
                    continue;
                }

                if (ByteCount != 3)
                {
                    this[i + AlphaIndex] = replace.A;
                }

                this[i + RedIndex] = replace.R;
                this[i + GreenIndex] = replace.G;
                this[i] = replace.B;
            }
        }
    }
}
