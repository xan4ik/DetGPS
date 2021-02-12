using System;

namespace DepthMapBounders
{
    public class ExternalDimensions : DimensionCalculator
    {
        public const int LeftHighEdgeIndex = 0;
        public const int RightLowEdgeIndex = 0;
        private int minIndexX;
        private int minIndexY;
        private int maxIndexX;
        private int maxIndexY;

        protected override void ResetPoints() 
        {
            minIndexX = int.MaxValue;
            minIndexY = int.MaxValue;
            maxIndexX = int.MinValue;
            maxIndexY = int.MinValue;
        }

        protected override void UpdatePoints(BoundMatrix boundMatrix)
        {
            foreach (var point in boundMatrix.GetMatrixPoints())
            {
                if (boundMatrix.IsPointEqualTo(point, DepthMapBounder.ObjectPointFactor))
                {
                    UpdateMinMax(ref minIndexX, ref maxIndexX, point.row);
                    UpdateMinMax(ref minIndexY, ref maxIndexY, point.column);
                }
            }
        }

        protected override MatrixPoint[] GetResult()
        {
            return new MatrixPoint[] 
            {
                new MatrixPoint(minIndexX, minIndexY),
                new MatrixPoint(maxIndexX, maxIndexY)
            };
        }

        private void UpdateMinMax(ref int min, ref int max, int value)
        {
            if (min > value)
            {
                min = value;
            }
            else if (max < value)
            {
                max = value;
            }
        }
    }
}
    

 