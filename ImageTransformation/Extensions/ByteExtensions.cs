using System;

namespace ImageTransformation.Extensions
{
    public static class ByteExtensions
    {
	    public static byte LimitMe(this byte value)
	    {
			return value.LimitMe(Byte.MinValue, Byte.MaxValue);
	    }

	    public static byte LimitMe(this byte value, byte minimum)
	    {
			return value.LimitMe(minimum, Byte.MaxValue);
	    }

	    public static byte LimitMe(this byte value, byte minimum, byte maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }
            var upperLimit = Math.Min(maximum, value);
            return Math.Max(minimum, upperLimit);
        }

        public static void Swap(ref byte a, ref byte b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
            //a += b;
            //b = a - b;
            //a -= b;
        }

        public static bool IsDivisible(byte number, byte divider)
        {
            return number % divider == 0;
        }
    }
}
