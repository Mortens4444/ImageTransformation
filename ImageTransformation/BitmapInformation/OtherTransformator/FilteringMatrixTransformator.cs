using System;
using System.Drawing;
using ImageTransformation.Matrices;
using ImageTransformation.TransformMethods;
using ImageTransformation.Colors;
using Real = System.Double;

namespace ImageTransformation.BitmapInformation
{
    public class FilteringMatrixTransformator: Transformator
    {
        private readonly FilteringMatrix filterMatrix;

        public FilteringMatrixTransformator(Image img, FilterMatrixTransformMethod filterMatrixTransformMethod)
            : base(img)
        {
            filterMatrix = new FilteringMatrix(filterMatrixTransformMethod);
        }

        public FilteringMatrixTransformator(Bitmap bmp, FilterMatrixTransformMethod filterMatrixTransformMethod)
            : base(bmp)
        {
            filterMatrix = new FilteringMatrix(filterMatrixTransformMethod);
        }

        public FilteringMatrixTransformator(Image img, FilteringMatrix filterMatrix)
            : base(img)
        {
            this.filterMatrix = filterMatrix;
        }

        public FilteringMatrixTransformator(Bitmap bmp, FilteringMatrix filterMatrix)
            : base(bmp)
        {
            this.filterMatrix = filterMatrix;
        }

        public override void Transform()
        {
			var result = new byte[Length];
            for (var i = 0; i < Length; i += ByteCount)
            {
                var rgb = GetRgbModifier(i);
                result[i] = filterMatrix.GetValue(rgb.Blue);
                result[i + GreenIndex] = filterMatrix.GetValue(rgb.Green);
                result[i + RedIndex] = filterMatrix.GetValue(rgb.Red);
				result[i + AlphaIndex] = Byte.MaxValue;
            }
	        RgbBytes = result;
        }

        private Rgb<Real> GetRgbModifier(int index)
        {
            var result = new Rgb<Real>();
            for (byte j = 0; j < filterMatrix.RowCount; j++)
            {
                var baseIndex = GetIxWithDeltaRow(index, j);
                for (byte k = 0; k < filterMatrix.ColumnCount; k++)
                {
                    var ix = GetIxWithDeltaColumn(baseIndex, k);
                    if ((ix >= 0) && (ix < Length))
                    {
                        var fmValue = filterMatrix[j, k];
                        result.Blue += RgbBytes[ix] * fmValue;
                        result.Green += RgbBytes[ix + GreenIndex] * fmValue;
                        result.Red += RgbBytes[ix + RedIndex] * fmValue;
                    }
                }
            }
            return result;
        }
    }
}