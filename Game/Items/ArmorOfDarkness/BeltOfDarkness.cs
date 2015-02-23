namespace Game.Items.ArmorOfDarkness
{
    using Core;
    using Core.Data.Enums;

    public class BeltOfDarkness : Armor
    {
        public BeltOfDarkness(string id)
            : base(id)
        {
            this.Id = "Belt enveloped by darkness found in dragon's dungeons.";
            this.AttackPoints = 0;
            this.AttackSpeed = 0.15;
            this.ChanceToDodge = 0;
            this.CriticalChance = 3;
            this.CriticalDamage = 25;
            this.DefensePoints = 10;
            this.HealthPoints = 40;
            this.Level = 3;
            this.Price = 100;
            this.Size = 1;
            this.ArmorType = ArmorType.Belt;
        }
    }
}
