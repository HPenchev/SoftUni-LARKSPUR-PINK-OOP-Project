namespace Game.Items
{
    using System;
    using Interfaces;

    protected abstract class DefenceItem : IBuyable, IPickable, IRewardable, ISellable
    {
        private const int defence = 100;

        public DefenceItem(int defence)
        {
            this.Defence = defence;
        }

        public int Defence
        {
            get
            {
                return defence;
            }
            set
            {
                this.Defence = value;
            }
        }
    }
}