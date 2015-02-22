namespace Game.Interfaces
{
    public interface IEnemy
    {
        void Attack(ICharacter player);

        void DropReward(); // should drop gold and items
    }
}
