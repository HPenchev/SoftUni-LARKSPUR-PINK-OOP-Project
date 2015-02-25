using System;

namespace Game.Items.ArmorOfDragon
{
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class BootsOfDragon : Armor
    {
        public BootsOfDragon(string id)
            : base(id)
        {
            this.Id = "Boots forged by fire-breathing dragon.";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.15;
            this.ChanceToDodge = 8;
            this.CriticalChance = 4;
            this.CriticalDamage = 20;
            this.DefensePoints = 150;
            this.HealthPoints = 250;
            this.Level = 4;
            this.Price = 200;
            this.Size = 2;
            this.ArmorType = ArmorType.Boots;
        }
    }
}
