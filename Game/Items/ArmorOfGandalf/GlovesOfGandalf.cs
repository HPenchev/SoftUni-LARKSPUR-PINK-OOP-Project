namespace Game.Items.ArmorOfGandalf
{
    using Core;
    using Core.Data.Enums;

    public class GlovesOfGandalf : Armor
    {
        public GlovesOfGandalf(string id)
            : base(id)
        {
            this.Id = "The Gloves of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 4;
            this.ChanceToDodge = 0;
            this.CriticalChance = 2;
            this.CriticalDamage = 10;
            this.DefensePoints = 50;
            this.HealthPoints = 75;
            this.Level = 1;
            this.Price = 50;
            this.Size = 1;
            this.ArmorType = ArmorType.Gloves;
        }
    }
}