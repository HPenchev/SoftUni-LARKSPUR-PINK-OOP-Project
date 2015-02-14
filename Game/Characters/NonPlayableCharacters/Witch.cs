namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
    using Game.Interfaces;

    public class Witch : Character
    {
        public Witch(string id)
            : base(
            id,
            WitchConstants.HealthPoints,
            WitchConstants.DefencePoints,
            WitchConstants.Range,
            WitchConstants.AttackPoints,
            WitchConstants.AttackSpeed,
            WitchConstants.CriticalChance,
            WitchConstants.ChanceToDoge)
        {
            this.HealthPoints = WitchConstants.HealthPoints;
            this.DefensePoints = WitchConstants.DefencePoints;
            this.AttackPoints = WitchConstants.AttackPoints;
            this.Range = WitchConstants.Range;
            this.Team = WitchConstants.Tm;
        }
    }
}