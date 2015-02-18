using Game.Core.Data.Enums;

namespace Game.Core.Data.Constants.PlayerConstatns
{
    public struct VampireConstants
    {
        // todo inventory - first item 
        public const int HealthPoints = 50;
        public const int DefencePoints = 10;
        public const int AttackPoints = 100;        
        public const int Range = 1;
        public const double AttackSpeed = 1.4;
        public const int CriticalChance = 6;
        public const int ChanceToDoge = 6;
        public const Team Tm = Team.Darkness;
    }
}