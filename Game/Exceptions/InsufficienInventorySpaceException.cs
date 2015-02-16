namespace Game.Exceptions
{
    using System;
    public class InsufficienInventorySpaceException : Exception
    {
        public InsufficienInventorySpaceException(string message)
            : base(message) { }
    }
}