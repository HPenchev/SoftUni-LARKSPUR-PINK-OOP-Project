﻿using Game.Interfaces;

namespace Game.Core
{
    public abstract class Character : GameObject, ICharacter
    {
        protected bool isAlive = true;
        private int healthPoints;
        private int attackPoints;
        private int defencePoints;
        private double range;
        private double x;
        private double y;
        protected Character(string id)
            : base(id)
        {
            this.IsAlive = true;
        }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public int HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }

        public int DefencePoints
        {
            get { return this.defencePoints; }
            set { this.defencePoints = value; }
        }


        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Range
        {
            get { return this.range; }
            set { this.range = value; }
        }
    }
}
