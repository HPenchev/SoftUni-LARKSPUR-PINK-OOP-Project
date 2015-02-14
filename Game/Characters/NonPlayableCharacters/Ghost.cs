namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
    using Game.Interfaces;

    public class Ghost : Character
    {
        public Ghost(string id)
            : base(
            id,
            GhostConstants.HealthPoints,
            GhostConstants.DefencePoints,
            GhostConstants.Range,
            GhostConstants.AttackPoints,
            GhostConstants.AttackSpeed,
            GhostConstants.CriticalChance,
            GhostConstants.ChanceToDoge)
        {
            this.HealthPoints = GhostConstants.HealthPoints;
            this.DefensePoints = GhostConstants.DefencePoints;
            this.AttackPoints = GhostConstants.AttackPoints;
            this.Range = GhostConstants.Range;
            this.Team = GhostConstants.Tm;
        }
    }
}