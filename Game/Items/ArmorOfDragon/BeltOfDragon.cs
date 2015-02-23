namespace Game.Items.ArmorOfDragon
{
    using Core;
    using Core.Data.Enums;

    public class BeltOfDragon : Armor
    {
        public BeltOfDragon(string id)
            : base(id)
        {
            this.Id = "Belt forged by fire-breathing dragon.";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.05;
            this.ChanceToDodge = 0;
            this.CriticalChance = 5;
            this.CriticalDamage = 15;
            this.DefensePoints = 30;
            this.HealthPoints = 80;
            this.Level = 3;
            this.Price = 100;
            this.Size = 1;
            this.ArmorType = ArmorType.Belt;
        }
    }
}
