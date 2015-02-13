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
    public class ArmorOfGandalf : Armor
    {
        public ArmorOfGandalf(string id) : base(id)
        {

            this.Id = "The Armor of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 2;
            this.ChanceToDodge = 2;
            this.CriticalChance = 1;
            this.CriticalDamage = 10;
            this.DefencePoints = 50;
            this.HealthPoints = 100;
            this.Level = 2;
            this.Price = 200;
            this.Size = 3;
            this.ArmorType = ArmorType.ChestArmor;
        }
    }
}
