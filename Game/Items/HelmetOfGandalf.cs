namespace Game.Items
{
    using Core;
    using Core.Data.Enums;

    public class HelmetOfGandalf : Armor
    {
        public HelmetOfGandalf(string id) : base(id)
        {
            this.Id = "The Helmet of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 0;
            this.ChanceToDodge = 3;
            this.CriticalChance = 4;
            this.CriticalDamage = 10;
            this.DefensePoints = 100;
            this.HealthPoints = 150;
            this.Level = 6;
            this.Price = 100;
            this.Size = 2;
            this.ArmorType = ArmorType.Helmet;
        }
    }
}