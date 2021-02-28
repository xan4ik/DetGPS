using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Determinanters
{
    //public abstract class DimensionFinder<T>
    //{
    //    public const int MinX_index = 0;
    //    public const int MinY_index = 2;
    //    public const int MinZ_index = 4;
    //    public const int MaxX_index = 1;
    //    public const int MaxY_index = 3;
    //    public const int MaxZ_index = 5;



    //    public abstract Vector3Coordinate[] CalculateSize(IEnumerable<T> source);
    //}

    public interface IPointConverter<T>
    {
        float ConvertX(int X);
        float ConvertY(int Y);
        float ConvertZ(int Z);

        Vector3Coordinate ConvertFrom(T point);
    }

    public abstract class SizeDeterminant<T, Out> : BaseDeterminant<T, Out> 
    {
        private IPointConverter<T> converter;
        protected SizeDeterminant(IPointConverter<T> converter)
        {
            this.converter = converter;
        }

        protected IPointConverter<T> Converter 
        {
            get 
            {
                return converter;
            }
        }
    }
}
