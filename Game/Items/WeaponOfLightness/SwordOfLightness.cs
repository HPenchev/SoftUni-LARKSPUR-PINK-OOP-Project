namespace Game.Items.WeaponOfLightness
{
    using System;
    using Core;
    using Core.Data.Enums;

    [Serializable]
    public class SwordOfLightness : Weapon
    {
        public SwordOfLightness(string id)
            : base(id)
        {
            this.Id = "Sword made from the core of fallen star";
            this.AttackPoints = 125;
            this.AttackSpeed = 0;
            this.ChanceToDodge = 0;
            this.CriticalChance = 3;
            this.CriticalDamage = 15;
            this.DefensePoints = 0;
            this.HealthPoints = 0;
            this.Level = 1;
            this.Price = 125;
            this.Size = 3;
            this.WeaponType = WeaponType.Sword;
        }
    }
}
