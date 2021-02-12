using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DepthMapBounders
{
    public interface IDepthMatrix
    {
        float GetDistance(int i, int j);
        int Width { get; }
        int Height { get; }
    }
}
