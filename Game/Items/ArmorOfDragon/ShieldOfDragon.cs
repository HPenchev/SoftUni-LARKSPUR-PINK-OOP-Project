﻿namespace Game.Items.ArmorOfDragon
{
    using Core;
    using Core.Data.Enums;

    public class ShieldOfDragon : Armor 
    {
        public ShieldOfDragon(string id)
            : base(id)
        {
            this.Id = "Shield forged by fire-breathing dragon.";
            this.AttackPoints = 0;
            this.AttackSpeed = -4;
            this.ChanceToDodge = 23;
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
