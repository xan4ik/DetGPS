using System;


namespace GPS
{ 
    public class ManipulatorGPS
    {
        private static double earthRadius;

        static ManipulatorGPS()
        {
            earthRadius = 6378137;
        }

        public GPS<float> RecountGPS(float latitude, float longitude, float directionAngle, float offsetX, float offsetY)
        {
            var degreeAngle = ConvertAngleFromCompass(directionAngle);
            var radianAngle = ConvertDegreeToRadian(degreeAngle);
            var _latitude = latitude + (180 / Math.PI) * (offsetY / earthRadius) * Math.Sin(radianAngle);
            var _longitude = longitude + (180 / Math.PI) * (offsetY / earthRadius) / Math.Cos(latitude) * Math.Cos(radianAngle);

            return new GPS<float>((float)_latitude, (float)_longitude);
        }

        public GPS<double> RecountGPS(double latitude, double longitude, double directionAngle, double offsetX, double offsetY)
        {

            var degreeAngle = ConvertAngleFromCompass(directionAngle);
            var radianAngle = ConvertDegreeToRadian(degreeAngle);
            var _latitude = latitude + (180 / Math.PI) * (offsetY / earthRadius) * Math.Sin(radianAngle);
            var _longitude = longitude + (180 / Math.PI) * (offsetY / earthRadius) / Math.Cos(latitude) * Math.Cos(radianAngle);
            
            return new GPS<double>(_latitude, _longitude);
        }

        private double ConvertDegreeToRadian(double degreeAngle)
        {
            return degreeAngle * (Math.PI / 180);
        }

        private double ConvertAngleFromCompass(double directionAngle)
        {
            return 360 - (directionAngle - 90);
        }     
    }
}

