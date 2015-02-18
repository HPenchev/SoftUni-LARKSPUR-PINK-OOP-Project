namespace Game.Items
{
    using Core;
    using Core.Data.Enums;

    public class ShieldOfGandalf : Armor
    {
        public ShieldOfGandalf(string id) : base(id)
        {
            this.Id = "The Shield of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 2;
            this.ChanceToDodge = 15;
            this.CriticalChance = 0;
            this.CriticalDamage = 0;
            this.DefensePoints = 300;
            this.HealthPoints = 0;
            this.Level = 9;
            this.Price = 275;
            this.Size = 3;
            this.ArmorType = ArmorType.Shield;
        }
    }
}