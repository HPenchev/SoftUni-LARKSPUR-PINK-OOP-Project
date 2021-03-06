﻿namespace Game.Items.ArmorOfGandalf
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class BeltOfGandalf : Armor
    {
        public BeltOfGandalf(string id)
            : base(id)
        {
            this.Id = "Belt Of Gandalf";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.1;
            this.ChanceToDodge = 1;
            this.CriticalChance = 3;
            this.CriticalDamage = 20;
            this.DefensePoints = 50;
            this.HealthPoints = 100;
            this.Level = 3;
            this.Price = 75;
            this.Size = 1;
            this.ArmorType = ArmorType.Belt;
        }
    }
}