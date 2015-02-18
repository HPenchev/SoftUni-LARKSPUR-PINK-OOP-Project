namespace Game.Interfaces
{
    public interface IStatsable
    {
        double AttackSpeed { get; set; }

        double CriticalChance { get; set; }

        double ChanceToDodge { get; set; }

        double CritDamage { get; set; }

        double AllResistance { get; set; }
    }
}