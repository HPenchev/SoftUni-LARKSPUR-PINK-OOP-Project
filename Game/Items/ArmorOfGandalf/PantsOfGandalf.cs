﻿namespace Game.Items.ArmorOfGandalf
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class PantsOfGandalf : Armor
    {
        public PantsOfGandalf(string id)
            : base(id)
        {
            this.Id = "The Pants of Gandalf the great";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.05;
            this.ChanceToDodge = 7;
            this.CriticalChance = 1;
            this.CriticalDamage = 10;
            this.DefensePoints = 125;
            this.HealthPoints = 250;
            this.Level = 5;
            this.Price = 150;
            this.Size = 3;
            this.ArmorType = ArmorType.Pants;
        }
    }
}