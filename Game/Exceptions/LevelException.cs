namespace Game.Exceptions
{
    using System;
    public class LevelException : Exception
    {
        public LevelException(string message)
            : base(message) { }
    }
}