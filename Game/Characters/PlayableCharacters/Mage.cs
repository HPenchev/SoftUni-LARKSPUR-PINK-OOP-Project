namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
    using Game.Core.Data.Enums;
    using Game.Exceptions;
    using Game.Interfaces;

    public class Mage : Player
    {
        public Mage(string id)
            : base(
            id, 
            MageConstants.HealthPoints, 
            MageConstants.DefencePoints,
            MageConstants.Range, 
            MageConstants.AttackPoints, 
            MageConstants.AttackSpeed,
            MageConstants.CriticalChance, 
            MageConstants.ChanceToDoge)           
        {
            this.HealthPoints = MageConstants.HealthPoints;
            this.DefensePoints = MageConstants.DefencePoints;
            this.AttackPoints = MageConstants.AttackPoints;
            this.Mana = MageConstants.Mana;
            this.Range = MageConstants.Range;
        }

        protected override void EquipWeapon(IItem item)
        {
            if (item is Weapon && (((Weapon)item).WeaponType != WeaponType.Wand))
            {
                throw new WeaponNotSupportedException("Mage can support wand only");
            }

            base.EquipWeapon(item);
        }
    }
}