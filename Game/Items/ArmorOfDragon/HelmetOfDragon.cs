namespace Game.Items.ArmorOfDragon
{
    using Core;
    using Core.Data.Enums;

    public class HelmetOfDragon : Armor
    {
        public HelmetOfDragon(string id)
            : base(id)
        {
            this.Id = "Helmet forged by fire-breathing dragon.";
            this.AttackPoints = 0;
            this.AttackSpeed = 1;
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
