using System;

namespace NMEA
{
    public class ParserGPRMC : MessageParser
    {
        private ParserGPS parser;
        public ParserGPRMC() : base("$GPRMC")
        {
            parser = new ParserGPS();
        }

        protected override object GetParseResult(string[] splitMessage)
        {
            var latitude = parser.TryParseLatitude(splitMessage[3]);
            var longitude = parser.TryParseLongitude(splitMessage[5]);
            var latitudeType = splitMessage[4];
            var longitudeType = splitMessage[6];            
            var nodalSpeed = parser.ConvertDouble(splitMessage[7]);
            var directionAngle = parser.ConvertDouble(splitMessage[8]);

            return new MessageGPRMC(latitude, longitude, latitudeType, longitudeType, nodalSpeed, directionAngle);
        } 
    }
}
