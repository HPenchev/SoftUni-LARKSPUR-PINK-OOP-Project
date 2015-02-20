using System.Runtime.CompilerServices;

namespace Game.Static
{
    using Core;
    using Interfaces;

    public static class HealthWell
    {
        private static double health;
        private static bool isUsed;

        static HealthWell()
        {
            Health = 100;
        }

        private static double Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        private static bool IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }

        public static double UseHealthWell()
        {
            if (IsUsed)
            {
                return 0;
            }
            else
            {
                IsUsed = true;
                return Health;   
            }
        }
    }
}