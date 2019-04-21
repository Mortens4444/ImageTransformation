using System;
using System.Drawing;
using ImageTransformation.Enums;

namespace ImageTransformation.Colors
{
    public class YuvColor : Argb<byte>
    {
        private readonly int c;
        private readonly int d;
        private readonly int e;

        public YuvColor(Color color)
            : this(color.R, color.G, color.B, ColorSpaceType.RGB)
        {
        }

        public YuvColor(int r_c_y, int g_d_u, int b_e_v, ColorSpaceType type)
        {
            switch (type)
            {
                case ColorSpaceType.RGB:
                    c = Convert.ToInt32((66 * r_c_y + 129 * g_d_u + 25 * b_e_v + 128) >> 8);
                    d = Convert.ToInt32((-38 * r_c_y - 74 * g_d_u + 112 * b_e_v + 128) >> 8);
                    e = Convert.ToInt32((112 * r_c_y - 94 * g_d_u - 18 * b_e_v + 128) >> 8);
                    Y = Convert.ToByte(c + 16);
                    U = Convert.ToByte(d + 128);
                    V = Convert.ToByte(e + 128);
                    Red = Convert.ToByte(r_c_y);
                    Green = Convert.ToByte(g_d_u);
                    Blue = Convert.ToByte(b_e_v);
                    break;
                case ColorSpaceType.CDE:
                    c = r_c_y;
                    d = g_d_u;
                    e = b_e_v;
                    Y = Convert.ToByte(c + 16);
                    U = Convert.ToByte(d + 128);
                    V = Convert.ToByte(e + 128);
                    Red = Clip((298 * c + 409 * e + 128) >> 8);
                    Green = Clip((298 * c - 100 * d - 208 * e + 128) >> 8);
                    Blue = Clip((298 * c + 516 * d + 128) >> 8);
                    break;
                case ColorSpaceType.YUV:
                    Y = Convert.ToByte(r_c_y);
                    U = Convert.ToByte(g_d_u);
                    V = Convert.ToByte(b_e_v);
                    c = Convert.ToInt32(Y - 16);
                    d = Convert.ToInt32(U - 128);
                    e = Convert.ToInt32(V - 128);
                    Red = Clip((298 * c + 409 * e + 128) >> 8);
                    Green = Clip((298 * c - 100 * d - 208 * e + 128) >> 8);
                    Blue = Clip((298 * c + 516 * d + 128) >> 8);
                    break;
            }
        }

        public byte Y { get; private set; }

        public byte U { get; private set; }

        public byte V { get; private set; }

        private static byte Clip(int value)
        {
            return Convert.ToByte(Math.Max(Math.Min(value, Byte.MaxValue), 0));
        }

        public Color ToColor()
        {
            return ConvertToColor(this);
        }

        public static Color ConvertToColor(YuvColor yuvColor)
        {
            return Color.FromArgb(yuvColor.Red, yuvColor.Green, yuvColor.Blue);
        }

        public override string ToString()
        {
            return String.Format("RGB = ({0}, {1}, {2})", Red, Green, Blue);
            //return String.Format("YUV = ({0}, {1}, {2})", Y, U, V);
        }
    }
}