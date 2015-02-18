namespace Game.Core
{
    using System;

    public class MapGenerator
    {
        /* UNFINISHED */
        #region Fields
        private char[,] map;
        private int size;
        private int manaWellCount;
        private int healthWellCount;
        private int chestCount;
        private int minionCount;
        #endregion

        #region Constructor
        public MapGenerator(int size, int healthWellCount, int manaWellCount, int chestCount, int minionCount)
        {
            this.Size = size;
            this.HealthWellCount = healthWellCount;
            this.ManaWellCount = manaWellCount;
            this.ChestCount = chestCount;
            this.MinionCount = minionCount;
            CreateMap(this.Size);
        }
        #endregion

        #region Properties
        public char[,] Map
        {
            get { return this.map; }

            set { this.map = value; }
        }

        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public int ManaWellCount
        {
            get { return manaWellCount; }
            set { manaWellCount = value; }
        }

        public int HealthWellCount
        {
            get { return healthWellCount; }
            set { healthWellCount = value; }
        }

        public int ChestCount
        {
            get { return chestCount; }
            set { chestCount = value; }
        }

        public int MinionCount
        {
            get { return minionCount; }
            set { minionCount = value; }
        }
        #endregion

        #region Methods
        private void CreateMap(int size)
        {
            Random random = new Random();
            char[,] array = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = 'e';
                }
            }
            int ShopPosition = this.size/2;
            array[ShopPosition, ShopPosition] = 'H';
            array[ShopPosition, ShopPosition - 1] = 'P';
            this.Map = array;
            RandomTheMap(this.Map);
        }

        private void RandomTheMap(char[,] map)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int xRandom, yRandom;
            Position[] validPositions = 
            {
                new Position(0, 0),
                new Position(Size-2, Size-1),
                new Position(0, Size-1),
                new Position(Size-2, 0) 
            };
            Position bossPosition = validPositions[random.Next(0, validPositions.Length)];
            this.Map[bossPosition.X, bossPosition.Y] = 'B';
            
            for (int i = 0; i < this.ManaWellCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'm';
                } while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
            for (int i = 0; i < this.HealthWellCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'h';
                } while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
            for (int i = 0; i < this.ChestCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'c';
                } while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
            for (int i = 0; i < this.MinionCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'M';
                } while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < size - 1; i++)
            {
                string line = "";
                for (int j = 0; j < size; j++)
                {
                    line += this.Map[i, j];
                }
                Console.WriteLine(line);
            }
        }
        #endregion
    }
}