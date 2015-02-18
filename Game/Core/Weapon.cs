namespace Game.Core
{
    using Data.Enums;

    public abstract class Weapon : Equipment
    {
        private WeaponType weaponType;

        protected Weapon(string id)
            : base(id)
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