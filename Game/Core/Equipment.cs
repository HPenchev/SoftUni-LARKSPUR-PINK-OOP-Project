namespace Game.Core
{
    public abstract class Equipment : Item
    {
        private double attackSpeed;
        private double criticalChance;
        private double criticalDamage;
        private double chanceToDodge;
        private bool isEquiped;

        protected Equipment(string id)
            : base(id)
        {
            this.AttackSpeed = attackSpeed;
            this.CriticalChance = criticalChance;
            this.CriticalDamage = criticalDamage;
            this.ChanceToDodge = chanceToDodge;
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

        public double ChanceToDodge
        {
            get
            {
                return this.chanceToDodge;
            }

            set
            {
                this.chanceToDodge = value;
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
        public override string ToString()
        {
            return base.ToString() 
                + string.Format("Attack Speed: {0}\nCritical Chance: {1}\nCritical Damage: {2}\nDodge chance: {3}"
                ,this.AttackSpeed, this.CriticalChance, this.CriticalDamage, this.ChanceToDodge );
        }
    }
}