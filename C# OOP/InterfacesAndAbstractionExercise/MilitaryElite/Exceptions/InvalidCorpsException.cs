using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string ExcMessage = "Invalid corps!";
        public InvalidCorpsException()
            : base(ExcMessage)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}
