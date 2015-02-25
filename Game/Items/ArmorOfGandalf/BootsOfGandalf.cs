using System;

namespace Game.Items.ArmorOfGandalf
{
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class BootsOfGandalf : Armor
    {
        public BootsOfGandalf(string id)
            : base(id)
        {
            this.Id = "The Boots of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.25;
            this.ChanceToDodge = 5;
            this.CriticalChance = 2;
            this.CriticalDamage = 20;
            this.DefensePoints = 100;
            this.HealthPoints = 200;
            this.Level = 4;
            this.Price = 130;
            this.Size = 2;
            this.ArmorType = ArmorType.Boots;
        }
    }
}