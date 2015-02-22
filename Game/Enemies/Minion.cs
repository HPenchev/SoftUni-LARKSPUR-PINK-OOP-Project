namespace Game.Enemies
{
    using Core;
    using Interfaces;

    public class Minion : Enemy
    {
        #region Constructors
        public Minion(string id)
            : base(id)
        {
        }
        #endregion

        #region Methods

        public override void Attack(ICharacter player)
        {
            throw new System.NotImplementedException();
        }

        public override void DropReward()
        {
        }
        #endregion
    }
}