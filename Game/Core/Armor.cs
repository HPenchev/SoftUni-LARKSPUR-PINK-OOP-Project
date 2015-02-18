using Game.Core.Data.Enums;

namespace Game.Core
{
    public abstract class Armor : Equipment
    {
        private ArmorType armorType;

        protected Armor(string id) : base(id)
        {
            this.ArmorType = armorType; 
        }

        public ArmorType ArmorType
        {
            get
            {
                return this.armorType;
            }

            set
            {
                this.armorType = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + string.Format("Armor type: {0}", this.ArmorType);
        }
    }
}