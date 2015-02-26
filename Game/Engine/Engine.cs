namespace Game.Engine
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using Characters;
    using Core;
    using Core.Data.Constants.EngineConstants;
    using Core.Data;
    using Static;

    [Serializable]
    public class Engine
    {
        #region Fields
        private static Player player;
        private static MapGenerator map;
        private static Position playerPosition;
        private static int world;
        private static char previousMapElement;
        private const string saveFile = "save.dat";
        #endregion

        public void Run()
        {
            MainMenu();
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
                        Print.PrintMessageWithAudio(player.Inventory[index].ToString());
                    }
                    else
                    {
                        Print.PrintMessageWithAudio("Invalid item index.");
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
                        Print.PrintMessageWithAudio("Invalid item index.");
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
                            Print.PrintMessageWithAudio(item.Id + " is now equiped.");
                        }
                        else
                        {
                            Print.PrintMessageWithAudio("You can not equip that item.");
                        }
                    }
                    else
                    {
                        Print.PrintMessageWithAudio("Invalid item index.");
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
                            Print.PrintMessageWithAudio(item.Id + " is now unequiped.");
                        }
                        else
                        {
                            Print.PrintMessageWithAudio("You can not unequip that item.");
                        }
                    }
                    else
                    {
                        Print.PrintMessageWithAudio("Invalid item index.");
                    }
                }
                else if (command.ToLower().Contains("print"))
                {
                    PrintInventory();
                }
                else if (command.Contains("exit"))
                {
                    Console.Clear();
                    Print.PrintMessageWithAudio("Inventory menu is closed.");
                    break;
                }
            }
        }

        #region NewGame
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
                        Print.PrintMessageWithAudio("Goodbye");
                        Environment.Exit(0);
                    }

                    if (!isValid && !heroParameters.Contains("exit"))
                    {
                        PrintNewGameMenuInvalidInputMessage();
                    }
                }
            }
        }

        private static void NewGame()
        {
            world = 1;
            previousMapElement = 'e';
            NewGameUserInput();
            SetPlayerPos();
            ExecuteCommand();
        }
        #endregion

        #region MainMenu
        public static void MainMenu()
        {
            while (true)
            {
                PrintMainMenu();
                var mainMenuInput = Console.ReadLine();
                Console.Clear();
                if (String.IsNullOrWhiteSpace(mainMenuInput))
                {
                    Print.PrintMessageWithAudio("Invalid Menu Choice.");
                }
                else
                {
                    ExecuteMainMenu(mainMenuInput);
                }
            }
        }

        private static void ExecuteMainMenu(string mainMenuInput)
        {
            if (mainMenuInput.Contains("1"))
            {
                Print.PrintMessage("Please enter Hero class and the Hero's name. [mage] [Gandalf]");
                DisplayAvailableHeroes();
                NewGame();
            }
            else if (mainMenuInput.Contains("2"))
            {
                Load();
            }
            else if (mainMenuInput.ToLower().Contains("exit"))
            {
                Print.PrintMessageWithAudio("Goodbye.");
                Environment.Exit(0);
            }
        }
        #endregion

        #region PlayerCreation
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
            }

            string playerType = player.GetType().ToString().Replace("Game.Characters.", string.Empty);
            Console.Clear();
            Print.PrintMessageWithAudio(String.Format("A new {0} has been created. His name is {1}", playerType, (player as GameObject).Id));
        }

        private static string[] SplitUserInput(string input)
        {
            string[] userParams = input.Split(' ');
            return userParams;
        }
        #endregion

        #region Command Exection
        private static void ExecuteCommand()
        {
            while (true)
            {
                string[] inputParams = SplitUserInput(Console.ReadLine());
                switch (inputParams[0].ToLower())
                {
                    case "exit":
                        Console.Clear();
                        Print.PrintMessageWithAudio("Goodbye");
                        PlayAudio.YouPussy();
                        Environment.Exit(0);
                        break;

                    case "display-area":
                        Console.Clear();
                        DisplaySurroundings();
                        break;

                    case "stats":
                        Console.Clear();
                        Print.PrintMessage(GetPlayerStats());
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

                    case "save":
                        Save();
                        break;

                    case "load":
                        Load();
                        break;

                    default:
                        Console.Clear();
                        Print.PrintMessageWithAudio("Invalid command.");
                        DisplayCommands();
                        break;
                }
            }
        }
        #endregion

        #region Movement
        private static void Move(string direction)
        {
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
            if (playerPosition.X <= 0)
            {
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPosition.X - 1, playerPosition.Y];
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPosition.X, playerPosition.Y] = previousMapElement;
                previousMapElement = map.Map[playerPosition.X - 1, playerPosition.Y];
                map.Map[playerPosition.X - 1, playerPosition.Y] = 'P';
                playerPosition.X--;
                map.PrintMap();
                Console.WriteLine();
            }
        }

        private static void MoveDown()
        {
            if (playerPosition.X > map.Size - 2)
            {
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPosition.X + 1, playerPosition.Y];
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPosition.X, playerPosition.Y] = previousMapElement;
                previousMapElement = map.Map[playerPosition.X + 1, playerPosition.Y];
                map.Map[playerPosition.X + 1, playerPosition.Y] = 'P';
                map.PrintMap();
                Console.WriteLine();
                playerPosition.X++;
            }
        }

        private static void MoveLeft()
        {
            if (playerPosition.Y <= 0)
            {
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPosition.X, playerPosition.Y - 1];
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPosition.X, playerPosition.Y] = previousMapElement;
                previousMapElement = map.Map[playerPosition.X, playerPosition.Y - 1];
                map.Map[playerPosition.X, playerPosition.Y - 1] = 'P';
                playerPosition.Y--;
                map.PrintMap();
                Console.WriteLine();
            }
        }

        private static void MoveRight()
        {
            if (playerPosition.Y >= map.Size - 1)
            {
                PrintMapBoarderReachedMessage();
            }
            else
            {
                char currentMapObject = map.Map[playerPosition.X, playerPosition.Y + 1];
                if (currentMapObject != 'e')
                {
                    ProceesMapElement(currentMapObject);
                }

                map.Map[playerPosition.X, playerPosition.Y] = previousMapElement;
                previousMapElement = map.Map[playerPosition.X, playerPosition.Y + 1];
                map.Map[playerPosition.X, playerPosition.Y + 1] = 'P';
                playerPosition.Y++;
                map.PrintMap();
                Console.WriteLine();
            }
        }
        #endregion

        #region Print Messages
        private static void PrintMainMenu()
        {
            Print.PrintMessageWithAudio("Please choose an option:");
            Print.PrintMessage("1 ---> New Game\n" +
                                "2 ---> Load Game");
        }

        private static void PrintNewGameMenuInvalidInputMessage()
        {
            Console.Clear();
            Print.PrintMessageWithAudio("Invalid input.");
            Print.PrintMessage("Please enter: [hero type] [name]");
            DisplayAvailableHeroes();
            Console.WriteLine();
        }

        private static void PrintMapBoarderReachedMessage()
        {
            Console.Beep(100, 100);
            Print.PrintMessageWithAudio("There is only the vast ocean in front of you.\nYou shall not pass.");
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

        private static void PrintInventory()
        {
            if (player.Inventory.Count == 0)
            {
                Print.PrintMessageWithAudio("Your Inventory is Empty.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0}", new String('-', 10));
                Print.PrintMessage("I-N-V-E-N-T-O-R-Y");
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
            Print.PrintMessage("move up");
            Print.PrintMessage("move left");
            Print.PrintMessage("move down");
            Print.PrintMessage("move left");
            Print.PrintMessage("display-area");
            Print.PrintMessage("inventory");
            Print.PrintMessage("items");
            Print.PrintMessage("stats");
            Print.PrintMessage("help");
            Print.PrintMessage("print");
            Print.PrintMessage("exit");
            Console.WriteLine("{0}", new string('-', 10));
            Console.WriteLine();
        }

        private static void DisplaySurroundings()
        {
            int x = playerPosition.X;
            int y = playerPosition.Y;

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

        private static void DisplayAvailableHeroes()
        {
            for (int i = 0; i < EngineConst.TypeOfHeroes.Length; i++)
            {
                Print.PrintMessage(String.Format("{0}", EngineConst.TypeOfHeroes[i]));
                Print.PrintMessage(EngineConst.HeroDesc[i]);
            }
        }

        private static void PrintInventoryCommands()
        {
            Print.PrintMessageWithAudio("Available Commands:");
            Print.PrintMessage("inspect [index]");
            Print.PrintMessage("equip [index]");
            Print.PrintMessage("unequip [index]");
            Print.PrintMessage("remove [index]");
            Print.PrintMessage("print");
            Print.PrintMessage("exit");
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
        #endregion

        #region Enemy Interaction
        private static void InteractWithBoss()
        {
            PlayAudio.YouAreFucked();
            Print.PrintMessageWithAudio("You have encountered a BOSS!");
            Print.PrintMessageWithAudio("Do you want to fight?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                RandomEnemyGenerator enemyGenerator = new RandomEnemyGenerator(player.Level, 'B');
                List<Enemy> bosses = enemyGenerator.EnemiesList;
                BattleEngineV2 battleEngine = new BattleEngineV2(player, bosses);
                battleEngine.Run();
                world++;
                player.CalculateLevelByExperience();

            }
            else
            {
                PlayAudio.Laugh();
                PlayAudio.YouPussy();
                Print.PrintMessageWithAudio("You will live to fight another day, you coward!");
            }
        }

        private static void InteractWithMinions()
        {
            PlayAudio.YouAreFucked();
            Print.PrintMessageWithAudio("You have encountered a Minion!");
            Print.PrintMessageWithAudio("Do you want to fight?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                RandomEnemyGenerator enemyGenerator = new RandomEnemyGenerator(player.Level, 'M');
                List<Enemy> minions = enemyGenerator.EnemiesList;
                BattleEngineV2 battleEngine = new BattleEngineV2(player, minions);
                battleEngine.Run();
                NextWorld();
            }
            else
            {
                PlayAudio.Laugh();
                PlayAudio.YouPussy();
                Print.PrintMessageWithAudio("You will live to fight another day, you coward!");
            }
        }

        private static void InteractWithMob()
        {
            PlayAudio.YouAreFucked();
            Print.PrintMessageWithAudio("You have encountered a Mob!");
            Print.PrintMessageWithAudio("Do you want to fight?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                RandomEnemyGenerator mobGenerator = new RandomEnemyGenerator(player.Level, 'O');
                List<Enemy> mob = mobGenerator.EnemiesList;
                BattleEngineV2 battleEngine = new BattleEngineV2(player, mob);
                battleEngine.Run();
                player.CalculateLevelByExperience();
            }
            else
            {
                PlayAudio.Laugh();
                PlayAudio.YouPussy();
                Print.PrintMessageWithAudio("You will live to fight another day, you coward!");
            }
        }
        #endregion

        #region Chest
        private static void InteractWithChest()
        {
            PlayAudio.YouLuckyBastard(); // AUDIO TEST
            Print.PrintMessageWithAudio("You lucky bastard...");
            Print.PrintMessageWithAudio("You have stumbled upon a Chest.");
            Print.PrintMessageWithAudio("Do you want to open it?");
            string input = Console.ReadLine();
            if (input.ToLower().Contains("yes"))
            {
                UseChest();
                player.UpdateInventorySpace();
            }
            else
            {
                Print.PrintMessageWithAudio("Good choice, this chest can be useful later on.");
            }
            Console.WriteLine();
        }

        private static void UseChest()
        {
            Chest chest = new Chest("Chest");
            RandomItemGenerator itemGenerator = new RandomItemGenerator(player.Level);
            chest.Items.AddRange(itemGenerator.ItemsList);
            Print.PrintMessageWithAudio("The chest has droped " + chest.Items.Count() + " items.");
            player.PickUpItem(chest.Items);
        }
        #endregion

        #region HealthWell
        private static void InteractWithHealthWell()
        {
            PlayAudio.YouLuckyBastard(); // AUDIO TEST
            Print.PrintMessageWithAudio("You lucky bastard...");
            Print.PrintMessageWithAudio("You have stumbled upon a Health Well.");
            Print.PrintMessageWithAudio("Do you want to drink from it?");
            string answer = Console.ReadLine();
            if (answer.ToLower().Contains("yes"))
            {
                UseHealthWell();
            }
            else
            {
                Print.PrintMessageWithAudio("Good choice, this health well can be useful later on.");
            }
            Console.WriteLine();
        }

        private static void UseHealthWell()
        {
            HealthWell well = new HealthWell(DateTime.Now.Millisecond.ToString());
            if (well.IsUsed)
            {
                Print.PrintMessageWithAudio("This Health well has been used and It is empty.");
                Console.WriteLine();
            }
            else if (player.HealthPoints == player.MaxHealthPoints)
            {
                Print.PrintMessageWithAudio("Your health is full and you can not use that health well.");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                player.HealthPoints += well.Health;
                well.IsUsed = true;
                Print.PrintMessageWithAudio("I feel stronger already.");
                Print.PrintMessageWithAudio(String.Format("{0} gained {1} health points by using a Health well.",
                    player.Id, well.Health));
                Console.WriteLine();
            }
        }
        #endregion

        #region ManaWell
        private static void InteractWithManaWell()
        {
            PlayAudio.YouLuckyBastard(); // AUDIO TEST
            Print.PrintMessageWithAudio("You lucky bastard...");
            Print.PrintMessageWithAudio("You have stumbled upon a Mana Well.");
            Print.PrintMessageWithAudio("Do you want to drink from it?");
            string answer = Console.ReadLine();
            if (answer.ToLower().Contains("yes"))
            {
                UseManaWell();
            }
            else
            {
                Print.PrintMessageWithAudio("Good choice, this mana well can be useful later on.");
            }
            Console.WriteLine();
        }

        private static void UseManaWell()
        {
            ManaWell manaWell = new ManaWell(DateTime.Now.Millisecond.ToString());
            if (manaWell.IsUsed)
            {
                Print.PrintMessageWithAudio("This Mana well has been used and It is empty.");
            }
            else
            {
                Console.Clear();
                player.Mana += manaWell.Mana;
                Print.PrintMessageWithAudio("I feel more powerful already.");
                Print.PrintMessageWithAudio(String.Format("{0} gained {1} mana points by using a Mana well.", player.Id,
                    manaWell.Mana));
                Console.WriteLine();
            }
        }
        #endregion

        #region Map
        private static void ProceesMapElement(char currmapChar)
        {
            switch (currmapChar)
            {
                case 'H':
                    Shop shop = new Shop(player);
                    shop.Run();
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

        public static void GenerateMapByWorld()
        {
            //todo
            Random random = new Random();
            int size = 8 * random.Next(5, world * 5);
            int healtWellCount = random.Next(world + 1, world * 5);
            int manaWellCount = random.Next(world, world * 4);
            int chestCount = random.Next(world, world * (5 - 2));
            int minionCount = random.Next(world * 2, world * 4);
            int mobCount = world;
            var generatedMap = new MapGenerator(size, healtWellCount, manaWellCount, chestCount, minionCount, mobCount);
            map = generatedMap;
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
                        playerPosition.Y = j;
                        playerPosition.X = i;
                    }
                }
            }
        }

        private static void NextWorld()
        {
            player.CalculateLevelByExperience();
            GenerateMapByWorld();
            SetPlayerPos();
            previousMapElement = 'e';
        }
        #endregion 

        #region Save and Load
        public static void Save()
        {

            SaveGame saveGame = new SaveGame(player, map, playerPosition, world, previousMapElement);
            try
            {
                using (Stream stream = File.Open(saveFile, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, saveGame);
                }

                Print.PrintMessageWithAudio("Save Successful!");
            }
            catch (AccessViolationException)
            {
                Print.PrintMessageWithAudio("Save Failed! File access denied.");
            }
            catch (Exception)
            {
                Print.PrintMessageWithAudio("Save failed! An unspecified error occurred.");
            }
        }

        public static void Load()
        {
            SaveGame saveGame;
            try
            {
                using (Stream stream = File.Open(saveFile, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    saveGame = (SaveGame)bin.Deserialize(stream);
                }
                LoadGame(saveGame);
                Print.PrintMessageWithAudio("Load Successful");
            }
            catch (FileNotFoundException)
            {
                Print.PrintMessageWithAudio("No savegame exists!");
            }
            catch (AccessViolationException)
            {
                Print.PrintMessageWithAudio("Load failed! File access denied.");
            }
            catch (Exception)
            {
                Print.PrintMessageWithAudio("Load failed! An unspecified error occurred.");
            }
        }

        public static void LoadGame(SaveGame saveGame)
        {
            player = saveGame.Player;
            map = saveGame.LastMapState;
            playerPosition = saveGame.PlayerPosition;
            world = saveGame.LastWorld;
            previousMapElement = saveGame.PrevMapElement;
            Print.PrintMessageWithAudio("Load successful.");
            map.PrintMap();
            ExecuteCommand();
        }
        #endregion
    }
}