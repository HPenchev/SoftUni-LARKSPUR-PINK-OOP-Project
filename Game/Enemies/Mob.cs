namespace Game.Enemies
{
    using Core;
    using Interfaces;

    public class Mob : Enemy
    {
        #region Constructors
        public Mob(string id)
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
