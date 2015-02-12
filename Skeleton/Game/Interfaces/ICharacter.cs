namespace Game.Interfaces
{
    public interface ICharacter
    {
        bool IsAlive { get; set; }
        int HealthPoints { get; set; }
        int AttackPoints { get; set; }
        int DefencePoints { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}
