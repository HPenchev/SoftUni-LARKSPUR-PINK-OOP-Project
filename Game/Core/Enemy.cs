using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Speech.Recognition;
using Game.Core.Data.Constants.EnemyConstants;

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

        public override void Attack(ICharacter player)
        {
            base.Attack(player);
        }
        
        public abstract void DropReward();
        #endregion
    }
}