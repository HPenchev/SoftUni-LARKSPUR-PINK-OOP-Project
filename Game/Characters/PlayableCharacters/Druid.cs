namespace Game.Characters
{
    using System.Collections.Generic;
    using Game.Core;
    using Game.Core.Data.Constants.PlayerConstatns;
    using Game.Interfaces;

    public class Druid : Player
    {
        public Druid(string id)
            : base(
            id,
            DruidConstants.HealthPoints,
            DruidConstants.DefencePoints,
            DruidConstants.Range,
            DruidConstants.AttackPoints,
            DruidConstants.AttackSpeed,
            DruidConstants.CriticalChance,
            DruidConstants.ChanceToDoge)
        {
            this.HealthPoints = DruidConstants.HealthPoints;
            this.DefensePoints = DruidConstants.DefencePoints;
            this.AttackPoints = DruidConstants.AttackPoints;
            this.Mana = DruidConstants.Mana;
            this.Range = DruidConstants.Range;
        }
    }
}