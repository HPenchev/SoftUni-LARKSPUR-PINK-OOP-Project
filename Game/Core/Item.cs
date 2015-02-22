namespace Game.Core
{
    using System.Text;
    using Exceptions.ItemException;
    using Interfaces;
    //todo Exceptions
    public abstract class Item : GameObject, IItem 
    {
        #region Fields
        private double attackPoints;
        private double healthPoints;
        private double defensePoints;
        private int level;
        private decimal price;
        private int size;
        #endregion

        #region Constructors
        protected Item(string id) : base(id)
        {
            this.AttackPoints = attackPoints;
            this.Level = level;
            this.Price = price;
            this.Size = size;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
        }
        #endregion

        #region Properties
        public double AttackPoints
        {
            get { return this.attackPoints; }

            set { this.attackPoints = value; }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }

            set { this.healthPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }

            set { this.defensePoints = value; }
        }

        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                if (value < 0)
                {
                    throw new ValueIsNegativeException("The level can not be negative.");
                }

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
                if (value < 0)
                {
                    throw new ValueIsNegativeException("The price can not be negative.");
                }

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
                if (value < 0)
                {
                    throw new ValueIsNegativeException("The size can not be negative.");
                }

                this.size = value;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(base.ToString());
            builder.AppendFormat("Attack Points = {0}\n", this.AttackPoints);
            builder.AppendFormat("Health Points = {0}\n", this.HealthPoints);
            builder.AppendFormat("Defense Points = {0}\n", this.DefensePoints);
            builder.AppendFormat("Level = {0}\n", this.Level);
            builder.AppendFormat("Price = {0}\n", this.Price);
            builder.AppendFormat("Size = {0}\n", this.Size);
            return builder.ToString();
        }
        #endregion
    }
}