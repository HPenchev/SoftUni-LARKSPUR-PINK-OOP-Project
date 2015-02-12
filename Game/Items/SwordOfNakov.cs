namespace Game.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Core;
    using Core.Data.Enums;
    using Core.Data.Constants;

    public class SwordOfNakov : Weapon
    {
        public SwordOfNakov(string id) : base(id)
        {
            this.Id = "The Sword of Justice";
            this.AttackPoints = 100;
            this.AttackSpeed = 1;
            this.ChanceToDoge = 0;
            this.CriticalChance = 1;
            this.CriticalDamage = 1;
            this.DefencePoints = 0;
            this.HealthPoints = 0;
            this.Level = 1;
            this.Price = 100;
            this.Size = 2;
            this.WeaponType = WeaponType.Sword;
        }
    }
}
