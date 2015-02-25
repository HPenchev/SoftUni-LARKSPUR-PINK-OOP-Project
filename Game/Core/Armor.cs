using System;

namespace Game.Core
{
    using System.Text;
    using Data.Enums;

    [Serializable]
    public abstract class Armor : Equipment
    {
        #region Fields
        private ArmorType armorType;
        #endregion

        #region Constructors
        protected Armor(string id)
            : base(id)
        {
            this.ArmorType = armorType;
        }
        #endregion

        #region Properties
        public ArmorType ArmorType
        {
            get { return this.armorType; }

            set { this.armorType = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(base.ToString());
            builder.AppendFormat("Armor Type = {0}\n", this.ArmorType);
            return builder.ToString();
        }
        #endregion
    }
}