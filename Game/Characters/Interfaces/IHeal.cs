namespace Game.Characters.Interfaces
{
    public interface IHeal
    {
        int HealingPoints { get; set; }

        void Heal();
    }
}