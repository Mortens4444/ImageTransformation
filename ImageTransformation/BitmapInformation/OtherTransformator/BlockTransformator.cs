using System;
using System.Drawing;
using ImageTransformation.Colors;
using ImageTransformation.Extensions;

namespace ImageTransformation.BitmapInformation
{
    public class BlockTransformator : Transformator
    {
        private readonly int blockSize;

        public BlockTransformator(Image img, int blockSize)
            : base(img)
        {
            this.blockSize = blockSize;
        }

        public BlockTransformator(Bitmap bmp, int blockSize)
            : base(bmp)
        {
            this.blockSize = blockSize;
        }

        public override void Transform()
        {
            var result = new byte[Length];

            var i = 0;
            while (i < Length)
            {
                if (i.IsDivisible(ByteCountMultipiledByWidth)) i += (blockSize - 1) * ByteCountMultipiledByWidth;
                if (i.IsDivisible(blockSize * ByteCount))
                {
                    var rgb = GetAvarageRgbColor(i);
                    for (var j = 0; j < blockSize; j++)
                    {
                        for (var k = 0; k < blockSize; k++)
                        {
                            var index = i - j * ByteCountMultipiledByWidth + k * ByteCount;
                            if ((index <= 0) || (index >= Length))
                            {
                                continue;
                            }
                            result[index] = rgb.Blue;
                            result[index + GreenIndex] = rgb.Green;
                            result[index + RedIndex] = rgb.Red;
                            result[index + AlphaIndex] = Byte.MaxValue;
                        }
                    }
                }

                i += ByteCount;
            }
            RgbBytes = result;
        }

        private Rgb<byte> GetAvarageRgbColor(int i)
        {
            double avarageBlue = 0, avarageGreen = 0, avarageRed = 0, blockSizeSquare = blockSize * blockSize;
            for (var j = 0; j < blockSize; j++)
            {
                for (var k = 0; k < blockSize; k++)
                {
                    avarageBlue += this[i, j, k];
                    avarageGreen += this[i + GreenIndex, j, k];
                    avarageRed += this[i + RedIndex, j, k];
                }
            }

            return new Rgb<byte>
            {
                Blue = GetValue(avarageBlue, blockSizeSquare),
                Green = GetValue(avarageGreen, blockSizeSquare),
                Red = GetValue(avarageRed, blockSizeSquare)
            };
        }

        private static byte GetValue(double value, double blockSizeSquare)
        {
            return (byte)Math.Round(value / blockSizeSquare);
        }
    }
}
