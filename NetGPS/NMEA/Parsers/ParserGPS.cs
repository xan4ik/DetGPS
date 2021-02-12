using System.Text;

namespace NMEA
{
    public class ParserGPS 
    {
        private StringBuilder builder;

        public ParserGPS()
        {
            builder = new StringBuilder();
        }

        public double TryParseLatitude(string latitude) 
        {
            return GetCoordinate(latitude, 2);           
        }
        
        public double TryParseLongitude(string longitude) 
        {
            return GetCoordinate(longitude, 3);
        }

        private double GetCoordinate(string coordinate, int dotPosition)
        {
            builder.Clear();
            builder.Append(coordinate);
            builder.Replace(".", "");
            builder.Insert(dotPosition, ",");
            return double.Parse(builder.ToString());
        }

        public double ConvertDouble(string value) 
        {
            builder.Clear();
            builder.Append(value);
            builder.Replace('.', ',');
            return double.Parse(builder.ToString());
        }

    }
}
