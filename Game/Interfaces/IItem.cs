namespace Game.Interfaces
{
    public interface IItem
    {
        string Id { get; set; }
        int Level { get; set; }
        decimal Price { get; set; }
        int Size { get; set; }
        double AttackPoints { get; set; }
        double DefensePoints { get; set; }        
        double HealthPoints { get; set; }
    }
}
