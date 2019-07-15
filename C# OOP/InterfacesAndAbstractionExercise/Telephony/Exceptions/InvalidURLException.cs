using System;

namespace Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string excMessage = "Invalid URL!";
        public InvalidURLException()
            :base(excMessage)
        {

        }

        public InvalidURLException(string message)
            :base(message)
        {
        }
    }
}
