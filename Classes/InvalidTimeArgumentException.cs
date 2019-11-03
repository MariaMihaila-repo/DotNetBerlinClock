using System;

namespace BerlinClock
{
    public class InvalidTimeArgumentException : Exception
    {
        public InvalidTimeArgumentException()
        {
        }
        public InvalidTimeArgumentException(string message)
            : base(message)
        {
        }

        public InvalidTimeArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
