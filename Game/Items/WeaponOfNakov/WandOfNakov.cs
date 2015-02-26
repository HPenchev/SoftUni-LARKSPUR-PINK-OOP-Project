﻿namespace Game.Items.WeaponOfNakov
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class WandOfNakov : Weapon
    {
        public WandOfNakov(string id)
            : base(id)
        {
            this.Id = "Wand Of Nakov";
            this.AttackPoints = 100;
            this.AttackSpeed = 0.1;
            this.ChanceToDodge = 0;
            this.CriticalChance = 1;
            this.CriticalDamage = 10;
            this.HealthPoints = 0;
            this.Level = 1;
            this.Price = 100;
            this.Size = 3;
            this.WeaponType = WeaponType.Wand;
        }
    }
}