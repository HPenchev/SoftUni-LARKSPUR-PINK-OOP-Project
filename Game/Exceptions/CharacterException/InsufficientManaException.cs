namespace Game.Exceptions.CharacterException
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InsufficientManaException : GameException
    {
        /// <summary>
        /// Main Character Exception Class
        /// </summary>
        public InsufficientManaException()
            : base()
        {
        }

        public InsufficientManaException(string message)
            : base(message)
        {
        }

        public InsufficientManaException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public InsufficientManaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InsufficientManaException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected InsufficientManaException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}