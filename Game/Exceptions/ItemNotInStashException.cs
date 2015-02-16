namespace Game.Exceptions
{
    using System;
    public class ItemNotInStashException : Exception
    {
        public ItemNotInStashException(string message)
        : base(message) { }
    }
}