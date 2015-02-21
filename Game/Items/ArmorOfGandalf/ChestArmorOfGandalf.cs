namespace Game.Items.ArmorOfGandalf
{
    using Core;
    using Core.Data.Enums;

    public class ChestArmorOfGandalf : Armor
    {
        public ChestArmorOfGandalf(string id)
            : base(id)
        {
            this.Id = "The Armor of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 2;
            this.ChanceToDodge = 10;
            this.CriticalChance = 0;
            this.CriticalDamage = 0;
            this.DefensePoints = 200;
            this.HealthPoints = 300;
            this.Level = 7;
            this.Price = 250;
            this.Size = 3;
            this.ArmorType = ArmorType.ChestArmor;
        }
    }
}