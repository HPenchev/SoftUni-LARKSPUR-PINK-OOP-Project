namespace Game.Items.WeaponOfNakov
{
    using Core;
    using Core.Data.Enums;

    public class BowOfNakov : Weapon
    {
        public BowOfNakov(string id) : base(id)
        {
            this.Id = "The Bow of Justice";
            this.AttackPoints = 100;
            this.AttackSpeed = 1;
            this.ChanceToDodge = 0;
            this.CriticalChance = 1;
            this.CriticalDamage = 1;
            this.HealthPoints = 0;
            this.Level = 1;
            this.Price = 100;
            this.Size = 2;
            this.WeaponType = WeaponType.Bow;
        }
    }
}