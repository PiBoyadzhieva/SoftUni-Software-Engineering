using System;

namespace Logger.Exceptions
{
    class InvalidAppenderTypeException : Exception
    {
        private const string ExcMessage = "Invalid Appender Type!";
        public InvalidAppenderTypeException()
            : base(ExcMessage)
        {

        }

        public InvalidAppenderTypeException(string message) 
            : base(message)
        {

        }
    }
}
