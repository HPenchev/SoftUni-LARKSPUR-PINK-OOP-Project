using Game.Interfaces;

namespace Game.Static
{
    using Core;

    public class HealthStatic : GameObject, IStatic
    {
        private double health;
        private bool isUsed;

        public HealthStatic(string id) : base(id)
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