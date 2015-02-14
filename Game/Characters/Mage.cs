using System.Collections.Generic;
using Game.Core;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Interfaces;

namespace Game.Characters
{
    public class Mage : Player
    {
        public Mage(string id)
            : base(id, 
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
    }
}