namespace Game.Enemies
{
    using System;
    using Core;
    using Interfaces;

    public class Boss : Enemy
    {
        #region Constructors
        public Boss(string id)
            : base(id)
        {
        }
        #endregion

        #region Methods

        public override double CalculateDamage(ICharacter target)
        {
            double damage = this.AttackPoints;
            if (target.DefensePoints < damage)
            {
                damage = 80;
            }
            return damage;
        }

        public override void DropReward()
        {
        }
        #endregion
    }
}
