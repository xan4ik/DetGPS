using Intel.RealSense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Determinanters
{
    public struct Vector3Coordinate
    {
        private float x;
        private float y;
        private float z;

        public Vector3Coordinate(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float X
        {
            get
            {
                return x;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
        }

        public float Z
        {
            get
            {
                return z;
            }
        }

        public override string ToString()
        {
            return $"x: {x}, y: {y}, z: {z}";
        }
    }

    //public class CoordinatesDeterminant : BaseDeterminant<Vector3Coordinate, Vector3Coordinate>
    //{
    //    private PixelToVecto3Converter converter;
    //    public CoordinatesDeterminant(Intrinsics depthCamMetrix, params ISelectFilter<Vector3Coordinate>[] filters) : base(filters)
    //    {
    //        this.converter = new PixelToVecto3Converter(depthCamMetrix);
    //    }

    //    protected override IEnumerable<Vector3Coordinate> GetSourceData(IDepthMatrix frame, SelectArea selectArea)
    //    {
    //        for (int i = selectArea.LocationX; i < selectArea.LocationX + selectArea.Width; i++)
    //        {
    //            for (int j = selectArea.LocationY; j < selectArea.LocationY + selectArea.Heigh; j++)
    //            {
    //                yield return converter.ConvertFrom(i, j, frame.GetMatrixValue(i, j));
    //            }
    //        }
    //    }

    //    protected override Vector3Coordinate FinalCalculation(IEnumerable<Vector3Coordinate> data)
    //    {
    //        var pointsCount = data.Count();
    //        var x = data.Sum(coord => coord.X) / pointsCount;
    //        var y = data.Sum(coord => coord.Y) / pointsCount;
    //        var z = data.Sum(coord => coord.Z) / pointsCount;

    //        return new Vector3Coordinate(x, y, z);
    //    }
    //}
}
