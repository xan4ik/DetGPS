using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Determinanters
{
    public interface IDepthMatrix<T>
    {
        T GetMatrixValue(int i, int j);
        int Width { get; }
        int Height { get; }
    }
}
