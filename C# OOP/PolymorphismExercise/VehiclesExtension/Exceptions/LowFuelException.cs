using System;

namespace VehiclesExtension.Exceptions
{
    public class LowFuelException : Exception
    {
        private const string ExceptionMessage = "{0} needs refueling";
        public LowFuelException()
            : base (ExceptionMessage)
        {
        }

        public LowFuelException(string message) 
            : base(message)
        {
        }
    }
}
