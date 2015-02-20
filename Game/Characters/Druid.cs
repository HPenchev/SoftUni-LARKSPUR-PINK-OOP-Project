namespace Game.Characters
{
    using System.Text;
    using Core;
    using Core.Data.Constants.PlayerConstatns;

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

        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Driud,\n");
            playerToString.Append(base.ToString());
            return playerToString.ToString();
        }
    }
}