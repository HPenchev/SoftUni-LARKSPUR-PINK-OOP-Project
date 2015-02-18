using System;

namespace Game.Exceptions
{
    public class ItemNotInStashException : Exception
    {
        public ItemNotInStashException(string message)
        : base(message) { }
    }
}