using System;
using System.Collections.Generic;
using System.Text;


namespace DepthMapBounders
{
    public class BoundMatrix
    {
        private int[,] matrix;

        public BoundMatrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public bool IsPointEqualTo(MatrixPoint point, int value) 
        {
            if (IsPointBelongsToMatrix(point))
            {
                return matrix[point.row, point.column] == value;
            }
            else throw new IndexOutOfRangeException("Matrix point out of range");
        }

        public IEnumerable<MatrixPoint> GetMatrixPoints() 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    yield return new MatrixPoint(i, j);
                }
            }
        }

        private bool IsPointBelongsToMatrix(MatrixPoint point) 
        {
            if (point.row >= 0 && point.row < matrix.GetLength(0)) 
            {
                if (point.column >= 0 && point.column < matrix.GetLength(1)) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
