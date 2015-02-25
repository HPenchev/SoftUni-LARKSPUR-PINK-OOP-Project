using System.Reflection;
using System.Text;

namespace Game.Core
{
    using System;

    [Serializable]
    public class MapGenerator
    {
        #region Fields
        private char[,] map;
        private int size;
        private int manaWellCount;
        private int healthWellCount;
        private int chestCount;
        private int minionCount;
        private int mobCount;
        #endregion

        #region Constructor
        public MapGenerator(int size, int healthWellCount, int manaWellCount, int chestCount, int minionCount, int mobCount)
        {
            this.Size = size;
            this.HealthWellCount = healthWellCount;
            this.ManaWellCount = manaWellCount;
            this.ChestCount = chestCount;
            this.MinionCount = minionCount;
            this.MobCount = mobCount;
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

        public int MobCount
        {
            get { return this.mobCount; }
            set { this.mobCount = value; }
        }
        #endregion

        #region Methods

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
            RandomTheMap(this.Map);
        }

        private void RandomTheMap(char[,] map)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            this.GenerateBoss(random);
            this.GenerateManaWells(random);
            this.GenerateHealthWells(random);
            this.GenerateChests(random);
            this.GenerateMinions(random);
            this.GenerateMobs(random);
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
                xRandom = random.Next(0, this.Size);
                yRandom = random.Next(0, this.Size);
                if (this.Map[xRandom, yRandom] != 'e')
                {
                    SetNewPosition('m');
                }
                else
                {
                    this.Map[xRandom, yRandom] = 'm';
                }
            }
        }

        private void GenerateHealthWells(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.HealthWellCount; i++)
            {
                xRandom = random.Next(0, this.Size);
                yRandom = random.Next(0, this.Size);
                if (this.Map[xRandom, yRandom] != 'e')
                {
                    SetNewPosition('h');
                }
                else
                {
                    this.Map[xRandom, yRandom] = 'h';
                }
            }
        }

        private void GenerateChests(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.ChestCount; i++)
            {
                xRandom = random.Next(0, this.Size);
                yRandom = random.Next(0, this.Size);
                if (this.Map[xRandom, yRandom] != 'e')
                {
                    SetNewPosition('c');
                }
                else
                {
                    this.Map[xRandom, yRandom] = 'c';
                }
            }
        }

        private void GenerateMinions(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.MinionCount; i++)
            {
                xRandom = random.Next(0, this.Size);
                yRandom = random.Next(0, this.Size);
                if (this.Map[xRandom, yRandom] != 'e')
                {
                    SetNewPosition('M');
                }
                else
                {
                    this.Map[xRandom, yRandom] = 'M';
                }
            }
        }

        private void GenerateMobs(Random random)
        {
            int xRandom, yRandom;
            for (int i = 0; i < this.MobCount; i++)
            {
                xRandom = random.Next(0, this.Size);
                yRandom = random.Next(0, this.Size);
                if (this.Map[xRandom, yRandom] != 'e')
                {
                    SetNewPosition('O');
                }
                else
                {
                    this.Map[xRandom, yRandom] = 'O';
                }
            }
        }

        private void SetNewPosition(char type)
        {
            Random random = new Random();
            int xRandom, yRandom;
            xRandom = random.Next(0, this.Size);
            yRandom = random.Next(0, this.Size);
            while (this.Map[xRandom, yRandom] != 'e')
            {
                int x = random.Next(0, this.Size);
                int y = random.Next(0, this.Size);
                if (this.Map[x, y] == 'e')
                {
                    xRandom = x;
                    yRandom = y;
                    break;
                }
            }
            this.Map[xRandom, yRandom] = type;
        }

        public void PrintMap()
        {
            for (int i = 0; i < this.Size; i++)
            {
                string line = string.Empty;
                for (int j = 0; j < this.Size; j++)
                {
                    line += this.Map[i, j];
                }
                PrintHighlightedMap(line);
            }
        }

        private void PrintHighlightedMap(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'P')
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (line[i] == 'M')
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (line[i] == 'B')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (line[i] == 'H')
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (line[i] == 'm')
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (line[i] == 'h')
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (line[i] == 'c')
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (line[i] == 'O')
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(line[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(line[i]);
                }
            }
            Console.WriteLine();
        }
        #endregion
    }
}