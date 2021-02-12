using System;
using System.Collections.Generic;
using System.Text;

namespace NMEA
{
    public class MessageGPGGA
    {
        public MessageGPGGA(double latitude, double longitude, double altitude, string latitudeType, string longitudeType)
        {
            Latitude = latitude;
            Longitude = longitude;
            LatitudeType = latitudeType;
            LongitudeType = longitudeType;
            Altitude = altitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string LatitudeType { get; private set; }
        public string LongitudeType { get; private set; }
        public double Altitude { get; private set; }
    }
}
