using System;
using System.Linq;

using Telephony.Exceptions;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public Smartphone()
        {

        }
        public string Browse(string url)
        {
            if(url.Any(c => char.IsDigit(c)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if(!phoneNumber.All(c => Char.IsDigit(c)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
