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

        public Size GetObjectSize(IDepthMatrix<float> matrix, MatrixPoint[] dimension)
        {
            try
            {
                var minX = dimension[InternalDimensions.MinXIndex];
                var minXvector = converter.ConvertFrom(minX.row, minX.column, GetDepthFromMatrix(matrix, minX));

                var maxX = dimension[InternalDimensions.MaxXIndex];
                var maxXvector = converter.ConvertFrom(maxX.row, maxX.column, GetDepthFromMatrix(matrix, maxX));

                var minY = dimension[InternalDimensions.MinYIndex];
                var minYvector = converter.ConvertFrom(minY.row, minY.column, GetDepthFromMatrix(matrix, minY));

                var maxY = dimension[InternalDimensions.MaxYIndex];
                var maxYvector = converter.ConvertFrom(maxY.row, maxY.column, GetDepthFromMatrix(matrix, maxY));


                var width = Math.Sqrt(
                        Math.Pow(minXvector.X - maxXvector.X, 2) +
                        Math.Pow(0, 2) + // minXvector.Y - maxXvector.Y
                        Math.Pow(minXvector.Z - maxXvector.Z, 2)
                    );


                var height = Math.Sqrt(
                        Math.Pow(0, 2) + //minYvector.X - maxYvector.X
                        Math.Pow(minYvector.Y - maxYvector.Y, 2) +
                        Math.Pow(minYvector.Z - maxYvector.Z, 2)
                    );
                return new Size((float)width, (float)height);
                //var minX = converter.ConverX(dimension[InternalDimensions.MinXIndex].row, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MinXIndex]));
                //var maxX = converter.ConverX(dimension[InternalDimensions.MaxXIndex].row, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MaxXIndex]));

                //var minY = converter.ConverY(dimension[InternalDimensions.MinYIndex].column, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MinYIndex]));
                //var maxY = converter.ConverY(dimension[InternalDimensions.MaxYIndex].column, GetDepthFromMatrix(matrix, dimension[InternalDimensions.MaxYIndex]));

                //return new Size(Math.Abs(minX - maxX), Math.Abs(minY - maxY));
            }
            catch (Exception exc) 
            {
                return new Size(0, 0);
            }
        }

        private float GetDepthFromMatrix(IDepthMatrix<float> matrix, MatrixPoint point) 
        {
            return matrix.GetMatrixValue(point.row, point.column);
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
