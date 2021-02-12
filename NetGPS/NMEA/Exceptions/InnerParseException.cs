using System;

namespace NMEA
{
    public class InnerParseException : Exception
    {
        public InnerParseException(string message, Exception exception) : base(message, exception)
        { }
    }

}
