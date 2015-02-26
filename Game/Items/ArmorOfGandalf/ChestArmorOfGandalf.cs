namespace Game.Items.ArmorOfGandalf
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class ChestArmorOfGandalf : Armor
    {
        public ChestArmorOfGandalf(string id)
            : base(id)
        {
            this.Id = "Chest Armor Of Gandalf";
            this.AttackPoints = 0;
            this.AttackSpeed = -0.1;
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
    }
}