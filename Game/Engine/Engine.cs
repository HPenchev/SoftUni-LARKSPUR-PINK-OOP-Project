using System;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using Game.Characters;
using Game.Core;
using Game.Core.Data.Constants.EngineConstants;
using Game.Interfaces;

namespace Game.Engine
{
    public class Engine
    {
        private static ICharacter player;
        private static MapGenerator map;
        private static Position playerPos;
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
                    map = new MapGenerator(10, 5, 3, 2, 2);
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
            string playerType = player.GetType().ToString().Replace("Game.Characters.", "");
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
            setPlayerPos();
            ExecuteCommand();
        }

        private static void setPlayerPos()
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
                }
            }
        }

        private static void DisplaySurroundings()
        {
            int x = playerPos.X;
            int y = playerPos.Y;
            //todo validation
            Console.WriteLine("RIGHT {0}", PrintGameGameObjectPosition(map.Map[x, y + 1])); //right
            Console.WriteLine("LEFT {0}", PrintGameGameObjectPosition(map.Map[x, y - 1])); //left
            Console.WriteLine("UP {0}", PrintGameGameObjectPosition(map.Map[x - 1, y])); //up
            Console.WriteLine("DOWN {0}", PrintGameGameObjectPosition(map.Map[x + 1, y])); //down
            PrintGameGameObjectPosition('a');
        }

        private static string PrintGameGameObjectPosition(char mapChar)
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
                    break;
                case 'c':
                    return "Chest";

            }
            return null;
        }
        private bool CheckForBounds(int indexX, int indexY)
        {
            return true;
        }

        private static void Move(string direction)
        {
            Console.WriteLine(playerPos.X);
            Console.WriteLine(playerPos.Y);
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

        private static void MoveDown()
        {
            if (map.Map[playerPos.X + 1, playerPos.Y] == 'e')
            {
                map.Map[playerPos.X, playerPos.Y] = 'e';
                playerPos.X++;
            }
            if (map.Map[playerPos.X + 1, playerPos.Y] == 'H')
            {
                Shop();
                playerPos.X++;
            }
            if (map.Map[playerPos.X + 1, playerPos.Y] == 'm')
            {
                useManaWell();
                playerPos.X++;
            }
            if (map.Map[playerPos.X + 1, playerPos.Y] == 'h')
            {
                useHealthWell();
                playerPos.X++;
            }
            if (map.Map[playerPos.X + 1, playerPos.Y] == 'M')
            {
                fightMinions();
                //todo double check
                playerPos.X++;
                map.Map[playerPos.X, playerPos.Y] = 'e';
            }
        }

        private static void MoveUp()
        {
            if (map.Map[playerPos.X - 1, playerPos.Y] == 'e')
            {
                map.Map[playerPos.X, playerPos.Y] = 'e';
                playerPos.X--;
            }
            if (map.Map[playerPos.X - 1, playerPos.Y] == 'H')
            {
                Shop();
                playerPos.X--;
            }
            if (map.Map[playerPos.X - 1, playerPos.Y] == 'm')
            {
                useManaWell();
                playerPos.X--;
            }
            if (map.Map[playerPos.X - 1, playerPos.Y] == 'h')
            {
                useHealthWell();
                playerPos.X--;
            }
            if (map.Map[playerPos.X - 1, playerPos.Y] == 'M')
            {
                fightMinions();
                playerPos.X--;
                map.Map[playerPos.X, playerPos.Y] = 'e';
            }
        }

        private static void MoveRight()
        {
            if (playerPos.Y > map.Size - 1)
            {
                Console.WriteLine("wall");
            }
            else
            {
                map.Map[playerPos.X, playerPos.Y + 1] = '*';
                map.PrintMap();
                playerPos.Y++;

            }
            //if (map.Map[playerPos.X, playerPos.Y + 1] == 'e')
            //{
            //    map.Map[playerPos.X, playerPos.Y] = 'e';
            //    playerPos.Y++;
            //}
            //if (map.Map[playerPos.X, playerPos.Y + 1] == 'H')
            //{
            //    Shop();
            //    playerPos.Y++;
            //}
            //if (map.Map[playerPos.X, playerPos.Y + 1] == 'm')
            //{
            //    useManaWell();
            //    playerPos.Y++;
            //}
            //if (map.Map[playerPos.X, playerPos.Y + 1] == 'h')
            //{
            //    useHealthWell();
            //    playerPos.Y++;
            //}
            //if (map.Map[playerPos.X, playerPos.Y + 1] == 'M')
            //{
            //    fightMinions();

            //    playerPos.Y++;
            //    map.Map[playerPos.X, playerPos.Y] = 'e';
            //}
        }

        private static void MoveLeft()
        {
            if (map.Map[playerPos.X, playerPos.Y - 1] == 'e')
            {
                map.Map[playerPos.X, playerPos.Y] = 'e';
                playerPos.Y--;
            }
            if (map.Map[playerPos.X, playerPos.Y - 1] == 'H')
            {
                Shop();
                playerPos.Y--;
            }
            if (map.Map[playerPos.X, playerPos.Y - 1] == 'm')
            {
                useManaWell();
                playerPos.Y--;
            }
            if (map.Map[playerPos.X, playerPos.Y - 1] == 'h')
            {
                useHealthWell();
                playerPos.Y--;
            }
            if (map.Map[playerPos.X, playerPos.Y - 1] == 'M')
            {
                fightMinions();
                playerPos.Y--;
                map.Map[playerPos.X, playerPos.Y] = 'e';
            }
        }

        private static void fightMinions()
        {
            Console.WriteLine("fight");
        }

        private static void useHealthWell()
        {
            Console.WriteLine("health using");
        }

        private static void useManaWell()
        {
            Console.WriteLine("mana well");
        }

        private static void Shop()
        {
            Console.WriteLine("you are in the shop");
        }
    }
}
