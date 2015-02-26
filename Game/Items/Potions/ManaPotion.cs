namespace Game.Items.Potions
{
    using System;
    using Core;
    using Exceptions.ItemException;

    [Serializable]
    public class ManaPotion : Potion
    {
        private double mana;
        public ManaPotion(string id)
            : base(id)
        {
            this.Mana = 100;
        }

        public double Mana
        {
            get
            {
                return this.mana;
            }

            set
            {
                if (value < 0)
                {
                    throw new ValueIsNegativeException("Mana in the mana potion cannot be negative.");
                }
                this.mana = value;
            }
        }
    }
}
