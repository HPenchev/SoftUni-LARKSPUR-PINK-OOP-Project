namespace Game.Items.ArmorOfGandalf
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class GlovesOfGandalf : Armor
    {
        public GlovesOfGandalf(string id)
            : base(id)
        {
            this.Id = "Gloves Of Gandalf";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.2;
            this.ChanceToDodge = 0;
            this.CriticalChance = 2;
            this.CriticalDamage = 10;
            this.DefensePoints = 50;
            this.HealthPoints = 75;
            this.Level = 1;
            this.Price = 50;
            this.Size = 1;
            this.ArmorType = ArmorType.Gloves;
        }
    }
}