using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string ExcMessage = "You cannot finish already completed mission!";
        public InvalidMissionCompletionException()
            :base(ExcMessage)
        {
        }

        public InvalidMissionCompletionException(string message) 
            : base(message)
        {

        }
    }
}
