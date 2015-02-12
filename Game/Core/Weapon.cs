namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Enums;

    public abstract class Weapon : Equipment
    {

        private WeaponType weaponType;

        protected Weapon(string id) : base(id)
        {
            this.WeaponType = weaponType;
        }
        public WeaponType WeaponType
        {
            get
            {
                return this.weaponType;
            }

            set
            {
                this.weaponType = value;
            }
        }
    }
}