using System;

namespace Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string ExcMessage = "Invalid DateTime Format!";
        public InvalidDateFormatException()
            : base(ExcMessage)
        {

        }

        public InvalidDateFormatException(string message) 
            : base(message)
        {

        }
    }
}
