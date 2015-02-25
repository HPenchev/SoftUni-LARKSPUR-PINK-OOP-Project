using System;

namespace Game.Items.ArmorOfDarkness
{
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class HelmetOfDarkness : Armor
    {
        public HelmetOfDarkness(string id)
            : base(id)
        {
            this.Id = "Helmet enveloped by darkness found in dragon's dungeons.";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.15;
            this.ChanceToDodge = 10;
            this.CriticalChance = 2;
            this.CriticalDamage = 20;
            this.DefensePoints = 100;
            this.HealthPoints = 150;
            this.Level = 6;
            this.Price = 125;
            this.Size = 2;
            this.ArmorType = ArmorType.Helmet;
        }
    }
}
