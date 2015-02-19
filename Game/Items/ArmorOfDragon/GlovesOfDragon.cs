namespace Game.Items.ArmorOfDragon
{
    using Core;
    using Core.Data.Enums;

    public class GlovesOfDragon : Armor
    {
        public GlovesOfDragon(string id)
            : base(id)
        {
            this.Id = "Gloves forged by fire-breathing dragon.";
            this.AttackPoints = 0;
            this.AttackSpeed = 2;
            this.ChanceToDodge = 0;
            this.CriticalChance = 3;
            this.CriticalDamage = 15;
            this.DefensePoints = 30;
            this.HealthPoints = 50;
            this.Level = 1;
            this.Price = 50;
            this.Size = 1;
            this.ArmorType = ArmorType.Gloves;
        }
    }
}
