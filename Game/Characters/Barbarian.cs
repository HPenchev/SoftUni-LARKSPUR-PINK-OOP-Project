using Game.Core;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Core.Data.Enums;
using Game.Exceptions;
using Game.Interfaces;

namespace Game.Characters
{
    public class Barbarian : Player
    {
        public Barbarian(string id)
            : base(
            id)
        {
            this.HealthPoints = BarbarianConstants.HealthPoints;
            this.DefensePoints = BarbarianConstants.DefencePoints;
            this.AttackPoints = BarbarianConstants.AttackPoints;
            this.Mana = BarbarianConstants.Mana;
            this.Range = BarbarianConstants.Range;
        }


        public override void Attack(ICharacter enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}