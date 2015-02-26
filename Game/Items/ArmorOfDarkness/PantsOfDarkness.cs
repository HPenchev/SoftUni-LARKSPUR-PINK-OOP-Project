namespace Game.Items.ArmorOfDarkness
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class PantsOfDarkness : Armor
    {
        public PantsOfDarkness(string id)
            : base(id)
        {
            this.Id = "Pants Of Darkness";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.05;
            this.ChanceToDodge = 5;
            this.CriticalChance = 3;
            this.CriticalDamage = 20;
            this.DefensePoints = 125;
            this.HealthPoints = 250;
            this.Level = 5;
            this.Price = 200;
            this.Size = 3;
            this.ArmorType = ArmorType.Pants;
        }
    }
}
