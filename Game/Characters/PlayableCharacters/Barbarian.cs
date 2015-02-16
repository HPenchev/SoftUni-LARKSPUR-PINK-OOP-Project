namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
    using Game.Core.Data.Enums;
    using Game.Exceptions;
    using Game.Interfaces;

    public class Barbarian : Player
    {
        public Barbarian(string id)
            : base(
            id,
            BarbarianConstants.HealthPoints,
            BarbarianConstants.DefencePoints,
            BarbarianConstants.Range,
            BarbarianConstants.AttackPoints,
            BarbarianConstants.AttackSpeed,
            BarbarianConstants.CriticalChance,
            BarbarianConstants.ChanceToDoge)
        {
            this.HealthPoints = BarbarianConstants.HealthPoints;
            this.DefensePoints = BarbarianConstants.DefencePoints;
            this.AttackPoints = BarbarianConstants.AttackPoints;
            this.Mana = BarbarianConstants.Mana;
            this.Range = BarbarianConstants.Range;
        }

        protected override void EquipWeapon(IItem item)
        {
            if (item is Weapon && (((Weapon)item).WeaponType != WeaponType.Bow))
            {
                throw new WeaponNotSupportedException("Amazon can support only bows");
            }
            base.EquipWeapon(item);
        }
    }
}