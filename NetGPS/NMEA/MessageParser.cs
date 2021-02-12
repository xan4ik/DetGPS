using System;

namespace NMEA
{
     public abstract class MessageParser 
    {
        private string messageType;

        protected MessageParser(string messageType)
        {
            this.messageType = messageType;
        }

        public string MessageType 
        {
            get 
            {
                return messageType;
            }
        }

        public bool CanParse(string messageType) 
        {
            return this.messageType == messageType;
        }

        public T TryParseMessage<T>(string[] splitMessage)
            where T: class
        {
            try
            {
                if (!CanParse(splitMessage[0]))
                {
                    throw new ArgumentException("Can't parse message of type: " + splitMessage[0]);
                }
                return (T)GetParseResult(splitMessage);
            }
            catch (Exception exc) 
            {
                throw new InnerParseException("Uncathced parse exception, check GetParseResult method", exc);
            }
        }

        protected abstract object GetParseResult(string[] splitMessage);
    }
}
