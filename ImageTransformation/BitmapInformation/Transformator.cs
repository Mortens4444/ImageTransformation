using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using ImageTransformation.Enums;
using ImageTransformation.Other;

namespace ImageTransformation.BitmapInformation
{
    public abstract class Transformator
    {
        protected const int GreenIndex = 1;

        protected const int RedIndex = 2;

        protected const int AlphaIndex = 3;

        protected Transformator(Image img)
        {
            Bitmap = new Bitmap(img);
            Initialize();
        }

        protected Transformator(Bitmap bmp)
        {
            Bitmap = bmp;
            Initialize();
        }

	    protected byte[] RgbBytes { get; set; }

        public byte BitCount { get; set; }

	    protected byte ByteCount { get; set; }

        public PixelFormat PixelFormat { get; set; }

        public Bitmap Bitmap { get; set; }

	    protected int ByteCountMultipiledByWidth { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Stride { get; private set; }

        void Initialize()
        {
            BitCount = ConvertPixelFormatToBitCount(Bitmap.PixelFormat);
            ByteCount = (byte)Math.Round((double)BitCount / 8);
            Width = Bitmap.Width;
            Height = Bitmap.Height;
            RgbBytes = GetByteArrayFromBitmap(Bitmap);
            ByteCountMultipiledByWidth = ByteCount * Width;
        }

        public Pixel GetPixelAt(int index)
        {
            return new Pixel(Width, index, this[index + RedIndex], this[index + GreenIndex], this[index]);
        }

        public void SetPixel(Pixel pixel)
        {
            SetPixelAt(pixel, pixel.Index);
        }

        public void SetPixelAt(Pixel pixel, int index)
        {
            this[index + RedIndex] = pixel.Color.R;
            this[index + GreenIndex] = pixel.Color.G;
            this[index] = pixel.Color.B;
        }

        public static byte ConvertPixelFormatToBitCount(PixelFormat format)
        {
            if (format == PixelFormat.Canonical)
            {
                return 32;
            }

            var formatName = format.ToString();
            if (formatName.Substring(0, 6) != "Format")
            {
                throw new Exception(String.Format("Unknown pixel format: {0}", formatName));
            }

            formatName = formatName.Substring(6, 2);
	        return Convert.ToByte(Char.IsNumber(formatName[1]) ? formatName : formatName[0].ToString(CultureInfo.InvariantCulture));
        }

        private unsafe byte[] GetByteArrayFromBitmap(Bitmap bitmap)
        {
            var bmpData = GetBitmapData(bitmap);
            Stride = bmpData.Stride;
            var bitmapRgbBytes = new byte[GetRgbByteArrayLength(bmpData)];

			//Marshal.Copy(bmpData.Scan0, bitmapRgbBytes, 0, bitmapRgbBytes.Length);
			var bytes = (byte*)bmpData.Scan0;
			for (var i = 0; i < bitmapRgbBytes.Length; i++)
			{
				bitmapRgbBytes[i] = bytes[i];
			}

            bitmap.UnlockBits(bmpData);
            GC.Collect();
            return bitmapRgbBytes;
        }

        private unsafe static void CopyByteArrayToBitmap(byte[] bitmapRgbBytes, Bitmap bitmap)
        {
            var bmpData = GetBitmapData(bitmap);

			//Marshal.Copy(bitmapRgbBytes, 0, bmpData.Scan0, GetRgbByteArrayLength(bmpData));
			var bytes = (byte*)bmpData.Scan0;
			for (var i = 0; i < bitmapRgbBytes.Length; i++)
			{
				bytes[i] = bitmapRgbBytes[i];
			}

            bitmap.UnlockBits(bmpData);
            GC.Collect();
        }
         
        private static BitmapData GetBitmapData(Bitmap bitmap)
        {
            var lockBitsRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            return bitmap.LockBits(lockBitsRectangle, ImageLockMode.ReadOnly, bitmap.PixelFormat);
        }

        private static int GetRgbByteArrayLength(BitmapData bitmapData)
        {
            return bitmapData.Stride * bitmapData.Height;
        }

	    protected int Length
        {
            get
            {
                return RgbBytes.Length;
            }
        }

        public void FinalizeChangesInRgbByteArray()
        {
            CopyByteArrayToBitmap(RgbBytes, Bitmap);

            #if __MonoCS__
                var arrayHandle = GCHandle.Alloc(RgbBytes, GCHandleType.Pinned);
                Bitmap = new Bitmap(Width, Height, Stride, PixelFormat.Format32bppArgb, arrayHandle.AddrOfPinnedObject());
            #endif
        }

        /// <summary>
        /// NW  N   NE
        /// W       E
        /// SW  S   SE
        /// </summary>
        /// <param name="index">Pixel index</param>
        /// <param name="direction">Direction of neighbor</param>
        /// <returns>Index of neighbor</returns>
        public int GetNeighborIndex(int index, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return index - ByteCount * Width;
                case Direction.NorthEast:
                    return index - ByteCount * Width + ByteCount;
                case Direction.East:
                    return index + ByteCount;
                case Direction.SouthEast:
                    return index + ByteCount * Width + ByteCount;
                case Direction.South:
                    return index + ByteCount * Width;
                case Direction.SouthWest:
                    return index + ByteCount * Width - ByteCount;
                case Direction.West:
                    return index - ByteCount;
                case Direction.NorthWest:
                    return index - ByteCount * Width - ByteCount;
                default:
                    throw new NotImplementedException();
            }
        }

        protected int GetIxWithDeltaRow(int index, int deltaRow)
        {
            return index + deltaRow * ByteCountMultipiledByWidth;
        }

        protected int GetIxWithDeltaColumn(int baseIndex, int deltaColumn)
        {
            return baseIndex + deltaColumn * ByteCount;
        }

        private int GetIx(int index, int deltaRow, int deltaColumn)
        {
            return GetIxWithDeltaColumn(GetIxWithDeltaRow(index, deltaRow), deltaColumn);
        }

        private bool IsValidIx(int ix)
        {
            return (ix >= 0) && (ix < Length);
        }

	    protected byte this[int index]
        {
            get
            {
                return RgbBytes[index];
            }
            set
            {
				RgbBytes[index] = value;
            }
        }

	    protected byte this[int index, int deltaRow, int deltaColumn]
        {
            get
            {
                var ix = GetIx(index, deltaRow, deltaColumn);
                if (!IsValidIx(ix))
                {
                    return 0;
                }
                return RgbBytes[ix];
            }
            set
            {
                var ix = GetIx(index, deltaRow, deltaColumn);
                if (!IsValidIx(ix))
                {
                    return;
                }
                RgbBytes[ix] = value;
            }
        }

	    protected byte this[int index, Direction direction]
        {
            get
            {
                if ((direction == Direction.West) && (index % ByteCountMultipiledByWidth == 0))
                {
                    return 0;
                }
                if ((direction == Direction.East) && (index % ByteCountMultipiledByWidth == ByteCountMultipiledByWidth - ByteCount))
                {
                    return 0;
                }

                if ((direction == Direction.NorthEast) && ((index % ByteCountMultipiledByWidth == ByteCountMultipiledByWidth - ByteCount)) || (index < ByteCountMultipiledByWidth))
                {
                    return 0;
                }
                if ((direction == Direction.NorthWest) && ((index % ByteCountMultipiledByWidth == 0) || (index < ByteCountMultipiledByWidth)))
                {
                    return 0;
                }

                if ((direction == Direction.SouthEast) && ((index % ByteCountMultipiledByWidth == ByteCountMultipiledByWidth - ByteCount) || (index >= Length - ByteCountMultipiledByWidth)))
                {
                    return 0;
                }
                if ((direction == Direction.SouthWest) && ((index % ByteCountMultipiledByWidth == 0) || (index >= Length - ByteCountMultipiledByWidth)))
                {
                    return 0;
                }

                if ((direction == Direction.North) && (index < ByteCountMultipiledByWidth))
                {
                    return 0;
                }
                if ((direction == Direction.South) && (index >= Length - ByteCountMultipiledByWidth))
                {
                    return 0;
                }

                return RgbBytes[GetNeighborIndex(index, direction)];
            }
            set
            {
                RgbBytes[GetNeighborIndex(index, direction)] = value;
            }
        }

        public abstract void Transform();
    }
}
