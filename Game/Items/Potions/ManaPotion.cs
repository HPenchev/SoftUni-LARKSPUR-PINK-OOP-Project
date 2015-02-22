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
            this.Mana = mana;
        }
    }
}
