using NMEA;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NMEA
{
    public class ParserGPGGA : MessageParser
    {
        private ParserGPS parserGPS;
        public ParserGPGGA() : base("$GPGGA") 
        {
            parserGPS = new ParserGPS();       
        }

        protected override object GetParseResult(string[] splitMessage)
        {
            double latitude = parserGPS.TryParseLatitude(splitMessage[2]);
            double longitude = parserGPS.TryParseLongitude(splitMessage[4]);
            double altitude = GetAltitude(splitMessage[9]);
            string latitudeType = splitMessage[3];
            string longitudeType = splitMessage[5];

            return new MessageGPGGA(latitude, longitude, altitude, latitudeType, longitudeType);
        }

        private double GetAltitude(string altitude) 
        {
            if (altitude == String.Empty)
            {
                return 0;
            }
            else return double.Parse(altitude);
        }
    }
}
