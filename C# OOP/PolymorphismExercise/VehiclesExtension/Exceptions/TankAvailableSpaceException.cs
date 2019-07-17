using System;

namespace VehiclesExtension.Exceptions
{
    public class TankAvailableSpaceException : Exception
    {
        private const string ExceptionMessage = "Cannot fit {0} fuel in the tank";
        public TankAvailableSpaceException()
            : base (ExceptionMessage)
        {

        }

        public TankAvailableSpaceException(string message) 
            : base(message)
        {

        }
    }
}
