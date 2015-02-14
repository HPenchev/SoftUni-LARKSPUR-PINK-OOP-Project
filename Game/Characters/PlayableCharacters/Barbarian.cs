namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
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
    }
}