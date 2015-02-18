namespace Game.Exceptions.ItemException
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ValueIsNegativeException : ItemException
    {
        /// <summary>
        /// If object's value is negative exception is thrown.  
        /// </summary>
        public ValueIsNegativeException() : base()
        {
        }

        public ValueIsNegativeException(string message) : base(message)
        {
        }

        public ValueIsNegativeException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public ValueIsNegativeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValueIsNegativeException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
        {
        }

        protected ValueIsNegativeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}