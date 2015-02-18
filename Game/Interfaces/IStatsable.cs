namespace Game.Interfaces
{
    public interface IStatsable
    {
        //depend on items;
        double AttackSpeed { get; set; }
        //double AllResistance { get; set; }
        int CriticalChance { get; set; }
        int ChanceToDodge { get; set; }
        double CritDamage { get; set; }


    }
}
