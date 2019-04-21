using System;

namespace ImageTransformation.Extensions
{
    public static class DoubleExtensions
    {
        public static int LimitMeWithRound(this double value, int minimum, int maximum)
        {
            if (maximum < minimum)
            {
                IntExtensions.Swap(ref maximum, ref minimum);
            }
            return (int)Math.Round(Math.Max(minimum, Math.Min(maximum, value)));
        }
    }
}
