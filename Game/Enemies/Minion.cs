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
        
        public override void DropReward()
        {
        }
        #endregion
    }
}