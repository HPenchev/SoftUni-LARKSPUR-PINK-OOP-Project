using Game.Exceptions.ItemException;

namespace Game.Core
{
    public abstract class Potion : Item
    {
        private double mana;
        protected Potion(string id)
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
                    throw new ValueIsNegativeException("Mama in Mana potion can not be negative");
                }

                this.mana = value;
            }
        }
    }
}
