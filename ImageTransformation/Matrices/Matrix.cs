using System;
using Real = System.Double;

namespace ImageTransformation.Matrices
{
    public class Matrix : ICloneable
    {
        protected Real[,] matrix;

        protected Matrix() { }

        protected Matrix(Real[,] matrix)
        {
            RowCount = (byte)matrix.GetLength(0);
            ColumnCount = (byte)matrix.GetLength(1);
            this.matrix = matrix;
        }

        public byte RowCount { get; protected set; }

        public byte ColumnCount { get; protected set; }

        public object Clone()
        {
            return new Matrix(matrix);
        }

        public Real this[byte rowIndex, byte columnIndex]
        {
            get
            {
                return matrix[rowIndex, columnIndex];
            }
            set
            {
                matrix[rowIndex, columnIndex] = value;
            }
        }

        public static Matrix operator +(Matrix matrix, Real lambda)
        {
            return Transform(matrix, lambda, (originalValue, delta) => originalValue + delta);
        }

        public static Matrix operator -(Matrix matrix, Real lambda)
        {
            return Transform(matrix, lambda, (originalValue, delta) => originalValue - delta);
        }

        public static Matrix operator *(Matrix matrix, Real lambda)
        {
            return Transform(matrix, lambda, (originalValue, delta) => originalValue * delta);
        }

        public static Matrix operator /(Matrix matrix, Real lambda)
        {
            return Transform(matrix, lambda, (originalValue, delta) => originalValue / delta);
        }

        private static Matrix Transform(Matrix matrix, Real lambda, Func<Real, Real, Real> valueProvider)
        {
            var result = (Matrix)matrix.Clone();
            for (byte i = 0; i < result.RowCount; i++)
            {
                for (byte j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = valueProvider(result[i, j], lambda);
                }
            }

            return result;
        }

        public static Matrix operator +(Matrix matrix, Matrix transformMatrix)
        {
            CheckMatrixBounds(matrix, transformMatrix);
            return Transform(matrix, transformMatrix, (originalValue, delta) => originalValue + delta);
        }

        public static Matrix operator -(Matrix matrix, Matrix transformMatrix)
        {
            CheckMatrixBounds(matrix, transformMatrix);
            return Transform(matrix, transformMatrix, (originalValue, delta) => originalValue - delta);
        }

        public static Matrix operator *(Matrix matrix, Matrix transformMatrix)
        {
            if (matrix.ColumnCount != transformMatrix.RowCount)
            {
                throw new InvalidOperationException();
            }

            var result = new Matrix(new Real[matrix.RowCount, transformMatrix.ColumnCount]);
            for (byte i = 0; i < result.RowCount; i++)
            {
                for (byte j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = 0;
                    for (byte k = 0; k < matrix.ColumnCount; k++)
                    {
                        result[i, j] += matrix[i, k] * transformMatrix[k, i];
                    }
                }
            }

            return result;
        }

        private static void CheckMatrixBounds(Matrix matrix, Matrix transformMatrix)
        {
            if ((matrix.RowCount != transformMatrix.RowCount) || (matrix.ColumnCount != transformMatrix.ColumnCount))
            {
                throw new InvalidOperationException();
            }
        }

        private static Matrix Transform(Matrix mtx, Matrix transformMatrix, Func<Real, Real, Real> valueProvider)
        {
            var result = (Matrix)mtx.Clone();
            for (byte i = 0; i < result.RowCount; i++)
            {
                for (byte j = 0; j < result.ColumnCount; j++)
                {
                    result[i, j] = valueProvider(result[i, j], transformMatrix[i, j]);
                }
            }

            return result;
        }

        public override int GetHashCode()
        {
            return (int)Math.Round(this[0, 0]);
        }

        public override bool Equals(object obj)
        {
            var mtx = obj as Matrix;
            if (mtx != null)
            {
                return this == mtx;
            }

            return false;
        }

        public static bool operator ==(Matrix mtx, Matrix mtx_2)
        {
            if ((mtx.RowCount != mtx_2.RowCount) || (mtx.ColumnCount != mtx_2.ColumnCount))
            {
                return false;
            }

            for (byte i = 0; i < mtx.RowCount; i++)
            {
                for (byte j = 0; j < mtx.ColumnCount; j++)
                {
                    if (mtx[i, j] != mtx_2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix mtx, Matrix mtx_2)
        {
            return !(mtx == mtx_2);
        }
    }
}
