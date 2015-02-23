namespace Game.Interfaces
{
    using Game.Core;
    public interface IEnemy
    {
        void Attack(ICharacter player);

        void DropReward(); // should drop gold and items
    }
}
