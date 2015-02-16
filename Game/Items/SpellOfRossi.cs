namespace Game.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Game.Core;
    using Game.Interfaces;
    using Game.Core.Data.Enums;

    public class SpellOfRossi : Spell
    {
        public SpellOfRossi(string id) : base(id)
        {
            this.ManaCost = 5;
            this.AttackPoints = 100;
            this.DefensePoints = 0;
            this.HealthPoints = 0;
            this.Level = 2;
            this.Price = 100;
            this.Size = 4;
        }
    }
}