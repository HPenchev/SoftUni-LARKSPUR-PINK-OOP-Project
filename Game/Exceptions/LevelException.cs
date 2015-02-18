using System;

namespace Game.Exceptions
{
    public class LevelException : Exception
    {
        public LevelException(string message)
            : base(message) { }
    }
}