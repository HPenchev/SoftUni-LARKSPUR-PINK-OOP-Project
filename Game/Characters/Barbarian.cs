namespace Game.Characters
{
    using System;
    using System.Text;
    using Core;
    using Core.Data.Constants.PlayerConstatns;
    using Interfaces;

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

        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Barberian,\n");
            playerToString.Append(base.ToString());
            return playerToString.ToString();
        }
    }
}