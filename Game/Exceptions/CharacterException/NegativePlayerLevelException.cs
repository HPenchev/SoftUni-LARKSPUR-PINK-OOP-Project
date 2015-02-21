namespace Game.Exceptions.CharacterException
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NegativePlayerLevelException : GameException
    {
        /// <summary>
        /// When the Player's level is negative this Exception is thrown.
        /// </summary>
        public NegativePlayerLevelException()
            : base()
        {
        }

        public NegativePlayerLevelException(string message)
            : base(message)
        {
        }

        public NegativePlayerLevelException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public NegativePlayerLevelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NegativePlayerLevelException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected NegativePlayerLevelException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}