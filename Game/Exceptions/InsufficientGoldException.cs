using System;

namespace Game.Exceptions
{
    public class InsufficientGoldException : Exception
    {
        public InsufficientGoldException(string message)
            : base(message) { }
    }
}