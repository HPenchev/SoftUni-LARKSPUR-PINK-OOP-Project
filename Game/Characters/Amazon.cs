using Game.Core;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Core.Data.Enums;
using Game.Exceptions;
using Game.Interfaces;

namespace Game.Characters
{
    public class Amazon : Player
    {
        public Amazon(string id)
            : base(
            id)
        {
            this.HealthPoints = AmazonConstants.HealthPoints;
            this.DefensePoints = AmazonConstants.DefencePoints;
            this.AttackPoints = AmazonConstants.AttackPoints;
            this.Mana = AmazonConstants.Mana;
            this.Range = AmazonConstants.Range;
        }


        public override void Attack(ICharacter enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}