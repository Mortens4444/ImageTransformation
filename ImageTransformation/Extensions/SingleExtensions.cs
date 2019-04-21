using System;

namespace ImageTransformation.Extensions
{
    public static class SingleExtensions
    {
        public static int LimitMeWithRound(this float value, int minimum, int maximum)
        {
            if (maximum < minimum)
            {
                IntExtensions.Swap(ref maximum, ref minimum);
            }
            return (int)Math.Round(Math.Max(minimum, Math.Min(maximum, value)));
        }
    }
}
