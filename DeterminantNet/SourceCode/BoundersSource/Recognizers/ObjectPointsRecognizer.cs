using System.Collections.Generic;


namespace DepthMapBounders
{
    public class ObjectPointsRecognizer
    {
        private int pointFactor;

        public ObjectPointsRecognizer(int pointFactor)
        {
            this.pointFactor = pointFactor;
        }

        public int PointFactor 
        {
            get => pointFactor; 
            set => pointFactor = value; 
        }

        public IEnumerable<MatrixPoint> GetInnerObjectPoints(BoundMatrix boundMatrix)
        {
            foreach (var point in boundMatrix.GetMatrixPoints())
            {
                if (boundMatrix.IsPointEqualTo(point, pointFactor))
                {
                    yield return point;
                }
            }
        }
    }
}
    

 