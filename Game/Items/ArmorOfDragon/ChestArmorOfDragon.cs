namespace Game.Items.ArmorOfDragon
{
    using Core;
    using Core.Data.Enums;

    public class ChestArmorOfDragon : Armor
    {
        public ChestArmorOfDragon(string id)
            : base(id)
        {
            this.Id = "The Armor of fire-breathing dragon.";
            this.AttackPoints = 0;
            this.AttackSpeed = 1;
            this.ChanceToDodge = 8;
            this.CriticalChance = 3;
            this.CriticalDamage = 0;
            this.DefensePoints = 250;
            this.HealthPoints = 200;
            this.Level = 7;
            this.Price = 250;
            this.Size = 3;
            this.ArmorType = ArmorType.ChestArmor;
        }
    }
}
