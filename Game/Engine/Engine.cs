using System.Collections.Generic;
using System.Deployment.Internal;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Game.Core.Data;
using Game.Enemies;
using Game.Items.ArmorOfDragon;
using Game.Items.ArmorOfGandalf;
using Game.Items.Spells;
using Game.Static;
/////todo 284
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
        //todo change item
        //todo update hero stat when euqip
        //todo Penchev`s methdod for using the potions
        //todo mapCreepChanging 

        private static Player player;
        private static MapGenerator map;
        private static Position playerPos;
        private static int world = 1;
        private static char prevMapElement = 'e';

        public void Run()
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            while (true)
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
                        GenerateMapByWorld();
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

        private static void DisplayAvailableHeroes() //todo MAKE THIS PRETIER
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
                        Console.Clear();
                        PrintTextSlowedDown("Goodbye");
                        PlayAudio.YouPussy();
                        Environment.Exit(0);
                        break;

                    case "display-area":
                        Console.Clear();
                        DisplaySurroundings();
                        break;

                    case "stats":
                        Console.Clear();
                        PrintTextSlowedDown(GetPlayerStats());
                        break;

                    case "items":
                        Console.Clear();
                        player.Inventory.ForEach(n => Console.WriteLine(n.Id));
                        break;

                    case "inventory":
                        Console.Clear();
                        Inventory();
                        break;

                    case "move":
                        Console.Clear();
                        Move(inputParams[1]);
                        break;

                    case "help":
                        Console.Clear();
                        DisplayCommands();
                        break;

                    case "print":
                        Console.Clear();
                        map.PrintMap();
                        break;

                    default:
                        Console.Clear();
                        PrintTextSlowedDown("Invalid command.");
                        DisplayCommands();
                        break;
                }
            }
        }

        private static void Inventory()
        {
            PrintInventory();
            while (true)
            {
                PrintInventoryCommands();
                string[] inputParams = Console.ReadLine().Split();
                string command = inputParams[0];
                int index;
                if (command.ToLower().Contains("inspect"))
                {
                    index = int.Parse(inputParams[1]);
                    if (index >= 0 && index < player.Inventory.Count)
                    {
                        PrintTextSlowedDown(player.Inventory[index].ToString());
                    }
                    else
                    {
                        PrintTextSlowedDown("Invalid item index.");
                    }
                }
                else if (command.ToLower().Contains("remove"))
                {
                    index = int.Parse(inputParams[1]);
                    if (index >= 0 && index < player.Inventory.Count)
                    {
                        player.RemoveItem(player.Inventory[index]);
                    }
                    else
                    {
                        PrintTextSlowedDown("Invalid item index.");
                    }
                }
                else if (command.ToLower() == "equip")
                {
                    index = int.Parse(inputParams[1]);
                    if (index >= 0 && index < player.Inventory.Count)
                    {
                        Item item = player.Inventory[index];
                        if (item is Weapon || item is Armor)
                        {
                            player.EquipItem(item);
                            PrintTextSlowedDown(item.Id + " is now equiped.");
                        }
                        else
                        {
                            PrintTextSlowedDown("You can not equip that item.");
                        }
                    }
                    else
                    {
                        PrintTextSlowedDown("Invalid item index.");
                    }
                }
                else if (command.ToLower() == "unequip")
                {
                    index = int.Parse(inputParams[1]);
                    if (index >= 0 && index < player.Inventory.Count)
                    {
                        Item item = player.Inventory[index];
                        if (item is Weapon || item is Armor)
                        {
                            player.UnequipItem(item);
                            PrintTextSlowedDown(item.Id + " is now unequiped.");
                        }
                        else
                        {
                            PrintTextSlowedDown("You can not unequip that item.");
                        }
                    }
                    else
                    {
                        PrintTextSlowedDown("Invalid item index.");
                    }
                }
                else if (command.ToLower().Contains("print"))
                {
                    PrintInventory();
                }
                else if (command.Contains("exit"))
                {
                    Console.Clear();
                    PrintTextSlowedDown("Inventory menu is closed.");
                    break;
                }
            }
        }

        private static void PrintInventoryCommands()
        {
            PrintTextSlowedDown("Available Commands:");
            PrintTextSlowedDown("inspect [index]");
            PrintTextSlowedDown("equip [index]");
            PrintTextSlowedDown("remove [index]");
            PrintTextSlowedDown("print");
            PrintTextSlowedDown("exit");
        }

        private static string GetPlayerStats()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Name: {0} Level: {1} Experience: {2}\n", player.Id, player.Level, player.Experience);
            builder.AppendFormat("Attack: {0} Defence: {1} Health: {2} Mana {3}\n",
                                  player.AttackPoints, player.DefensePoints, player.HealthPoints, player.Mana);
            builder.AppendFormat("All Ressistance: {0}\n", player.AllResistance);
            builder.AppendFormat("Attack Speed: {0}\n", player.AttackSpeed);
            builder.AppendFormat("Chance to Dodge: {0}\n", player.ChanceToDodge);
            builder.AppendFormat("Critical Chance: {0}\n", player.CriticalChance);
            builder.AppendFormat("Critical Damage: {0}\n", player.CritDamage);
            builder.AppendFormat("Kills Counter = {0}\n", player.KillCounter);
            builder.AppendFormat("Gold Available = {0}\n", player.Gold);
            return builder.ToString();
        }

        private static void PrintInventory()
        {
            if (player.Inventory.Count == 0)
            {
                PrintTextSlowedDown("Your Inventory is Empty.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0}", new String('-', 10));
                PrintTextSlowedDown("I-N-V-E-N-T-O-R-Y");
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    Console.WriteLine("{0} ---> {1}", player.Inventory[i].Id, i);
                }
                Console.WriteLine("{0}", new String('-', 10));
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
            PrintTextSlowedDown("inventory");
            PrintTextSlowedDown("items");
            PrintTextSlowedDown("stats");
            PrintTextSlowedDown("help");
            PrintTextSlowedDown("print");
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

                case 'O':
                    return "Mob";
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
                    InteractWithMinions();
                    break;

                case 'B':
                    InteractWithBoss();
                    break;

                case 'O':
                    InteractWithMob();
                    break;
            }
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
                player.UpdateInventorySpace();
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
            chest.Items.AddRange(itemGenerator.ItemsList);
            PrintTextSlowedDown("The chest has droped " + chest.Items.Count() + " items.");
            player.PickUpItem(chest.Items);
        }

        private static void InteractWithBoss()
        {
            PlayAudio.YouAreFucked(); // AUDIO TEST
            PrintTextSlowedDown("You have encountered a BOSS!");
            PrintTextSlowedDown("Do you want to fight?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                RandomEnemyGenerator enemyGenerator = new RandomEnemyGenerator(player.Level, 'B');
                List<Enemy> bosses = enemyGenerator.EnemiesList;
                BattleEngine battleEngine = new BattleEngine(player, bosses);
                battleEngine.Run();
                world++;
                player.CalculateLevelByExperience();
            }
            else
            {
                PlayAudio.Laugh();
                PlayAudio.YouPussy();
                PrintTextSlowedDown("You will live to fight another day, you coward!");
            }
        }

        private static void InteractWithMinions()
        {
            PlayAudio.YouAreFucked(); // AUDIO TEST
            PrintTextSlowedDown("You have encountered a Minion!");
            PrintTextSlowedDown("Do you want to fight?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                RandomEnemyGenerator enemyGenerator = new RandomEnemyGenerator(player.Level, 'M');
                List<Enemy> minions = enemyGenerator.EnemiesList;
                BattleEngine battleEngine = new BattleEngine(player, minions);
                battleEngine.Run();
                player.CalculateLevelByExperience();
            }
            else
            {
                PlayAudio.Laugh();
                PlayAudio.YouPussy();
                PrintTextSlowedDown("You will live to fight another day, you coward!");
            }
        }

        private static void InteractWithMob()
        {
            PlayAudio.YouAreFucked(); // AUDIO TEST
            PrintTextSlowedDown("You have encountered a Mob!");
            PrintTextSlowedDown("Do you want to fight?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                RandomEnemyGenerator mobGenerator = new RandomEnemyGenerator(player.Level, 'O');
                List<Enemy> mob = mobGenerator.EnemiesList;
                BattleEngine battleEngine = new BattleEngine(player, mob);
                battleEngine.Run();
                player.CalculateLevelByExperience();
            }
            else
            {
                PlayAudio.Laugh();
                PlayAudio.YouPussy();
                PrintTextSlowedDown("You will live to fight another day, you coward!");
            }
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
            ////todo SHOOOOOOOOOOP
        }

        public static void GenerateMapByWorld()
        {
            //todo
            Random random = new Random();
            int size = 8 * random.Next(world, world * 5);
            int healtWellCount = random.Next(world + 1, world * 5);
            int manaWellCount = random.Next(world, world * 4);
            int chestCount = random.Next(world, world * (5 - 2));
            int minionCount = random.Next(world * 2, world * 4);
            int mobCount = world;
            var generatedMap = new MapGenerator(size, healtWellCount, manaWellCount, chestCount, minionCount, mobCount);
            map = generatedMap;
        }
    }
}