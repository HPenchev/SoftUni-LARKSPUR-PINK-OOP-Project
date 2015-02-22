namespace Game.Static
{
    using Core;
    using Interfaces;

    public class HealthWell : GameObject, IStatic
    {
        private double health;
        private bool isUsed;

        public HealthWell(string id)
            : base(id)
        {
            this.Health = 100;
        }

        public double Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        public bool IsUsed
        {
            get { return this.isUsed; }
            set { this.isUsed = value; }
        }
    }
}