using System;

namespace Logger.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string ExcMessage = "Invalid Level Type!";
        public InvalidLevelTypeException()
            : base(ExcMessage)
        {

        }

        public InvalidLevelTypeException(string message) 
            : base(message)
        {

        }
    }
}
