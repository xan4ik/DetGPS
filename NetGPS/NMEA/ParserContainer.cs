using System;
using System.Collections.Generic;

namespace NMEA
{
    public class ParserContainer 
    {
        private List<MessageParser> parsers;

        public ParserContainer(params MessageParser[] parsers) 
        {
            this.parsers = new List<MessageParser>();
            foreach (var item in parsers)
            {
                this.parsers.Add(item);
            }
        }

        public void AddParser(MessageParser parser) 
        {
            if (!parsers.Contains(parser))
            {
                parsers.Add(parser);
            }
            else throw new ArgumentException("Parser had been added");
        }

        public void RemoveParser(MessageParser parser) 
        {
            if (parsers.Contains(parser))
            {
                parsers.Remove(parser);
            }
            else throw new ArgumentException("Parser hadn't been added");
        }

        public T ConvertMessage<T>(string message)
            where T : class
        {
            if (!IsParsersExist())
                throw new IndexOutOfRangeException("Didn't add parsers");

            var parts = GetSplitMessage(message);
            var parser = TryFindMessageParserFor(parts[0]);  //parts[0] - $******* - message type
            return parser.TryParseMessage<T>(parts);
        }

        private bool IsParsersExist()
        {
            return parsers.Count != 0;
        }

        private MessageParser TryFindMessageParserFor(string messageType)
        {
            foreach (var parser in parsers)
            {
                if (parser.CanParse(messageType)) 
                {
                    return parser;
                }
            }
            
            throw new ParserNotFoundException(messageType);
        }

        private string[] GetSplitMessage(string sourse) 
        {
            return sourse.Split(',');        
        }
    }
}
