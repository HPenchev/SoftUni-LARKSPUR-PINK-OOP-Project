namespace Game.Static
{
    using Core;
    using Game.Interfaces;

    public class ManaStatic : GameObject, IStatic
    {
        private double mana;
        private bool isUsed;

        public ManaStatic(string id) : base(id)
        {
            this.Mana = 100;
        }

        public double Mana
        {
            get { return this.mana; }
            set { this.mana = value; }
        }

        public bool IsUsed
        {
            get { return this.isUsed; }
            set { this.isUsed = value; }
        }
    }
}