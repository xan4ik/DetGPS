using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intel.RealSense;

namespace Determinanters
{
    public class PixelToVecto3Converter
    {
        private Intrinsics intrinsics;

        public PixelToVecto3Converter(Intrinsics intrinsics)
        {
            this.intrinsics = intrinsics;
        }

        public float ConverX(int x, float depth) 
        {
            return (x - intrinsics.ppx) / intrinsics.fx * depth;
        }

        public float ConverY(int y, float depth)
        {
            return (y - intrinsics.ppy) / intrinsics.fy * depth;
        }


        public Vector3Coordinate ConvertFrom(int x, int y, float depth) 
        {
            float newX = ConverX(x, depth);
            float newY = ConverY(y, depth);
            return new Vector3Coordinate(newX, newY, depth);
        }
    }
}
