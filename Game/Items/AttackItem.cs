namespace Game.Items
{
    using System;
    using Interfaces;

    protected abstract class AttackItem : IBuyable, IPickable, IRewardable, ISellable
    {
        private const int attack = 100;

        public AttackItem(int attack)
        {
            this.Attack = attack;
        }

        public int Attack
        {
            get
            {
                return attack; 
            }
            set
            {
                this.Attack = value;            
            }
        }
    
    }
}
