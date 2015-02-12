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
        private double defencePoints;
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
            this.DefencePoints = defencePoints;
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
        public double DefencePoints
        {
            get
            {
                return this.defencePoints;
            }

            set
            {
                this.defencePoints = value;
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
    }
}