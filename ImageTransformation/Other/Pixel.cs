using System;
using System.Drawing;
using ImageTransformation.BitmapInformation;
using ImageTransformation.Colors;

namespace ImageTransformation.Other
{
    public class Pixel : ICloneable
    {
        private readonly int bitmapWidth;

        public Pixel(Transformator bitmapInfo, int index, int red, int green, int blue)
            : this(IndexToLocation(bitmapInfo.Width, index), Color.FromArgb(red, green, blue), index, bitmapInfo.Width)
        { }

        public Pixel(int bitmapWidth, int index, int red, int green, int blue)
            : this(IndexToLocation(bitmapWidth, index), Color.FromArgb(red, green, blue), index, bitmapWidth)
        { }

        public Pixel(Point location, Color color, int bitmapWidth)
            : this(location, color, LocationToIndex(bitmapWidth, location), bitmapWidth)
        { }

        public Pixel(Point location, Color color, int index, int bitmapWidth)
        {
            Color = color;
            Location = location;
            Index = index;
            this.bitmapWidth = bitmapWidth;
        }

        public Point Location { get; set; }

        public Color Color { get; set; }

        public int Index { get; set; }

        public object Clone()
        {
            return new Pixel(Location, Color, bitmapWidth);
        }

	    public Rgb<byte> GetRgb()
        {
			return new Rgb<byte>
            {
                Red = Color.R,
                Green = Color.G,
                Blue = Color.B
            };
        }

        public static Point IndexToLocation(Transformator bitmapInfo, int index)
        {
            return IndexToLocation(bitmapInfo.Width, index);
        }

        public static Point IndexToLocation(int width, int index)
        {
            return new Point(index % width, index / width);
        }

        public static int LocationToIndex(Transformator bitmapInfo, Point location)
        {
            return LocationToIndex(bitmapInfo.Width, location);
        }

        public static int LocationToIndex(int width, Point location)
        {
            return location.Y * width + location.X;
        }
    }
}
