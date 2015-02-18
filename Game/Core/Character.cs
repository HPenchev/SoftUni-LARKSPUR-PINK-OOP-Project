using Game.Core.Data.Constants.PlayerConstatns;
using Game.Core.Data.Enums;
using Game.Interfaces;

namespace Game.Core
{
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
    }
}
