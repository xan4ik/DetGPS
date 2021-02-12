using System;
using System.Collections.Generic;
using System.Text;

namespace DepthMapBounders{
    public abstract class DimensionCalculator
    {
        public MatrixPoint[] GetObjectDimension(BoundMatrix boundMatrix)
        {
            ResetPoints();
            UpdatePoints(boundMatrix);
            return GetResult();
        }


        protected abstract void ResetPoints();
        protected abstract void UpdatePoints(BoundMatrix boundMatrix);
        protected abstract MatrixPoint[] GetResult();

    }
}
