using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DepthMapBounders;
using Intel.RealSense;

namespace Determinanters 
{ 
    public class SizeCalculator
    {
        private PixelToVecto3Converter converter;
        public SizeCalculator(Intrinsics intrinsics)
        {
            this.converter = new PixelToVecto3Converter(intrinsics);
        }

        public Size GetObjectSize(IDepthMatrix matrix, MatrixPoint[] dimension)
        {
            try
            {
                var minX = converter.ConverX(dimension[InternalDimensions.MinXIndex].row, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MinXIndex]));
                var maxX = converter.ConverX(dimension[InternalDimensions.MaxXIndex].row, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MaxXIndex]));

                var minY = converter.ConverY(dimension[InternalDimensions.MinYIndex].column, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MinYIndex]));
                var maxY = converter.ConverY(dimension[InternalDimensions.MaxYIndex].column, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MaxYIndex]));

                return new Size(Math.Abs(minX - maxX), Math.Abs(minY - maxY));
            }
            catch (Exception exc) 
            {
                return new Size(0, 0);
            }
        }

        private float GetDepthFromMatrix(IDepthMatrix matrix, MatrixPoint point) 
        {
            return matrix.GetDistance(point.row, point.column);
        }
    }

    public struct Size 
    {
        public float Width;
        public float Height;

        public Size(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
