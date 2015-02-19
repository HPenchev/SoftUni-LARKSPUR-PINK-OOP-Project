namespace Game.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class IdIsNullOrEmptyException : GameException
    {
        /// <summary>
        /// If an object ID is null or empty an exception is thrown.
        /// </summary>
        public IdIsNullOrEmptyException() : base()
        {
        }

        public IdIsNullOrEmptyException(string message) : base(message)
        {
        }

        public IdIsNullOrEmptyException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public IdIsNullOrEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public IdIsNullOrEmptyException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected IdIsNullOrEmptyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}