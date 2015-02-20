namespace Game.Core
{
    using System.Text;
    using Exceptions.ItemException;

    public abstract class Equipment : Item
    {
        #region Fields
        private double attackSpeed;
        private double criticalChance;
        private double criticalDamage;
        private double chanceToDodge;
        private bool isEquiped;
        #endregion

        #region Constructors
        protected Equipment(string id) : base(id)
        {
            this.AttackSpeed = attackSpeed;
            this.CriticalChance = criticalChance;
            this.CriticalDamage = criticalDamage;
            this.ChanceToDodge = chanceToDodge;
            this.IsEquiped = isEquiped;
        }
        #endregion

        #region Properties
        public double AttackSpeed
        {
            get
            {
                return this.attackSpeed;
            }

            set
            {
                //if (value < 0)
                //{
                //    throw new ValueIsNegativeException("The Attack Speed can not be negative");
                //}

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
                //if (value < 0)
                //{
                //    throw new ValueIsNegativeException("The Critical chance can not be negative.");
                //}

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
                //if (value < 0)
                //{
                //    throw new ValueIsNegativeException("The Critical Damage can not be negative.");
                //}

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
                //if (value < 0)
                //{
                //    throw new ValueIsNegativeException("Chance to Dodge can not be negative.");
                //}

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
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(base.ToString());
            builder.AppendFormat("Attack Speed = {0}\n", this.AttackSpeed);
            builder.AppendFormat("Critical Chance = {0}\n", this.CriticalChance);
            builder.AppendFormat("Critical Damage = {0}\n", this.CriticalDamage);
            builder.AppendFormat("Chance to Dodge = {0}\n", this.ChanceToDodge);
            builder.AppendFormat("Is Equiped = {0}\n", this.IsEquiped ? "Yes" : "No");
            return builder.ToString();
        }
        #endregion
    }
}