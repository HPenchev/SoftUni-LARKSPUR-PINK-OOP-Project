namespace Game.Enemies
{
    using Core;
    using Interfaces;

    public class Minion : Enemy
    {
        public Minion(string id)
            : base(id)
        {
        }

        public override ICharacter FindTarget(ICharacter player)
        {
            throw new System.NotImplementedException();
        }

        public override void Attack(ICharacter player)
        {
            throw new System.NotImplementedException();
        }

        public override void DropReward()
        {
        }
    }
}