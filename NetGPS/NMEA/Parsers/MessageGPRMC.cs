namespace NMEA
{
    public class MessageGPRMC
    {
        public MessageGPRMC(double latitude, double longitude, string latitudeType, string longitudeType, double nodalSpeed, double directionAngle)
        {
            Latitude = latitude;
            Longitude = longitude;
            LatitudeType = latitudeType;
            LongitudeType = longitudeType;
            NodalSpeed = nodalSpeed;
            DirectionAngle = directionAngle;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string LatitudeType { get; private set; }
        public string LongitudeType { get; private set; }
        public double NodalSpeed { get; private set; }
        public double DirectionAngle { get; private set; }
    }

}
