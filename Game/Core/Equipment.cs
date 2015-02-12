﻿namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Equipment : Item
    {
        private double attackSpeed;
        private double criticalChance;
        private double criticalDamage;
        private double chanceToDoge;
        private bool isEquiped;
        protected Equipment(string id) : base(id)
        {
            this.AttackSpeed = attackSpeed;
            this.CriticalChance = criticalChance;
            this.CriticalDamage = criticalDamage;
            this.ChanceToDoge = chanceToDoge;
            this.IsEquiped = isEquiped;
        }

        public double AttackSpeed
        {
            get
            {
                return this.attackSpeed;
            }

            set
            {
                this.attackSpeed = value;
            }
        }
        public double CriticalChance
        {
            get
            {
                return this.criticalChance;
            }

            set
            {
                this.criticalChance = value;
            }
        }
        public double CriticalDamage
        {
            get
            {
                return this.criticalDamage;
            }

            set
            {
                this.criticalDamage = value;
            }
        }
        public double ChanceToDoge
        {
            get
            {
                return this.chanceToDoge;
            }

            set
            {
                this.chanceToDoge = value;
            }
        }
        public bool IsEquiped
        {
            get
            {
                return this.isEquiped;
            }

            set
            {
                this.isEquiped = value;
            }
        }
    }
}