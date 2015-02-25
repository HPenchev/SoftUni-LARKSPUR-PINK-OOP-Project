using System;

namespace Game.Items.ArmorOfDarkness
{
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class ShieldOfDarkness : Armor
    {
        public ShieldOfDarkness(string id)
            : base(id)
        {
            this.Id = "Shield enveloped by darkness found in dragon's dungeons.";
            this.AttackPoints = 0;
            this.AttackSpeed = -0.25;
            this.ChanceToDodge = 25;
            this.CriticalChance = 0;
            this.CriticalDamage = 0;
            this.DefensePoints = 400;
            this.HealthPoints = 0;
            this.Level = 9;
            this.Price = 400;
            this.Size = 3;
            this.ArmorType = ArmorType.Shield;
        }
    }
}
