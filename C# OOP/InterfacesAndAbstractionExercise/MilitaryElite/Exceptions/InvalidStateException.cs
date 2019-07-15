using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string excMessage = "Invalid mission state!";
        public InvalidStateException()
            :base(excMessage)
        {

        }

        public InvalidStateException(string message) 
            : base(message)
        {

        }
    }
}
