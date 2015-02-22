namespace Game.Core
{
    using System.Collections.Generic;
    using Interfaces;

    public abstract class Enemy : Character, IEnemy
    {
        private decimal gold;
      
        protected Enemy(string id)
            : base(id)
        {
        }

        public decimal Gold
        {
            get { return this.gold; }
            set { this.gold = value; }
        }

    

        public abstract ICharacter FindTarget(ICharacter player);

        public abstract void Attack(ICharacter player);

        public abstract void DropReward();
    }
}