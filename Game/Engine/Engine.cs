﻿using System.Collections.Generic;
using System.Deployment.Internal;
using System.Runtime.CompilerServices;
using System.Threading;
using Game.Core.Data;
using Game.Items.ArmorOfDragon;
using Game.Items.ArmorOfGandalf;
using Game.Items.Spells;
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
        private static char prevMapElement = 'e';

        public void Run()
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            while(true)
            {
                PrintMainMenu();
                var mainMenuInput = Console.ReadLine();
                Console.Clear();
                if (String.IsNullOrWhiteSpace(mainMenuInput))
                {
                    PrintTextSlowedDown("Invalid Menu Choice.");
                }
                else
                {
                    ExecuteMainMenu(mainMenuInput);    
                }
            }
        }

        private static void PrintMainMenu()
        {
            PrintTextSlowedDown("Please choose an option:");
            PrintTextSlowedDown("1 ---> New Game\n" +
                                "2 ---> Load Game");
        }

        private static void ExecuteMainMenu(string mainMenuInput)
        {
            if (mainMenuInput.Contains("1"))
            {
                PrintTextSlowedDown("Please enter Hero class and the Hero's name. [mage] [Gandalf]");
                DisplayAvailableHeroes();
                NewGame();
            }
            else if (mainMenuInput.Contains("2"))
            {
                LoadGame();
            }
            else if (mainMenuInput.ToLower().Contains("exit"))
            {
                PrintTextSlowedDown("Goodbye.");
                Environment.Exit(0);
            }
        }

        //todo shop generate
        private static void NewGameUserInput()
        {
            bool isValid = false;
            while (!isValid)
            {
                string newGameMenuUserInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newGameMenuUserInput))
                {
                    PrintNewGameMenuInvalidInputMessage();
                }
                else
                {
                    string[] heroParameters = SplitUserInput(newGameMenuUserInput.Trim());
                    if (player == null && heroParameters.Length >= 2 &&
                        EngineConst.TypeOfHeroes.Contains(heroParameters[0].ToLower()))
                    {
                        isValid = true;
                        GenerateMapByWord();
                        CreatePlayer(heroParameters);
                    }

                    if (heroParameters.Contains("exit"))
                    {
                        Console.WriteLine();
                        PrintTextSlowedDown("Goodbye");
                        Environment.Exit(0);
                    }

                    if (!isValid && !heroParameters.Contains("exit"))
                    {
                        PrintNewGameMenuInvalidInputMessage();
                    }
                }
            }
        }

        private static void PrintNewGameMenuInvalidInputMessage()
        {
            Console.Clear();
            PrintTextSlowedDown("Invalid input.");
            PrintTextSlowedDown("Please enter: [hero type] [name]");
            DisplayAvailableHeroes();
            Console.WriteLine();
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

        private static void DisplayAvailableHeroes()
        {
            for (int i = 0; i < EngineConst.TypeOfHeroes.Length; i++)
            {
                PrintTextSlowedDown(String.Format("{0}", EngineConst.TypeOfHeroes[i]));
                PrintTextSlowedDown(EngineConst.HeroDesc[i]);
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
            NewGameUserInput();
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
                switch (inputParams[0].ToLower())
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

                    case "print": // OR A SCROLL WHICH WILL SHOW THE MAP ONE TIME 
                        map.PrintMap();
                        break;

                    default:
                        PrintTextSlowedDown("Invalid command.");
                        break;
                }
            }
        }

        private static void DisplayCommands()
        {
            Console.WriteLine();
            Console.WriteLine("{0}", new string('-', 10));
            PrintTextSlowedDown("move up");
            PrintTextSlowedDown("move left");
            PrintTextSlowedDown("move down");
            PrintTextSlowedDown("move left");
            PrintTextSlowedDown("display-area");
            PrintTextSlowedDown("items");
            PrintTextSlowedDown("stats");
            PrintTextSlowedDown("help");
            PrintTextSlowedDown("exit");
            Console.WriteLine("{0}", new string('-', 10));
            Console.WriteLine();
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
            Console.WriteLine("X = " + playerPos.X); //// TEST OUTPUT
            Console.WriteLine("Y = " + playerPos.Y); //// TEST OUTPUT
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
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPos.X - 1, playerPos.Y];
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPos.X, playerPos.Y] = prevMapElement;
                prevMapElement = map.Map[playerPos.X - 1, playerPos.Y];
                map.Map[playerPos.X - 1, playerPos.Y] = 'P';
                playerPos.X--;
                map.PrintMap();
                Console.WriteLine();
            }
        }

        private static void MoveDown()
        {
            if (playerPos.X > map.Size - 2)
            {
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPos.X + 1, playerPos.Y];
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPos.X, playerPos.Y] = prevMapElement;
                prevMapElement = map.Map[playerPos.X + 1, playerPos.Y];
                map.Map[playerPos.X + 1, playerPos.Y] = 'P';
                map.PrintMap();
                Console.WriteLine();
                playerPos.X++;
            }
        }

        private static void MoveLeft()
        {
            if (playerPos.Y <= 0)
            {
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPos.X, playerPos.Y - 1];
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPos.X, playerPos.Y] = prevMapElement;
                prevMapElement = map.Map[playerPos.X, playerPos.Y - 1];
                map.Map[playerPos.X, playerPos.Y - 1] = 'P';
                playerPos.Y--;
                map.PrintMap();
                Console.WriteLine();
            }
        }

        private static void MoveRight()
        {
            if (playerPos.Y >= map.Size - 1)
            {
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPos.X, playerPos.Y + 1];
                Console.WriteLine(currentMapObject);
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPos.X, playerPos.Y] = prevMapElement;
                prevMapElement = map.Map[playerPos.X, playerPos.Y + 1];
                map.Map[playerPos.X, playerPos.Y + 1] = 'P';
                playerPos.Y++;
                map.PrintMap();
                Console.WriteLine();
            }
        }

        private static void PrintMapBoarderReachedMessage()
        {
            Console.Beep(100, 100);
            //// !!!!COUPLING!!!! or Console.ReadLine();
            PrintTextSlowedDown("There is only the vast ocean in front of you.\nYou shall not pass.");
        }

        private static void ProceesMapElement(char currmapChar)
        {
            switch (currmapChar)
            {
                case 'H':
                    Shop();
                    break;

                case 'c':
                    InteractWithChest();
                    break;

                case 'm':
                    InteractWithManaWell();
                    break;

                case 'h':
                    InteractWithHealthWell();
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
            map.PrintMap();
        }

        private static void InteractWithHealthWell()
        {
            PlayAudio.YouLuckyBastard(); // AUDIO TEST
            PrintTextSlowedDown("You lucky bastard...");
            PrintTextSlowedDown("You have stumbled upon a Health Well.");
            PrintTextSlowedDown("Do you want to drink from it?");
            string answer = Console.ReadLine();
            if (answer.ToLower().Contains("yes"))
            {
                UseHealthWell();
                //todo UPDATE PLAYER POSITION
            }
            else
            {
                PrintTextSlowedDown("Good choice, this health well can be useful later on.");
            }
            Console.WriteLine();
        }

        private static void InteractWithManaWell()
        {
            PlayAudio.YouLuckyBastard();  // AUDIO TEST
            PrintTextSlowedDown("You lucky bastard...");
            PrintTextSlowedDown("You have stumbled upon a Mana Well.");
            PrintTextSlowedDown("Do you want to drink from it?");
            string answer = Console.ReadLine();
            if (answer.ToLower().Contains("yes"))
            {
                UseManaWell();
                //todo UPDATE PLAYER POSITION
            }
            else
            {
                PrintTextSlowedDown("Good choice, this mana well can be useful later on.");
            }
            Console.WriteLine();
        }

        public static void PrintTextSlowedDown(string text)
        {
            ////todo Key Listener, Play music
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < text.Length; i++)
            {
                Thread.Sleep(1);
                Console.Write(text[i]);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void InteractWithChest()
        {
            PlayAudio.YouLuckyBastard();  // AUDIO TEST
            PrintTextSlowedDown("You lucky bastard...");
            PrintTextSlowedDown("You have stumbled upon a Chest.");
            PrintTextSlowedDown("Do you want to open it?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                UseChest();
            }
            else
            {
                PrintTextSlowedDown("Good choice, this chest can be useful later on.");
            }
            Console.WriteLine();
        }


        private static void UseChest()
        {
            Chest chest = new Chest("Chest");
            RandomItemGenerator itemGenerator = new RandomItemGenerator(player.Level);
            chest.Items.AddRange(itemGenerator.List);
            PrintTextSlowedDown("The chest has droped " + chest.Items.Count() + " items.");
            player.PickUpItem(chest.Items);
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
            HealthWell well = new HealthWell(DateTime.Now.Millisecond.ToString());
            if (well.IsUsed)
            {
                PrintTextSlowedDown("This Health well has been used and It is empty.");
                Console.WriteLine();
            }
            else if (player.HealthPoints == player.MaxHealthPoints)
            {
                PrintTextSlowedDown("Your health is full and you can not use that health well.");
                Console.WriteLine();
            }
            else
            {
                player.HealthPoints += well.Health;
                well.IsUsed = true;
                Console.WriteLine("I feel stronger already.");
                Console.WriteLine("{0} gained {1} health points by using a Health well.", player.Id, well.Health);
                Console.WriteLine();
            }
        }

        private static void UseManaWell()
        {
            ManaWell manaWell = new ManaWell(DateTime.Now.Millisecond.ToString());
            if (manaWell.IsUsed)
            {
                Console.WriteLine("This Mana well has been used and It is empty.");
            }
            else
            {
                player.Mana += manaWell.Mana;
                Console.WriteLine("I feel more powerful already.");
                Console.WriteLine("{0} gained {1} mana points by using a Mana well.", player.Id, manaWell.Mana);
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