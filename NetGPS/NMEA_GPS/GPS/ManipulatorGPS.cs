using System;


namespace GPS
{ 
    public class ManipulatorGPS
    {
        private const double EarthRadius = 6378137.0;
        private const double RADIANS = Math.PI / 180;
        private const double DEGREES = 180 / Math.PI;

        public GPS<double> MoveGPS(GPS<double> from, double distance, double brearing)
        {
            double lat1 = from.Latitude * RADIANS;
            double lon1 = from.Longitude * RADIANS;
            double radbear = brearing * RADIANS;

            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(distance / EarthRadius) + Math.Cos(lat1) * Math.Sin(distance / EarthRadius) * Math.Cos(radbear));
            double lon2 = lon1 + Math.Atan2(Math.Sin(radbear) * Math.Sin(distance / EarthRadius) * Math.Cos(lat1), Math.Cos(distance / EarthRadius) - Math.Sin(lat1) * Math.Sin(lat2));

            return new GPS<double>(lat2 * DEGREES, lon2 * DEGREES);
        }

        public GPS<double> RecountGPS(double latitude, double longitude, double rangeX, double rangeY, double bearing)
        {
            var angle = ConvertAngleFromCompass(bearing) * RADIANS;
            var _X = rangeX * Math.Cos(angle) - rangeY * Math.Sin(angle);
            var _Y = rangeX * Math.Sin(angle) + rangeY * Math.Cos(angle);

            var new_latitude = latitude + (_Y / EarthRadius) * DEGREES; // x
            var new_longitude = longitude + (_X / EarthRadius) * DEGREES / Math.Cos(latitude * RADIANS); //y

            return new GPS<double>(new_latitude, new_longitude);
        }

        private double ConvertAngleFromCompass(double directionAngle)
        {
            return 360 - (directionAngle - 90);
        }

        private static double RotateX(double x, double y, double angle)
        {
            angle *= RADIANS;
            return x * Math.Cos(angle) - y * Math.Sin(angle); 
        }

        private static double RotateY(double x, double y, double angle)
        {
            angle *= RADIANS;
            return x * Math.Sin(angle) + y * Math.Cos(angle);
        }
    }
}

