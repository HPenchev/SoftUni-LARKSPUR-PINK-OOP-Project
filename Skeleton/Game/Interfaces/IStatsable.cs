namespace Game.Interfaces
{
    public interface IStatsable
    {
        //depend on items;
        double AttackSpeed { get; set; }
        double AllResistance { get; set; }
        double CritChance { get; set; }
        double ChanceToDoge { get; set; }

    }
}
