namespace Game.Items
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
    public class GlovesOfGandalf : Armor
    {
        public GlovesOfGandalf(string id)
            : base(id)
        {

            this.Id = "The Gloves of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 1;
            this.ChanceToDodge = 0;
            this.CriticalChance = 2;
            this.CriticalDamage = 10;
            this.DefensePoints = 30;
            this.HealthPoints = 50;
            this.Level = 1;
            this.Price = 50;
            this.Size = 1;
            this.ArmorType = ArmorType.Gloves;
        }
    }
}
