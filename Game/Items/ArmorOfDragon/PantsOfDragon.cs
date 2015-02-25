namespace Game.Items.ArmorOfDragon
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class PantsOfDragon : Armor
    {
        public PantsOfDragon(string id)
            : base(id)
        {
            this.Id = "Pants forged with the breath of fire-breathing dragon";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.2;
            this.ChanceToDodge = 2;
            this.CriticalChance = 4;
            this.CriticalDamage = 15;
            this.DefensePoints = 150;
            this.HealthPoints = 225;
            this.Level = 5;
            this.Price = 150;
            this.Size = 3;
            this.ArmorType = ArmorType.Pants;
        }
    }
}
