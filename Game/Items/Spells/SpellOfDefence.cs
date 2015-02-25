using System;

namespace Game.Items.Spells
{
    using Core;

    [Serializable]
    public class SpellOfDefence : Spell
    {

        public SpellOfDefence(string id)
            : base(id)
        {
            this.ManaCost = 10;
            this.AttackPoints = 0;
            this.DefensePoints = 100;
            this.HealthPoints = 0;
            this.Level = 6;
            this.Price = 150;
            this.Size = 2;
        }
    }
}
