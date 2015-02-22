namespace Game.Core
{
    using System.Text;
    using System.Collections.Generic;
    using Data.Constants.PlayerConstatns;
    using Interfaces;

    public abstract class Character : GameObject, ICharacter
    {
        private bool isAlive;

        private double maxHealthPoints;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private double range;
        private List<Item> inventory = new List<Item>();

        protected Character(string id)
            : base(id)
        {
            this.IsAlive = PlayerConstants.IsAlive;
        }

        public double MaxHealthPoints
        {
            get { return this.maxHealthPoints; }
            set { this.maxHealthPoints = value; }
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

        public List<Item> Inventory
        {
            get { return this.inventory; }
            set { this.inventory = value; }
        }


        public virtual void CastSpell(Spell spell) //To be implemented todo
        {
             
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