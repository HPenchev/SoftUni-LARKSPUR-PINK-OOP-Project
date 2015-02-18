namespace Game.Core
{
    using System.Text;
    using Data.Constants.PlayerConstatns;
    using Interfaces;

    public abstract class Character : GameObject, ICharacter
    {
        private bool isAlive;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private double range;

        protected Character(string id)
            : base(id)
        {
            this.IsAlive = PlayerConstants.IsAlive;
        }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            set { this.defensePoints = value; }
        }

        public double Range
        {
            get { return this.range; }
            set { this.range = value; }
        }

        public override string ToString()
        {
            StringBuilder baseCharacter = new StringBuilder();
            baseCharacter.AppendFormat(
                "Status: {0},\nHealth points: {1},\nAttack points: {2},\nDefence points: {3},\nRange: {4},\n", this.IsAlive ? "Alive" : "Dead", this.HealthPoints, this.AttackPoints, this.DefensePoints, this.Range);
            return baseCharacter.ToString();
        }
    }
}