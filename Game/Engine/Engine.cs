using System.Runtime.CompilerServices;
using Game.Items.ArmorOfGandalf;
using Game.Static;

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
        //todo map showing ??
        //todo map testing
        //todo map update - wells chests, new minions
        private static Player player;
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
            Console.WriteLine("1 ---> New Game\n2 ---> Load Game");
            string inputParams = Console.ReadLine();
            Console.Clear();
            ExecuteMainMenu(inputParams);
        }

        private static void ExecuteMainMenu(string inputParams)
        {
            switch (inputParams)
            {
                case "1":
                    Console.WriteLine("Please enter Hero class and the Hero's name.");
                    DisplayAveilabeHeroes();
                    NewGame();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "exit":
                    Console.WriteLine("Goodbye.");
                    Environment.Exit(0);
                    break;
                default: throw new Exception("Invalid command.");
            }
        }

        //todo shop generate
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
                    GenerateMapByWord();
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
                    Console.WriteLine("Invalid input.");
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
            for (int i = 0; i < EngineConst.TypeOfHeroes.Length; i++)
            {
                Console.WriteLine("{0} -------> {1}", EngineConst.TypeOfHeroes[i], EngineConst.HeroDesc[i]);
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
                    case "exit":
                        Environment.Exit(0);
                        break;

                    case "display-area":
                        DisplaySurroundings();
                        break;

                    case "stats":
                        Console.WriteLine(player.ToString());
                        break;

                    case "items":
                        player.Inventory.ForEach(n => Console.WriteLine(n.ToString()));
                        break;

                    case "move":
                        Move(inputParams[1]);
                        break;

                    case "help":
                        DisplayCommands();
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
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
                Console.WriteLine("Left: Sea");
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (y == map.Size - 1 && x != 0 && x != map.Size - 1)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: Sea");
            }
            else if (x == 0 && y != 0 && y != map.Size - 1)
            {
                Console.WriteLine("Up: Sea");
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (x == map.Size - 1 && y != 0 && y != map.Size - 1)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: Sea");
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (x == map.Size - 1 && y == map.Size - 1)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: Sea");
                Console.WriteLine("Lelft: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: Sea");
            }
            else if (x == map.Size - 1 && y == 0)
            {
                Console.WriteLine("Up: {0}", PrintGameObjectPosition(map.Map[x - 1, y]));
                Console.WriteLine("Down: Sea");
                Console.WriteLine("Left: Sea");
                Console.WriteLine("Right: {0}", PrintGameObjectPosition(map.Map[x, y + 1]));
            }
            else if (x == 0 && y == map.Size - 1)
            {
                Console.WriteLine("Up: Sea");
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: {0}", PrintGameObjectPosition(map.Map[x, y - 1]));
                Console.WriteLine("Right: Sea");
            }
            else if (x == 0 && y == 0)
            {
                Console.WriteLine("Up: Sea");
                Console.WriteLine("Down: {0}", PrintGameObjectPosition(map.Map[x + 1, y]));
                Console.WriteLine("Left: Sea");
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
                    Console.WriteLine("Invalid direction. Please try again.");
                    break;
            }
        }

        private static void MoveUp()
        {
            if (playerPos.X <= 0)
            {
                Console.WriteLine("There is only the vast ocean in front of you.\nYou shall not pass.");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X - 1, playerPos.Y];
                ProceedMapElement(currmapChar); 
                if (currmapChar == 'M') // if currmapChar != e INTERACT(  ProceedMapElement  )
                {
                    map.Map[playerPos.X - 1, playerPos.Y] = 'e';
                }

                map.Map[playerPos.X - 1, playerPos.Y] = 'P';
                map.Map[playerPos.X, playerPos.Y] = currmapChar; //// return the original element to the map
                map.PrintMap();                                  //// need to check
                playerPos.X--;
            }
        }

        private static void MoveDown()
        {
            if (playerPos.X > map.Size - 2)
            {
                Console.WriteLine("There is only the vast ocean in front of you.\nYou shall not pass.");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X + 1, playerPos.Y];
                ProceedMapElement(currmapChar);
                if (currmapChar == 'M')
                {
                    map.Map[playerPos.X + 1, playerPos.Y] = 'e';
                }

                map.Map[playerPos.X + 1, playerPos.Y] = 'P';
                map.Map[playerPos.X, playerPos.Y] = currmapChar;
                map.PrintMap();
                playerPos.X++;
            }
        }

        private static void MoveLeft()
        {
            if (playerPos.Y <= 0)
            {
                Console.WriteLine("There is only the vast ocean in front of you.\nYou shall not pass.");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X, playerPos.Y - 1];
                ProceedMapElement(currmapChar);
                if (currmapChar == 'M')
                {
                    map.Map[playerPos.X, playerPos.Y - 1] = 'e';
                }

                map.Map[playerPos.X, playerPos.Y - 1] = 'P';
                map.Map[playerPos.X, playerPos.Y] = currmapChar;
                map.PrintMap();
                playerPos.Y--;
            }
        }

        private static void MoveRight()
        {
            if (playerPos.Y >= map.Size - 1)
            {
                Console.WriteLine("There is only the vast ocean in front of you.\nYou shall not pass.");
            }
            else
            {
                char currmapChar = map.Map[playerPos.X, playerPos.Y + 1];
                ProceedMapElement(currmapChar);
                if (currmapChar == 'M')
                {
                    map.Map[playerPos.X, playerPos.Y + 1] = 'e';
                }

                map.Map[playerPos.X, playerPos.Y + 1] = 'P';
                map.Map[playerPos.X, playerPos.Y] = currmapChar;
                map.PrintMap();
                playerPos.Y++;
            }
        }

        private static void ProceedMapElement(char currmapChar)
        {
            switch (currmapChar)
            {
                case 'H':
                    Shop();
                    break;

                case 'c':
                    UseChest();
                    break;

                case 'm': 
                    UseManaWell();
                    break;

                case 'h':
                    UseHealthWell();
                    break;

                case 'M': 
                    FightMinions();
                    break;

                case 'B':
                    FightBoss();
                    break;

                default: 
                    break;
            }
        }

        private static void UseChest()
        {
            Console.WriteLine("Chest found.");
        }

        private static void FightBoss()
        {
            Console.WriteLine("BOSS!!!!");
            world++;
        }

        private static void FightMinions()
        {
            Console.WriteLine("Fight");
        }

        private static void UseHealthWell()
        {
            HealthWell well = new HealthWell(DateTime.Now.ToString());
            if (well.IsUsed)
            {
                Console.WriteLine("This Health well has been used and It is empty.");
            }
            else
            {
                Console.WriteLine("I feel stronger already.");
                Console.WriteLine("{0} gained {1} health points by using a Health well.", player.Id, well.Health);
                player.HealthPoints += well.Health;
                well.IsUsed = true;
            }
        }

        private static void UseManaWell()
        {
            double wellPoints = ManaWell.UseManaWell();
            if (wellPoints == 0)
            {
                Console.WriteLine("This Mana well has been used and It is empty.");
            }
            else
            {
                Console.WriteLine("I feel more powerful already.");
                Console.WriteLine("{0} gained {1} mana points by using a Mana well.", player.Id, wellPoints);
                player.Mana += wellPoints;
            }
        }

        private static void Shop()
        {
            Console.WriteLine("You are in the Shop!");
        }

        public static void GenerateMapByWord()
        {
            //todo
            Random random = new Random();
            int size = 8 * random.Next(world, world * 5);
            int healtWellCount = random.Next(world + 1, world * 5);
            int manaWellCount = random.Next(world, world * 4);
            int chestCount = random.Next(world, world * (5 - 2));
            int minionCount = random.Next(world * 2, world * 4);
            var generatedMap = new MapGenerator(size, healtWellCount, manaWellCount, chestCount, minionCount);
            map = generatedMap;
        }
    }
}