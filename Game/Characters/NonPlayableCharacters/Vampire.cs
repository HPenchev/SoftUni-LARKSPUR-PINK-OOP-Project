namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
    using Game.Interfaces;

    public class Vampire : Character
    {
        public Vampire(string id)
            : base(
            id,
            VampireConstants.HealthPoints,
            VampireConstants.DefencePoints,
            VampireConstants.Range,
            VampireConstants.AttackPoints,
            VampireConstants.AttackSpeed,
            VampireConstants.CriticalChance,
            VampireConstants.ChanceToDoge)
        {
            this.HealthPoints = VampireConstants.HealthPoints;
            this.DefensePoints = VampireConstants.DefencePoints;
            this.AttackPoints = VampireConstants.AttackPoints;            
            this.Range = VampireConstants.Range;
            this.Team = VampireConstants.Tm;           
        }
    }
}