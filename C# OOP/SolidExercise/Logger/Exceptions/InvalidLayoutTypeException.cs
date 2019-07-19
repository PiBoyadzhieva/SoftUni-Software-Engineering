using System;

namespace Logger.Exceptions
{
    public class InvalidLayoutTypeException : Exception
    {
        private const string ExcMessage = "Invalid Layout Type!";
        public InvalidLayoutTypeException()
            : base(ExcMessage)
        {

        }

        public InvalidLayoutTypeException(string message) 
            : base(message)
        {

        }
    }
}
