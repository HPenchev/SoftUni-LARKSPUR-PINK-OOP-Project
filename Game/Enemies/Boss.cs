namespace Game.Enemies
{
    using System;
    using Core;
    using Interfaces;

    public class Boss : Enemy
    {
        public Boss(string id)
            : base(id)
        {
        }

        public override ICharacter FindTarget(ICharacter player)
        {
            throw new NotImplementedException();
        }

        public override void Attack(ICharacter player)
        {
            throw new NotImplementedException();
        }

        public override void DropReward()
        {
            throw new NotImplementedException();
        }
    }
}
