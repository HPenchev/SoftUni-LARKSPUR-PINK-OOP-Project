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
       
        public override void Attack(ICharacter player)
        {
            throw new NotImplementedException();
        }

        public override void DropReward()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
