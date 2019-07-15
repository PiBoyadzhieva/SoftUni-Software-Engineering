using System;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string excMessage = "Invalid number!";
        public InvalidPhoneNumberException()
            :base(excMessage)
        {

        }

        public InvalidPhoneNumberException(string message) 
            : base(message)
        {

        }
    }
}
