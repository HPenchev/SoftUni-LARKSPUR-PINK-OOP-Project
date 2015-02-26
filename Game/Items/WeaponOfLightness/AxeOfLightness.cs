﻿namespace Game.Items.WeaponOfLightness
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class AxeOfLightness : Weapon
    {
        public AxeOfLightness(string id)
            : base(id)
        {
            this.Id = "Axe Of Lightness";
            this.AttackPoints = 125;
            this.AttackSpeed = 0;
            this.ChanceToDodge = 0;
            this.CriticalChance = 3;
            this.CriticalDamage = 15;
            this.HealthPoints = 0;
            this.Level = 1;
            this.Price = 125;
            this.Size = 3;
            this.WeaponType = WeaponType.Axe;
        }
    }
}