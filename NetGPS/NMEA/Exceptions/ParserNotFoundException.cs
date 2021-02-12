using System;

namespace NMEA
{
    public class ParserNotFoundException : Exception
    {
        public ParserNotFoundException(string messageType) : base("Can't parse message with type: " + messageType)
        { }
    }

}
