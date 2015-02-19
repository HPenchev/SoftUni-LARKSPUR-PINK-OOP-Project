namespace Game.Items.Spells
{
    using Core;

    public class SpellOfHealth : Spell
    {
        public SpellOfHealth(string id)
            : base(id)
        {
            this.ManaCost = 10;
            this.AttackPoints = 0;
            this.DefensePoints = 0;
            this.HealthPoints = 100;
            this.Level = 4;
            this.Price = 125;
            this.Size = 2;
        }
    }
}
