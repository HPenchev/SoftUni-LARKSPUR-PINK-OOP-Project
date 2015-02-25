namespace Game.Items.ArmorOfDragon
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class ChestArmorOfDragon : Armor
    {
        public ChestArmorOfDragon(string id)
            : base(id)
        {
            this.Id = "Armor forged with the breath of fire-breathing dragon";
            this.AttackPoints = 0;
            this.AttackSpeed = -0.05;
            this.ChanceToDodge = 8;
            this.CriticalChance = 3;
            this.CriticalDamage = 0;
            this.DefensePoints = 250;
            this.HealthPoints = 200;
            this.Level = 7;
            this.Price = 250;
            this.Size = 3;
            this.ArmorType = ArmorType.ChestArmor;
        }
    }
}
