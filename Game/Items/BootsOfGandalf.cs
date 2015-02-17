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
    public class BootsOfGandalf : Armor
    {
        public BootsOfGandalf(string id)
            : base(id)
        {

            this.Id = "The Boots of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 5;
            this.ChanceToDodge = 5;
            this.CriticalChance = 5;
            this.CriticalDamage = 25;
            this.DefensePoints = 100;
            this.HealthPoints = 200;
            this.Level = 4;
            this.Price = 130;
            this.Size = 2;
            this.ArmorType = ArmorType.Boots;
        }
    }
}
