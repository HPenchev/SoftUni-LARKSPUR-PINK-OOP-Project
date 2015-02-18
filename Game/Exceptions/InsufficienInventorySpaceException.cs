using System;

namespace Game.Exceptions
{
    public class InsufficienInventorySpaceException : Exception
    {
        public InsufficienInventorySpaceException(string message)
            : base(message) { }
    }
}