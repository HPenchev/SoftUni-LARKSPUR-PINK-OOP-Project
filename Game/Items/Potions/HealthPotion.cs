using System;

namespace Game.Items.Potions
{
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
