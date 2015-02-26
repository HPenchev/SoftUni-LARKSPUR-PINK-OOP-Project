namespace Game.Items.ArmorOfDarkness
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class ChestArmorOfDarkness : Armor
    {
        public ChestArmorOfDarkness(string id)
            : base(id)
        {
            this.Id = "Chest Armor Of Darkness";
            this.AttackPoints = 0;
            this.AttackSpeed = -0.1;
            this.ChanceToDodge = 15;
            this.CriticalChance = 0;
            this.CriticalDamage = 0;
            this.DefensePoints = 250;
            this.HealthPoints = 300;
            this.Level = 7;
            this.Price = 300;
            this.Size = 3;
            this.ArmorType = ArmorType.ChestArmor;
        }
    }
}
