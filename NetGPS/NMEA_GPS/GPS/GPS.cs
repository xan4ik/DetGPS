using System.Collections.Generic;
using System.Text;


namespace GPS
{
    public struct GPS<T>
    {
        public GPS(T latitude, T longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public T Latitude { get; private set; }
        public T Longitude { get; private set; }
    }
}

