namespace Game.Characters
{
    using System.Text;
    using Core;
    using Core.Data.Constants.PlayerConstatns;
   
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

        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Amazon,\n");
            playerToString.Append(base.ToString());
            return playerToString.ToString();
        }
    }
}