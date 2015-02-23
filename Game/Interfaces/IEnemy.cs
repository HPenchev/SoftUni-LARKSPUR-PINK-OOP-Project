namespace Game.Interfaces
{
    using Game.Core;
    public interface IEnemy
    {
        void Attack(Character player);

        void DropReward(); // should drop gold and items
    }
}
