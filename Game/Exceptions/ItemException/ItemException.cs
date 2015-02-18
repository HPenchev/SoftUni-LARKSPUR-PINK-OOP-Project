namespace Game.Exceptions.ItemException
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ItemException : GameException
    {
        /// <summary>
        /// Main Item Exception Class
        /// </summary>
        public ItemException() : base()
        {
        }

        public ItemException(string message) : base(message)
        {
        }

        public ItemException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public ItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ItemException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected ItemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}