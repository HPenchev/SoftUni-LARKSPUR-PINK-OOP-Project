namespace Game.Interfaces
{
    public interface ICharacter : IStatsable
    {
        bool IsAlive { get; set; }
        double HealthPoints { get; set; }
        double AttackPoints { get; set; }
        double DefensePoints { get; set; }        
    }
}
