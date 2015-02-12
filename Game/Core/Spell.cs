namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Spell : Item
    {
        private double manaCost;
        protected Spell(string id) : base(id)
        {
            this.ManaCost = manaCost;
        }
        public double ManaCost
        {
            get
            {
                return this.manaCost;
            }

            set
            {
                this.manaCost = value;
            }
        }
    }
}