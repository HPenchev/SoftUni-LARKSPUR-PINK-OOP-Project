namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Core.Data.Enums;

    public abstract class Armor : Equipment
    {
        private ArmorType armorType;

        protected Armor(string id) : base(id)
        {
            this.ArmorType = armorType; // This makes no sensce, Check it again!
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
    }
}