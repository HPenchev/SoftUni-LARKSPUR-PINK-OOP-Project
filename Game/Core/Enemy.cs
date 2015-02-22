namespace Game.Core
{
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
        
        public abstract void Attack(ICharacter player);

        public abstract void DropReward();
        #endregion
    }
}