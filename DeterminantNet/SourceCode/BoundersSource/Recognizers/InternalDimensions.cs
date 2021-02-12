namespace DepthMapBounders
{
    public class InternalDimensions : DimensionCalculator
    {
        public const int MinXIndex = 0;
        public const int MaxXIndex = 2;
        public const int MinYIndex = 1;
        public const int MaxYIndex = 3;
        private MatrixPoint MinYPoint;
        private MatrixPoint MaxYPoint;
        private MatrixPoint MaxXPoint;
        private MatrixPoint MinXPoint;

        protected override void ResetPoints()
        {
            MinYPoint = new MatrixPoint(0, int.MaxValue);
            MaxYPoint = new MatrixPoint(0, 0);
            MaxXPoint = new MatrixPoint(0, 0);
            MinXPoint = new MatrixPoint(int.MaxValue, 0);
        }

        protected override void UpdatePoints(BoundMatrix boundMatrix) 
        {
            foreach (var point in boundMatrix.GetMatrixPoints())
            {
                if (boundMatrix.IsPointEqualTo(point, DepthMapBounder.ObjectPointFactor)) 
                {
                    UpdatePointX(point);
                    UpdatePointY(point);
                }
            }
        }

        protected override MatrixPoint[] GetResult() 
        {
           return new MatrixPoint[] { MinXPoint, MinYPoint, MaxXPoint, MaxYPoint };
        }

        private void UpdatePointX(MatrixPoint point) 
        {
            if (point.row > MaxXPoint.row)
            {
                MaxXPoint = point;
            }
            else if (point.row < MinXPoint.row)
            {
                MinXPoint = point;
            }
        }

        private void UpdatePointY(MatrixPoint point) 
        {
            if (point.column > MaxYPoint.column)
            {
                MaxYPoint = point;
            }
            else if (point.column < MinYPoint.column)
            {
                MinYPoint = point;
            }
        }

    }
}
    

 