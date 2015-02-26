namespace Game.Items.ArmorOfDragon
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class HelmetOfDragon : Armor
    {
        public HelmetOfDragon(string id)
            : base(id)
        {
            this.Id = "Helmet Of Dragon";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.10;
            this.ChanceToDodge = 7;
            this.CriticalChance = 2;
            this.CriticalDamage = 15;
            this.DefensePoints = 120;
            this.HealthPoints = 150;
            this.Level = 6;
            this.Price = 100;
            this.Size = 2;
            this.ArmorType = ArmorType.Helmet;
        }
    }
}
