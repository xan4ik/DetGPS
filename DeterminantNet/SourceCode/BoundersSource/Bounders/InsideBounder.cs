using System.Collections.Generic;

namespace DepthMapBounders
{
    public class InsideBounder : DepthMapBounder
    {
        public InsideBounder(float epsilon, int minNeighborNumber) : base(epsilon, minNeighborNumber)
        { }

        protected override void AddNeighborCells(MatrixPoint point)
        {
            if (boundMatrix[point.row, point.column] != ObjectPointFactor)
            {
                return;
            }
            for (int i = 0; i < 3; i++)
            {
                points.Enqueue(new MatrixPoint(point.row + i - 1, point.column - 1));
                points.Enqueue(new MatrixPoint(point.row + i - 1, point.column + 1));
            }
            points.Enqueue(new MatrixPoint(point.row + 1, point.column));
            points.Enqueue(new MatrixPoint(point.row - 1, point.column));
        }
    }
    
}
 