using Game.Core;
using Game.Core.Data.Enums;

namespace Game.Items
{
    public class SwordOfNakov : Weapon
    {
        public SwordOfNakov(string id) : base(id)
        {
            this.Id = "The Sword of Justice";
            this.AttackPoints = 100;
            this.AttackSpeed = 1;
            this.ChanceToDodge = 0;
            this.CriticalChance = 1;
            this.CriticalDamage = 1;
            this.DefensePoints = 0;
            this.HealthPoints = 0;
            this.Level = 1;
            this.Price = 100;
            this.Size = 2;
            this.WeaponType = WeaponType.Sword;
        }
    }
}
