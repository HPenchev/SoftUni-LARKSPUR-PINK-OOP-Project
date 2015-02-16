namespace Game.Exceptions
{
    using System;
    public class WeaponNotSupportedException : Exception
    {
        public WeaponNotSupportedException(string message)
            : base(message) { }
    }
}