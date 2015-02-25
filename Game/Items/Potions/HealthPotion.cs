namespace Game.Items.Potions
{
    using System;
    using Core;

    [Serializable]
    public class HealthPotion : Potion
    {
        public HealthPotion(string id)
            : base(id)
        {
        }
    }
}
