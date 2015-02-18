namespace Game.Core
{
    using System.Text;
    using Exceptions;

    public abstract class GameObject
    {
        #region Fields
        private string id;
        #endregion

        #region Constructors
        protected GameObject(string id)
        {
            this.Id = id;
        }
        #endregion

        #region Properties
        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value == null)
                {
                    throw new IdIsNullOrEmptyException("The Id can not be null.");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new IdIsNullOrEmptyException("The Id can not be empty.");
                }

                this.id = value;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Id = {0}\n", this.Id);
            return builder.ToString();
        }
        #endregion
    }
}