﻿namespace Game.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Core;
    using Core.Data.Enums;
    using Characters;
    using Interfaces;
    public class ArmorOfGandalf : Armor
    {
        public ArmorOfGandalf(string id)
            : base(id)
        {

            this.Id = "The Armor of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 2;
            this.ChanceToDodge = 10;
            this.CriticalChance = 0;
            this.CriticalDamage = 0;
            this.DefensePoints = 200;
            this.HealthPoints = 300;
            this.Level = 7;
            this.Price = 250;
            this.Size = 3;
            this.ArmorType = ArmorType.ChestArmor;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
