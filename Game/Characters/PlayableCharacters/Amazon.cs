namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
    using Game.Core.Data.Enums;
    using Game.Exceptions;
    using Game.Interfaces;


    public class Amazon : Player
    {
        public Amazon(string id)
            : base(
            id,
            AmazonConstants.HealthPoints,
            AmazonConstants.DefencePoints,
            AmazonConstants.Range,
            AmazonConstants.AttackPoints,
            AmazonConstants.AttackSpeed,
            AmazonConstants.CriticalChance,
            AmazonConstants.ChanceToDoge)
        {
            this.HealthPoints = AmazonConstants.HealthPoints;
            this.DefensePoints = AmazonConstants.DefencePoints;
            this.AttackPoints = AmazonConstants.AttackPoints;
            this.Mana = AmazonConstants.Mana;
            this.Range = AmazonConstants.Range;
        }

        protected override void EquipWeapon(IItem item)
        {
            if (item is Weapon && (((Weapon)item).WeaponType != WeaponType.Axe) && (((Weapon)item).WeaponType != WeaponType.Sword))
            {
                throw new WeaponNotSupportedException("Barbarian can support mellee weapons only");
            }

            base.EquipWeapon(item);
        }
    }
}