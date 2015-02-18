using Game.Core;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Interfaces;

namespace Game.Characters
{
    public class Druid : Player
    {
        public Druid(string id)
            : base(
            id)
        {
            this.HealthPoints = DruidConstants.HealthPoints;
            this.DefensePoints = DruidConstants.DefencePoints;
            this.AttackPoints = DruidConstants.AttackPoints;
            this.Mana = DruidConstants.Mana;
            this.Range = DruidConstants.Range;
        }

        public override void Attack(ICharacter enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}