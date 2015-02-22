namespace Game.Items.Potions
{
    using Core;
    using Exceptions.ItemException;
    public class ManaPotion : Potion
    {
        private double mana;
        public ManaPotion(string id)
            : base(id)
        {
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
