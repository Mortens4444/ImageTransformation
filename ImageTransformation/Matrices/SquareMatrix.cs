using System;
using Real = System.Double;

namespace ImageTransformation.Matrices
{
    public class SquareMatrix : Matrix
    {
        protected SquareMatrix(params Real[] squareMatrixValues)
        {
            InitializeSquareMatrixValues(squareMatrixValues);
        }

        protected SquareMatrix(Real[,] squareMatrix)
            : base(squareMatrix)
        {
            if (squareMatrix.GetLength(0) != squareMatrix.GetLength(1))
            {
                throw new ArgumentException("Parameter name: squareMatrix", "squareMatrix");
            }
        }

        protected void InitializeSquareMatrixValues(params Real[] squareMatrixValues)
        {
            var sqrt = Math.Round(Math.Sqrt(squareMatrixValues.Length));
            if (sqrt * sqrt != squareMatrixValues.Length)
            {
                throw new ArgumentException("Parameter name: squareMatrixValues", "squareMatrixValues");
            }

            RowCount = (byte)sqrt;
            ColumnCount = RowCount;

            matrix = new Real[RowCount, ColumnCount];

            var index = 0;
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    matrix[i, j] = squareMatrixValues[index++];
                }
            }
        }
    }
}
