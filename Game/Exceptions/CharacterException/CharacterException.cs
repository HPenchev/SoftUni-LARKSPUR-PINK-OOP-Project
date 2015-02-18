namespace Game.Exceptions.CharacterException
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class CharacterException : GameException
    {
        /// <summary>
        /// Main Character Exception Class
        /// </summary>
        public CharacterException()
            : base()
        {
        }

        public CharacterException(string message)
            : base(message)
        {
        }

        public CharacterException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public CharacterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CharacterException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected CharacterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}