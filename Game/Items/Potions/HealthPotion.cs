using System.Runtime.CompilerServices;
using Game.Exceptions.ItemException;

namespace Game.Items.Potions
{
    using Core;
    public class HealthPotion : Potion
    {
        public HealthPotion(string id)
            : base(id)
        {
        }
    }
}
