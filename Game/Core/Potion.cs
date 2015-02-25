namespace Game.Core
{
    using System;
    using Exceptions.ItemException;

    [Serializable]
    public abstract class Potion : Item
    {
        private double mana;

        protected Potion(string id)
            : base(id)
        {
            this.Size = 1;
            this.Price = 100;
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
                    throw new ValueIsNegativeException("Mama in Mana potion can not be negative");
                }

                this.mana = value;
            }
        }
    }
}
