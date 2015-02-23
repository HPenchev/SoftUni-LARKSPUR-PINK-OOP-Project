namespace Game.Core
{
    using Game.Core.RandomGenerator;
    using Interfaces;    

    public abstract class Enemy : Character, IEnemy
    {
        #region Fileds
        private decimal gold;
        #endregion

        #region Constructors
        protected Enemy(string id)
            : base(id)
        {
        }
        #endregion

        #region Properties
        public decimal Gold
        {
            get { return this.gold; }
            set { this.gold = value; }
        }
        #endregion

        #region Methods
        
        public override void Attack(ICharacter player)
        {
            base.Attack(player);
        }

        protected override double CalculateDamage(ICharacter target)
        {
            Player player = (Player)target;
            double dodgeChance = player.ChanceToDodge;
            double damage = base.CalculateDamage(player);
            int chenceToDoge = RandomGenerator.RandomGenerator.rnd.Next(100);
            if (chenceToDoge < player.ChanceToDodge)
            {
                damage = 0;
            }

            return damage;
        }

        public abstract void DropReward();
        #endregion
    }
}