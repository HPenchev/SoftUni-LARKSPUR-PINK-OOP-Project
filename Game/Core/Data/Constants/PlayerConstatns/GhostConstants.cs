namespace Game.Core.Data.Constants.PlayerConstatns
{
    using Game.Core.Data.Enums;
    public struct GhostConstants
    {
        // todo inventory - first item 
        public const int HealthPoints = 30;
        public const int DefencePoints = 5;
        public const int AttackPoints = 110;
        public const int Range = 3;
        public const double AttackSpeed = 1.5;
        public const int CriticalChance = 8;
        public const int ChanceToDoge = 60;
        public const Team Tm = Team.Darkness;
    }
}