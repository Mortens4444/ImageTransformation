using System;
using System.Drawing;
using ImageTransformation.Extensions;

namespace ImageTransformation.Colors
{
	public class CmyColor : Argb<int>
    {
		public Color Color { get; private set; }

		public int Cyan { get; private set; }
		public int Magenta { get; private set; }
		public int Yellow { get; private set; }

        public CmyColor(Color color)
        {
            Alpha = color.A;
            Red = color.R;
            Green = color.G;
            Blue = color.B;
            Color = color;

            Cyan = ColorExtensions.GetComponentValue(1 - ColorExtensions.GetNonLinearGammaCorrectedValue(Red));
            Magenta = ColorExtensions.GetComponentValue(1 - ColorExtensions.GetNonLinearGammaCorrectedValue(Green));
            Yellow = ColorExtensions.GetComponentValue(1 - ColorExtensions.GetNonLinearGammaCorrectedValue(Blue));
        }

        public CmyColor(int c, int m, int y)
        {
            Cyan = c;
            Magenta = m;
            Yellow = y;

            Alpha = Byte.MaxValue;
            Red = ColorExtensions.GetComponentValue(1 - ColorExtensions.GetNonLinearGammaCorrectedValue(Cyan));
            Green = ColorExtensions.GetComponentValue(1 - ColorExtensions.GetNonLinearGammaCorrectedValue(Magenta));
            Blue = ColorExtensions.GetComponentValue(1 - ColorExtensions.GetNonLinearGammaCorrectedValue(Yellow));
            Color = Color.FromArgb(Alpha, Red, Green, Blue);
        }

        public override string ToString()
        {
            return String.Format("RGB = ({0}, {1}, {2})", Red, Green, Blue);
            //return String.Format("CMY = ({0}, {1}, {2})", C, M, Y);
        }
    }
}
