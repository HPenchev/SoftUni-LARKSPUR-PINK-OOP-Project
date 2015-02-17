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
    public class PantsOfGandalf : Armor
    {
        public PantsOfGandalf(string id)
            : base(id)
        {

            this.Id = "The Pants of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 2;
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
