namespace Game.Exceptions
{
    using System;
    public class InsufficientGoldException : Exception
    {
        public InsufficientGoldException(string message)
            : base(message) { }
    }
}