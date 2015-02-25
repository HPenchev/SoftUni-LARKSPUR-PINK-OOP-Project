namespace Game.Items.ArmorOfDarkness
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class GlovesOfDarkness : Armor
    {
        public GlovesOfDarkness(string id)
            : base(id)
        {
            this.Id = "Gloves covered in darkness found in dragon's dungeons";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.1;
            this.ChanceToDodge = 0;
            this.CriticalChance = 2;
            this.CriticalDamage = 20;
            this.DefensePoints = 50;
            this.HealthPoints = 100;
            this.Level = 1;
            this.Price = 75;
            this.Size = 1;
            this.ArmorType = ArmorType.Gloves;
        }
    }
}
