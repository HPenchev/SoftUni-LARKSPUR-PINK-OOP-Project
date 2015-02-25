using System;

namespace Game.Items.ArmorOfDragon
{
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class ShieldOfDragon : Armor 
    {
        public ShieldOfDragon(string id)
            : base(id)
        {
            this.Id = "Shield forged by fire-breathing dragon.";
            this.AttackPoints = 0;
            this.AttackSpeed = -0.2;
            this.ChanceToDodge = 20;
            this.CriticalChance = 0;
            this.CriticalDamage = 0;
            this.DefensePoints = 350;
            this.HealthPoints = 0;
            this.Level = 9;
            this.Price = 350;
            this.Size = 3;
            this.ArmorType = ArmorType.Shield;
        }
    }
}
