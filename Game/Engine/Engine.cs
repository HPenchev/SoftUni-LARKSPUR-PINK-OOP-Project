namespace Game.Engine
{
    using System;
    using System.Linq;
    using Characters;
    using Core;
    using Core.Data.Constants.EngineConstants;
    using Interfaces;

    public class Engine
    {
        //todo map showing?
        private static ICharacter player;
        private static MapGenerator map;
        private static Position playerPos;
        private static int world = 1;

        public void Run()
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            //   DrawImg.Draw(@"..\..\Images\menu.jpg", "");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1 ---> New Game \n2 ---> Load Game \nOr type Exit for quit");
            string inputParams = Console.ReadLine();
            Console.Clear();
            ExecuteMainMenu(inputParams);
        }

        private static void ExecuteMainMenu(string inputParams)
        {
            switch (inputParams)
            {
                case "1":
                    Console.WriteLine("Please enter type of Hero and his/her name");
                    DisplayAveilabeHeroes();
                    NewGame();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default: throw new Exception("Invalid Command");
            }
        }

        private static void MainMenuUserInput()
        {
            bool isValid = false;
            string[] userParams;
            while (!isValid)
            {
                userParams = SplitUserInput(Console.ReadLine().Trim());
                if (player == null && EngineConst.TypeOfHeroes.Contains(userParams[0].ToLower()))
                {
                    isValid = true;
                    map = GenerateMapByWord();
                    CreatePlayer(userParams);
                }

                if (userParams.Contains("exit"))
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                }

                if (!isValid && !userParams.Contains("exit"))
                {
                    Console.Clear();
                    Console.WriteLine("Ivalid input.");
                    DisplayAveilabeHeroes();
                    Console.WriteLine("Please enter: [hero type] [name]");
                }
            }
        }

        private static void CreatePlayer(string[] inputParams)
        {
            switch (inputParams[0].ToLower())
            {
                case "mage":
                    player = new Mage(inputParams[1]);
                    break;

                case "amazon":
                    player = new Amazon(inputParams[1]);
                    break;

                case "druid":
                    player = new Druid(inputParams[1]);
                    break;

                case "barbarian":
                    player = new Barbarian(inputParams[1]);
                    break;

                default:
                    break;
            }

            string playerType = player.GetType().ToString().Replace("Game.Characters.", string.Empty);
            Console.Clear();
            Console.WriteLine("A new {0} has been created. His name is {1}", playerType, (player as GameObject).Id);
        }

        private static void DisplayAveilabeHeroes()
        {
            Console.WriteLine("Please choose hero type:");
            for (int i = 0; i < EngineConst.TypeOfHeroes.Length; i++)
            {
                Console.WriteLine("{0} --> {1}", EngineConst.TypeOfHeroes[i], EngineConst.HeroDesc[i]);
            }
        }

        private static void LoadGame()
        {
            throw new NotImplementedException();
        }

        private static string[] SplitUserInput(string input)
        {
            string[] userParams = input.Split(' ');
            return userParams;
        }

        private static void NewGame()
        {
            MainMenuUserInput();
            SetPlayerPos();
            ExecuteCommand();
        }

        private static void SetPlayerPos()
        {
            map.PrintMap();
            for (int i = 0; i < map.Size; i++)
            {
                for (int j = 0; j < map.Size; j++)
                {
                    if (map.Map[i, j] == 'P')
                    {
                        playerPos.Y = j;
                        playerPos.X = i;
                    }
                }
            }
        }

        private static void ExecuteCommand()
        {
            while (true)
            {
                string[] inputParams = SplitUserInput(Console.ReadLine());
                switch (inputParams[0])
                {
                    case "exit": Environment.Exit(0);
                        break;
                    case "display":
                        DisplaySurroundings();
                        break;
                    case "move":
                        Move(inputParams[1]);
                        break;
                    case "help":
                        DisplayCommands();
                        break;
                    default:
                        Console.WriteLine("invalid direction.");
                        break;
                }
            }
        }

        private static void DisplayCommands()
        {
            throw new NotImplementedException();
        }

        private static void DisplaySurroundings()
        {
            int x = playerPos.X;
            int y = playerPos.Y;

            if (y == 0 && x != 0 && x != map.Size - 1)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: Wall");
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (y == map.Size - 1 && x != 0 && x != map.Size - 1)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: wall");
            }
            else if (x == 0 && y != 0 && y != map.Size - 1)
            {
                Console.WriteLine("Up: wall");
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (x == map.Size - 1 && y != 0 && y != map.Size - 1)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: wall");
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (x == map.Size - 1 && y == map.Size - 1)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: wall");
                Console.WriteLine("Lelft: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: wall");
            }
            else if (x == map.Size - 1 && y == 0)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: wall");
                Console.WriteLine("Left: wall");
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (x == 0 && y == map.Size - 1)
            {
                Console.WriteLine("Up: wall");
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: wall");
            }
            else if (x == 0 && y == 0)
            {
                Console.WriteLine("Up: wall");
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: wall");
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
        }

        private static string PrintGameObjectPosition(char mapChar)
        {
            switch (mapChar)
            {
                case 'H':
                    return "Shop";

                case 'e':
                    return "Grass";

                case 'B':
                    return "Big Boss";

                case 'm':
                    return "Mana well";

                case 'M':
                    return "Minion";

                case 'h':
                    return "Health well";

                case 'c':
                    return "Chest";
            }

            return null;
        }

        private static void Move(string direction)
        {
            Console.WriteLine("X = " + playerPos.X);
            Console.WriteLine("Y = " + playerPos.Y);
            switch (direction)
            {
                case "left":
                    MoveLeft();
                    break;

                case "right":
                    MoveRight();
                    break;

                case "up":
                    MoveUp();
                    break;

                case "down":
                    MoveDown();
                    break;
                default:
                    //todo
                    Console.WriteLine("invalid direction please try again");
                    break;
            }
        }

        private static void MoveUp()
        {
            if (playerPos.X <= 0)
            {
                Console.WriteLine("wall");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X - 1, playerPos.Y];
                ProceedMapElement(currmapChar);
                if (currmapChar == 'M')
                {
                    map.Map[playerPos.X - 1, playerPos.Y] = 'e';
                }

                map.Map[playerPos.X - 1, playerPos.Y] = 'e';
                map.PrintMap();
                playerPos.X--;
            }
        }

        private static void MoveDown()
        {
            if (playerPos.X > map.Size - 2)
            {
                Console.WriteLine("wall");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X + 1, playerPos.Y];
                ProceedMapElement(currmapChar);
                if (currmapChar == 'M')
                {
                    map.Map[playerPos.X + 1, playerPos.Y] = 'e';
                }

                map.Map[playerPos.X + 1, playerPos.Y] = '*';
                map.PrintMap();
                playerPos.X++;
            }
        }

        private static void MoveLeft()
        {
            if (playerPos.Y <= 0)
            {
                Console.WriteLine("wall");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X, playerPos.Y - 1];
                ProceedMapElement(currmapChar);
                if (currmapChar == 'M')
                {
                    map.Map[playerPos.X, playerPos.Y - 1] = 'e';
                }

                map.Map[playerPos.X, playerPos.Y - 1] = '*';

                map.PrintMap();
                playerPos.Y--;
            }
        }

        private static void MoveRight()
        {
            if (playerPos.Y >= map.Size - 1)
            {
                Console.WriteLine("wall");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X, playerPos.Y + 1];
                ProceedMapElement(currmapChar);
                if (currmapChar == 'M')
                {
                    map.Map[playerPos.X, playerPos.Y + 1] = 'e';
                }

                map.Map[playerPos.X, playerPos.Y + 1] = '*';
                map.PrintMap();
                playerPos.Y++;
            }
        }

        private static void ProceedMapElement(char currmapChar)
        {
            switch (currmapChar)
            {
                case 'H': Shop();
                    break;
                case 'm': UseManaWell();
                    break;
                case 'h': UseHealthWell();
                    break;
                case 'M': FightMinions();
                    break;
                case 'B':
                    FightBoss();
                    break;

                default: break;
            }
        }

        private static void FightBoss()
        {
            world++;
        }

        private static void FightMinions()
        {
            Console.WriteLine("fight");
        }

        private static void UseHealthWell()
        {
            Console.WriteLine("health using");
        }

        private static void UseManaWell()
        {
            Console.WriteLine("mana well");
        }

        private static void Shop()
        {
            Console.WriteLine("you are in the shop");
        }

        private static MapGenerator GenerateMapByWord()
        {
            Random random = new Random();
            int size = 5 * random.Next(world, world * 5);
            int healtWellCount = random.Next(world + 1, world * 5);
            int manaWellCount = random.Next(world, world * 4);
            int chestCount = random.Next(world, world * (5 - 2));
            int minionCount = random.Next(world * 2, world * 4);
            var map = new MapGenerator(size, healtWellCount, manaWellCount, chestCount, minionCount);
            return map;
        }
    }
}