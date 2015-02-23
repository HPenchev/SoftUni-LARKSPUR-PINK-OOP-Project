namespace Game.Core
{
    using System.Collections.Generic;
    using System.Text;
    using Data.Constants.PlayerConstatns;
    using Interfaces;

    public abstract class Character : GameObject, ICharacter
    {
        #region Fields
        private bool isAlive;
        private double maxHealthPoints;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private double range;
        private List<Item> inventory = new List<Item>();
        #endregion

        #region Constructors
        protected Character(string id)
            : base(id)
        {
            this.IsAlive = PlayerConstants.IsAlive;
        }
        #endregion

        #region Properties
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
            get
            {
                return this.healthPoints;
            }

            set
            {
                if (value <= 0)
                {
                    this.IsAlive = false;
                }

                this.healthPoints = value;
            }
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
        #endregion

        #region Methods
        public virtual void Attack(ICharacter target)
        {
            double damage = CalculateDamage();
            if (target.DefensePoints > damage)
            {
                damage = 1;
            }
            else
            {
                damage -= target.DefensePoints;
            }

            target.HealthPoints -= damage;
        }

        public override string ToString()
        {
            StringBuilder baseCharacter = new StringBuilder();
            baseCharacter.AppendFormat(
                "Status: {0},\nHealth points: {1},\nAttack points: {2},\nDefence points: {3},\nRange: {4},\n", this.IsAlive ? "Alive" : "Dead", this.HealthPoints, this.AttackPoints, this.DefensePoints, this.Range);
            return baseCharacter.ToString();
        }

         protected virtual double CalculateDamage()
        {
            double damage = this.AttackPoints;
            if (damage < 1)
            {
                damage = 1;
            }

            return damage;
        }
        #endregion
    }
}