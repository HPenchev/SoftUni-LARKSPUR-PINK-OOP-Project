using System;
using Game.Characters;
using Game.Core;
using Game.Core.Data.Constants.EngineConstants;
using Game.Interfaces;

namespace Game.Engine
{
    public class Engine
    {
        public static ICharacter player;
        private bool isInBattle;
        private bool isInTown;

        public static void Run()
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            //   DrawImg.Draw(@"..\..\Images\menu.jpg", "");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1 ---> New Game \n2 ---> Load Game \nOr type Exit for quit");
            string inputParams = Console.ReadLine();
            ExecuteMainMenu(inputParams);
        }

        private static void ExecuteMainMenu(string inputParams)
        {
            switch (inputParams)
            {
                case "1":
                    Console.WriteLine("Please enter type of Hero and his/her name");
                    DisplayAveilabeHeroes(); NewGame();
                    break;
                case "2":
                    LoadGame();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                //to do ex
                default: throw new Exception("Invalid Command");
            }
        }

        private static void DisplayAveilabeHeroes()
        {
            Console.Write("Please choose hero type:  ");
            // EngineConst.TypeOfHeroes.ToList().ForEach(n => Console.Write(n + "or"));
            string heroType = String.Join(" or ", EngineConst.TypeOfHeroes);
            Console.WriteLine(heroType);
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
            ReadUserInput();
        }
        private static void ReadUserInput()
        {
            while (true)
            {
                string inputLine = Console.ReadLine().Trim();

                if (player == null)
                {
                    CreatePlayer(SplitUserInput(inputLine));
                }
                if (inputLine.Equals("exit"))
                {
                    Environment.Exit(0);
                }
                ExecuteCommand(inputLine);
            }
        }

        private static void ExecuteCommand(string inputLine)
        {
            string[] inputParams = SplitUserInput(inputLine);

        }

        private static void CreatePlayer(string[] inputParams)
        {
            if (inputParams.Length > 2)
            {
                //todo
                throw new ArgumentException();
            }
            switch (inputParams[0])
            {
                //todo constatns
                case "mage": player = new Mage(inputParams[1]);
                    break;
                //todo
                default: throw new Exception();
                //case "range" : player = new 
            }
            string playerType = player.GetType().ToString().Replace("Game.Characters.", "");
            Console.WriteLine("A new {0} has been created. His name is {1}", playerType, (player as GameObject).Id);
            Console.WriteLine(player.ToString());
        }
    }
}
