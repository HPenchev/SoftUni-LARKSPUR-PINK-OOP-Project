namespace Game.Core
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class Enemy : Character, IEnemy
    {
        private decimal gold;
        private List<Item> inventory = new List<Item>();

        protected Enemy(string id)
            : base(id)
        {
        }

        public decimal Gold
        {
            get { return this.gold; }
            set { this.gold = value; }
        }

        public List<Item> Inventory
        {
            get { return this.inventory; }
            set { this.inventory = value; }
        }

        public abstract ICharacter FindTarget(ICharacter player);

        public abstract void Attack(ICharacter player);

        public abstract void DropReward();
    }
}