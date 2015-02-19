namespace Game.Items.Spells
{
    using Core;

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
            this.Size = 2;
        }
    }
}