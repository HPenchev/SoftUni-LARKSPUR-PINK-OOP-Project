using System;

namespace Game.Exceptions
{
    public class WeaponNotSupportedException : Exception
    {
        public WeaponNotSupportedException(string message)
            : base(message) { }
    }
}