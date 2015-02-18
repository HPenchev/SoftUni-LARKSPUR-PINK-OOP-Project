namespace Game.Core
{
    public abstract class GameObject
    {
        private string id;
        protected GameObject(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get { return this.id; }

            set { this.id = value; }
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}