using Determinanters;
using System;
using System.Collections.Generic;


namespace DepthMapBounders
{
    public abstract class DepthMapBounder 
    {
        public const int ObjectPointFactor = 1;
        public const int ObjectBorderFactor = -1;
        public const int UndefinedPointFactor = 0;

        private float epsilon;
        private int minNeighborNUmber;
        protected int[,] boundMatrix;
        protected Queue<MatrixPoint> points;

        public DepthMapBounder(float epsilon, int minNeighborNumber)
        {
            this.epsilon = epsilon;
            this.minNeighborNUmber = minNeighborNumber;
            this.points = new Queue<MatrixPoint>();
        }

        public float Epsilon
        {
            get => epsilon;
            set => epsilon = value;
        }

        public int FactorValue
        {
            get => minNeighborNUmber;
            set => minNeighborNUmber = value;
        }

        public BoundMatrix GetObjectBoundMatrix(IDepthMatrix<float> depthMatrix, int startX, int startY)
        {
            CrateBoundMatrixFor(depthMatrix);
            InitializeQueue(startX, startY);
            FillBoundMatrix(depthMatrix, boundMatrix);
            return new BoundMatrix(boundMatrix);
        }

        private void CrateBoundMatrixFor(IDepthMatrix<float> depthMatrix)
        {
            boundMatrix = new int[depthMatrix.Width, depthMatrix.Height];
        }

        private void InitializeQueue(int startX, int startY)
        {
            points.Clear();
            points.Enqueue(new MatrixPoint(startX, startY));
        }


        private void FillBoundMatrix(IDepthMatrix<float> depthMatrix, int[,] bounds)
        {
            while (!IsQueueEmpty())
            {
                var point = points.Dequeue();
                if (!IsCellInArea(point.row, point.column) || IsCellChecked(point.row, point.column))
                {
                    continue;
                }

                FlagCenterCell(depthMatrix, point);
                AddNeighborCells(point);
            }
        }

        private void FlagCenterCell(IDepthMatrix<float> arr, MatrixPoint currentPoint)
        {
            var count = CountCellsInEpsilonCircle(arr, currentPoint.row, currentPoint.column);
            if (count >= minNeighborNUmber)
            {
                boundMatrix[currentPoint.row, currentPoint.column] = ObjectPointFactor;
            }
            else
            {
                boundMatrix[currentPoint.row, currentPoint.column] = ObjectBorderFactor;
            }
        }

        protected abstract void AddNeighborCells(MatrixPoint point);

        private int CountCellsInEpsilonCircle(IDepthMatrix<float> depthMatrix, int row, int column)
        {
            int count = 0;

            for (int i = 0; i < 3; i++)
            {
                if (IsCellInEpsilonCircle(depthMatrix, row, column, row + i - 1, column - 1))
                {
                    count++;
                }
                if (IsCellInEpsilonCircle(depthMatrix, row, column, row + i - 1, column + 1))
                {
                    count++;
                }
            }
            if (IsCellInEpsilonCircle(depthMatrix, row, column, row + 1, column))
            {
                count++;
            }
            if (IsCellInEpsilonCircle(depthMatrix, row, column, row - 1, column))
            {
                count++;
            }

            return count;
        }

        private bool IsCellInEpsilonCircle(IDepthMatrix<float> depthMatrix, int row, int column, int neighborX, int neighborY)
        {
            if (!IsCellInArea(neighborX, neighborY))
            {
                return false;
            }
            else
            {
                return Math.Abs(Math.Abs(depthMatrix.GetMatrixValue(row, column)) - Math.Abs(depthMatrix.GetMatrixValue(neighborX, neighborY))) <= epsilon;
            }
        }

        private bool IsQueueEmpty()
        {
            return points.Count == 0;
        }

        private bool IsCellInArea(int x, int y)
        {
            return x >= 0 && x < boundMatrix.GetLength(0) && y >= 0 && y < boundMatrix.GetLength(1);
        }

        private bool IsCellChecked(int x, int y)
        {
            return boundMatrix[x, y] != UndefinedPointFactor;
        }
    }
}
 