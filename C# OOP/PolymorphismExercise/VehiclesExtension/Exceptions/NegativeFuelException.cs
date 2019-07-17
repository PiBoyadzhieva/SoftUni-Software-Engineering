using System;

namespace VehiclesExtension.Exceptions
{
    public class NegativeFuelException : Exception
    {
        private const string ExceptionMessage = "Fuel must be a positive number";

        public NegativeFuelException()
            : base(ExceptionMessage)
        {
        }

        public NegativeFuelException(string message) 
            : base(message)
        {
        }
    }
}
