namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    public abstract class Item : GameObject, IItem 
    {
        private double attackPoints;
        private double healthPoints;
        private double defensePoints;
        private int level;
        private decimal price;
        private int size;
        protected Item(string id) : base(id)
        {
            this.AttackPoints = attackPoints;
            this.Level = level;
            this.Price = price;
            this.Size = size;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
        }
        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            set
            {
                this.attackPoints = value;
            }
        }
        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                this.healthPoints = value;
            }
        }
        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            set
            {
                this.defensePoints = value;
            }
        }
        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() 
                + string.Format("\nAttack Points: {0}\nLevel: {1}\nPrice: {2}\nSize: {3}\nHealth Points: {4}\nDefencePoints: {5}",
                this.AttackPoints, this.Level, this.Price);
        }
    }
}