using System;

namespace ImageTransformation.Extensions
{
    public static class IntExtensions
    {
        public static int LimitMe(this int value, int minimum, int maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }
            var upperLimit = Math.Min(maximum, value);
            return Math.Max(minimum, upperLimit);
        }

        public static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
            //a += b;
            //b = a - b;
            //a -= b;
        }

        public static bool IsDivisible(this int value, int divider)
        {
            return value % divider == 0;
        }
    }
}
