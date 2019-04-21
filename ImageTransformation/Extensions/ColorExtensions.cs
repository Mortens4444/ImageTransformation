using System;
using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Enums;

namespace ImageTransformation.Extensions
{
    public static class ColorExtensions
    {
        public static double GetNonLinearGammaCorrectedValue(int component)
        {
            return (double)component / 255;
        }

        public static int GetComponentValue(double nonLinearGammaCorrectedValue)
        {
            return (int)Math.Round(nonLinearGammaCorrectedValue * 255);
        }

        public static Color ConvertToBlackOrWhite(this Color value)
        {
            //var distance = GetComponentValue(value.GetBt709Value());
            var distance = (int)Math.Round((double)(value.R + value.G + value.B) / 3);
            return (distance < 128) ? Color.Black : Color.White;
        }

        public static double GetBt601Value(double red, double green, double blue)
        {
            return 0.299 * red + 0.587 * green + 0.114 * blue;
        }

        public static double GetBt709Value(this Color value)
        {
            return GetBt709Value(GetNonLinearGammaCorrectedValue(value.R), GetNonLinearGammaCorrectedValue(value.G), GetNonLinearGammaCorrectedValue(value.B));
        }

        public static double GetBt709Value(double red, double green, double blue)
        {
            return 0.2125 * red + 0.7154 * green + 0.0721 * blue;
        }

        public static double GetNormalizedValue(ColorComponent component, int red, int green, int blue)
        {
            switch (component)
            {
                case ColorComponent.Red:
                    return (double)red / (red + green + blue);
                case ColorComponent.Green:
                    return (double)green / (red + green + blue);
                case ColorComponent.Blue:
                    return (double)blue / (red + green + blue);
                default:
                    throw new NotImplementedException();
            }
        }

		public static Rgb<double> GetNormalizedValue(double red, double green, double blue)
        {
            var sum = red + green + blue;
			return new Rgb<double>
            {
                Red = red / sum,
                Green = green / sum,
                Blue = blue / sum
            };
        }

        public static bool IsColorBetweenColors(this Color value, Color from, Color to)
        {
	        return IsComponentBetweenValues(value.A, from.A, to.A) && IsComponentBetweenValues(value.R, from.R, to.R)
				&& IsComponentBetweenValues(value.G, from.G, to.G) && IsComponentBetweenValues(value.B, from.B, to.B);
        }

		private static bool IsComponentBetweenValues(byte colorComponent, byte fromComponent, byte toComponent)
		{
			int colorComponentMaximum = Math.Max(fromComponent, toComponent);
			int colorComponentMinimum = Math.Min(fromComponent, toComponent);
			return (colorComponent >= colorComponentMinimum) && (colorComponent <= colorComponentMaximum);
		}
    }
}