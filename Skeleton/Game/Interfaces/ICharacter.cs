namespace Game.Interfaces
{
    public interface ICharacter
    {
        bool IsAlive { get; set; }
        double HealthPoints { get; set; }
        double AttackPoints { get; set; }
        double DefencePoints { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}
