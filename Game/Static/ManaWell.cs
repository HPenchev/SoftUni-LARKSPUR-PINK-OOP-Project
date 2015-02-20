namespace Game.Static
{
    using Core;
    using Game.Interfaces;

    public static class ManaWell
    {
        private static double mana;
        private static bool isUsed;

        static ManaWell()
        {
            Mana = 100;
        }

        private static double Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        private static bool IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }

        public static double UseManaWell()
        {
            if (IsUsed)
            {
                return 0;
            }
            else
            {
                IsUsed = true;
                return Mana;
            }
        }
    }
}