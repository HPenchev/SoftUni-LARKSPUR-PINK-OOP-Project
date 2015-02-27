namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using Data.Constants.EnemyConstants;
    using Interfaces;

    [Serializable]
    public abstract class Enemy : Character, IEnemy
    {
        #region Fileds
        private decimal gold;
        #endregion

        #region Constructors
        protected Enemy(string id)
            : base(id)
        {
            this.AttackPoints = EnemyConstants.EnemyStartingAttackPoints;
            this.Gold = EnemyConstants.EnemyStartingGold;
            this.HealthPoints = EnemyConstants.EnemyStartingHealthPoints;
            this.Inventory = new List<Item>();
            this.IsAlive = true;
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

        public override double CalculateDamage(ICharacter target)
        {
            double damage = this.AttackPoints;
            if (target.DefensePoints < damage)
            {
                damage = 99;
            }

            return damage;
        }

        public abstract void DropReward();
        #endregion
    }
}