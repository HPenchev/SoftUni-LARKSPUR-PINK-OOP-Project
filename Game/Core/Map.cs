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
            this.CreateMap(this.Size);
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
            get
            {
                return this.size;
            }

            set
            {
                if (value % 2 == 0)
                {
                    value++;
                }

                this.size = value;
            }
        }

        public int ManaWellCount
        {
            get { return this.manaWellCount; }
            set { this.manaWellCount = value; }
        }

        public int HealthWellCount
        {
            get { return this.healthWellCount; }
            set { this.healthWellCount = value; }
        }

        public int ChestCount
        {
            get { return this.chestCount; }
            set { this.chestCount = value; }
        }

        public int MinionCount
        {
            get { return this.minionCount; }
            set { this.minionCount = value; }
        }
        #endregion

        #region Methods
        public void PrintMap()
        {
            for (int i = 0; i < this.Size; i++)
            {
                string line = string.Empty;
                for (int j = 0; j < this.Size; j++)
                {
                    line += this.Map[i, j];
                }

                Console.WriteLine(line);
            }
        }

        private void CreateMap(int size)
        {
            char[,] array = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = 'e';
                }
            }

            int shopPosition = this.size / 2;
            array[shopPosition, shopPosition] = 'H';
            array[shopPosition, shopPosition - 1] = 'P';
            this.Map = array;
            this.RandomTheMap(this.Map);
        }

        private void RandomTheMap(char[,] map)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            this.GenerateBoss(random);
            this.GenerateManaWells(random);
            this.GenerateHealthWells(random);
            this.GenerateChests(random);
            this.GenerateMinions(random);
        }

        private void GenerateBoss(Random random)
        {
            Position[] validPositions =
            {
                new Position(0, 0),
                new Position(this.Size - 2, this.Size - 1),
                new Position(0, this.Size - 1),
                new Position(this.Size - 2, 0)
            };
            Position bossPosition = validPositions[random.Next(0, validPositions.Length)];
            this.Map[bossPosition.X, bossPosition.Y] = 'B';
        }

        private void GenerateManaWells(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.ManaWellCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'm';
                }
                while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
        }

        private void GenerateHealthWells(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.HealthWellCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'h';
                }
                while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
        }

        private void GenerateChests(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.ChestCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'c';
                }
                while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
        }

        private void GenerateMinions(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.MinionCount; i++)
            {
                do
                {
                    xRandom = random.Next(0, this.Size);
                    yRandom = random.Next(0, this.Size);
                    this.Map[xRandom, yRandom] = 'M';
                }
                while (this.Map[xRandom, yRandom] == 'e' &&
                         this.Map[xRandom, yRandom] == 'H' &&
                         this.Map[xRandom, yRandom] == 'P' &&
                         this.Map[xRandom, yRandom] == 'B');
            }
        }
        #endregion
    }
}