namespace Game.Characters.Interfaces
{
    public interface IAttack
    {
        int AttackPoints { get; set; }

        void Attack();
    }
}