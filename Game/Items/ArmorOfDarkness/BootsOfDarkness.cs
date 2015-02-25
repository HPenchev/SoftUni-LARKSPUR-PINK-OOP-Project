namespace Game.Items.ArmorOfDarkness
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class BootsOfDarkness : Armor
    {
        public BootsOfDarkness(string id)
            : base(id)
        {
            this.Id = "Boots covered by darkness found dragon's dungeons";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.10;
            this.ChanceToDodge = 12;
            this.CriticalChance = 3;
            this.CriticalDamage = 30;
            this.DefensePoints = 175;
            this.HealthPoints = 225;
            this.Level = 4;
            this.Price = 225;
            this.Size = 2;
            this.ArmorType = ArmorType.Boots;
        }
    }
}
