namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class Shop
    {
        #region Fields
        private List<Item> shopInventory;
        private Player player;
        private RandomItemGenerator randomItemGenerator;
        private bool isInShop;
        #endregion

        #region Constructors
        public Shop(Player player)
        {
            this.Player = player;
            this.RandomItemGenerator = new RandomItemGenerator(this.Player.Level);
            this.ShopInventory = this.RandomItemGenerator.AllItems;
            randomItemGenerator.RandomizeItemsStats(this.ShopInventory);
            EqualizeItemAndPlayerLevel();
            this.IsInShop = true;
        }
        #endregion

        #region Properties
        public List<Item> ShopInventory
        {
            get
            {
                return this.shopInventory;
            }

            set
            {
                this.shopInventory = value;
            }
        }

        public Player Player
        {
            get { return this.player; }

            set { this.player = value; }
        }

        public RandomItemGenerator RandomItemGenerator
        {
            get
            {
                return this.randomItemGenerator;
            }

            set
            {
                this.randomItemGenerator = value;
            }
        }

        public bool IsInShop
        {
            get
            {
                return this.isInShop;
            }

            set
            {
                this.isInShop = value;
            }
        }
        #endregion

        #region Methods
        public void Run()
        {
            PrintShopItems();
            PrintShopCommands();
            while (this.IsInShop)
            {
                string[] input = GetUserInput();
                ExecuteUserInput(input);
            }
        }

        private void EqualizeItemAndPlayerLevel()
        {
            this.ShopInventory.ForEach(n => n.Level = this.Player.Level);
        }

        private void PrintShopItems()
        {
            PlayAudio.WelcomeToTheShop();
            Console.WriteLine("<---S-H-O-P--->");
            Console.WriteLine("{0} ---> Index[{1}] Price[{2}]", "Item", "ID", "Price");
            for (int i = 0; i < shopInventory.Count; i++)
            {
                Console.WriteLine("{0} ---> {1}  {2} gold", shopInventory[i].Id, i, shopInventory[i].Price);
            }

            Print.PrintMessage(String.Format("Available gold: {0}", player.Gold));
            Console.WriteLine("{0}\n", new String('-', 10));
        }

        private void PrintShopCommands()
        {
            Print.PrintMessageWithAudio("Available Commands:");
            Print.PrintMessage("buy [index]");
            Print.PrintMessage("inspect [index]");
            Print.PrintMessage("sell");
            Print.PrintMessage("print");
            Print.PrintMessage("exit");
            Console.WriteLine();
        }

        private void PrintPlayerInventory(Player player)
        {
            if (player.Inventory.Any())
            {
                Console.Clear();
                Console.WriteLine("<---Your Items--->");
                Console.WriteLine("{0} ---> Index[{1}] Price[{2}]", "Item", "ID", "Price");
                for (int i = 0; i < player.Inventory.Count; i++)
                {
                    Console.WriteLine("{0} Index: {1} Price: {2:F0} gold",
                                      player.Inventory[i].Id, i, player.Inventory[i].Price * 0.8M);
                }

                Console.WriteLine((String.Format("{0}\n", new String('-', 10))));
                Console.WriteLine();
            }
            else
            {
                Print.PrintMessageWithAudio("You do not have any items in your inventory.");
            }
        }

        private void PrintSellMenuChoices()
        {
            Print.PrintMessageWithAudio("Available Commands:");
            Print.PrintMessage("sell [index]");
            Print.PrintMessage("exit");
        }

        private string[] GetUserInput()
        {
            Print.PrintMessageWithAudio("Awaiting input...");
            string[] input = Console.ReadLine().Split(' ');
            Console.WriteLine();
            return input;
        }

        private bool IsValidInteger(string value)
        {
            int index;
            return int.TryParse(value, out index);
        }

        private bool IsIndexInRange(int index, int collectionCount)
        {
            if (index >= 0 && index < collectionCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsPlayerGoldSufficient(decimal playerGold, decimal itemPrice)
        {
            if (playerGold >= itemPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsPlayerInventorySpaceSufficient(Player player, Item item)
        {
            int currentSpaceTaken = player.Inventory.Sum(n => n.Size);
            int currentFreeSpace = player.InventorySize - currentSpaceTaken;
            if (currentFreeSpace >= item.Size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Buy(string[] input)
        {
            if (input.Length > 1)
            {
                if (IsValidInteger(input[1]))
                {
                    if (IsIndexInRange(int.Parse(input[1]), this.ShopInventory.Count))
                    {
                        Item item = this.ShopInventory[int.Parse(input[1])];
                        if (IsPlayerGoldSufficient(this.Player.Gold, item.Price))
                        {
                            if (IsPlayerInventorySpaceSufficient(this.Player, item))
                            {
                                this.Player.Inventory.Add(item);
                                this.Player.Gold -= item.Price;
                                Print.PrintMessageWithAudio(String.Format("You have successfuly bought {0}", item.Id));
                            }
                            else
                            {
                                Print.PrintMessageWithAudio("You do not have enough free inventory space available.");
                            }
                        }
                        else
                        {
                            Print.PrintMessageWithAudio("You do not have enough gold to buy this item.");
                        }
                    }
                    else
                    {
                        Print.PrintMessageWithAudio("Invalid index. Please enter an index in range.");
                    }
                }
                else
                {
                    Print.PrintMessageWithAudio("Invalid index. Please enter a valid integer number.");
                }
            }
            else
            {
                Print.PrintMessage("Invalid input.");
            }
        }

        private void Sell()
        {
            PrintPlayerInventory(this.Player);
            PrintSellMenuChoices();
            string[] sellMenuUserInput = GetUserInput();
            if (sellMenuUserInput.Length > 1)
            {
                if (!sellMenuUserInput.Contains("exit"))
                {
                    if (IsValidInteger(sellMenuUserInput[1]))
                    {
                        int index = int.Parse(sellMenuUserInput[1]);
                        if (IsIndexInRange(index, this.ShopInventory.Count))
                        {
                            Item item = this.Player.Inventory[index];
                            if (item is Equipment)
                            {
                                if ((item as Equipment).IsEquiped)
                                {
                                    Print.PrintMessageWithAudio("This item is equiped.");
                                    Print.PrintMessageWithAudio("Are you sure you want to sell it?");
                                    string choice = Console.ReadLine();
                                    if (choice.ToLower().Contains("yes"))
                                    {
                                        Print.PrintMessageWithAudio(
                                            String.Format("{0} was successfuly sold for {1} gold.",
                                                item.Id, item.Price*0.8M));
                                        this.Player.RemoveItemEffects(item);
                                        this.Player.Gold += item.Price;
                                        this.Player.RemoveItem(item);
                                        PrintPlayerInventory(this.Player);
                                        PrintSellMenuChoices();
                                    }
                                    else
                                    {
                                        Print.PrintMessageWithAudio("Good choice, you may find this item useful.");
                                    }
                                }
                                else
                                {
                                    Print.PrintMessageWithAudio("Are you sure you want to sell it?");
                                    string choice = Console.ReadLine();
                                    if (choice.ToLower().Contains("yes"))
                                    {
                                        Print.PrintMessageWithAudio(
                                            String.Format("{0} was successfuly sold for {1} gold.",
                                                item.Id, item.Price*0.8M));
                                        this.Player.Gold += item.Price;
                                        this.Player.RemoveItem(item);
                                        PrintPlayerInventory(this.Player);
                                        PrintSellMenuChoices();
                                    }
                                    else
                                    {
                                        Print.PrintMessageWithAudio("Good choice, you may find this item useful.");
                                    }
                                }
                            }
                            else
                            {
                                Print.PrintMessageWithAudio("Are you sure you want to sell it?");
                                string choice = Console.ReadLine();
                                if (choice.ToLower().Contains("yes"))
                                {
                                    Print.PrintMessageWithAudio(String.Format("{0} was successfuly sold for {1} gold.",
                                        item.Id, item.Price*0.8M));
                                    this.Player.Gold += item.Price;
                                    this.Player.RemoveItem(item);
                                    PrintPlayerInventory(this.Player);
                                    PrintSellMenuChoices();
                                }
                                else
                                {
                                    Print.PrintMessageWithAudio("Good choice, you may find this item useful.");
                                }
                            }
                        }
                        else
                        {
                            Print.PrintMessageWithAudio("Invalid index. Please enter an index in range.");
                        }
                    }
                    else
                    {
                        Print.PrintMessageWithAudio("Invalid index. Please enter a valid integer number.");
                    }
                }
                else
                {
                    PrintShopItems();
                    PrintShopCommands();
                }
            }
            else
            {
                Print.PrintMessage("Invalid input.");
            }
        }

        private void Inspect(string[] input)
        {
            if (input.Length > 1)
            {
                if (IsValidInteger(input[1]))
                {
                    int index = int.Parse(input[1]);
                    if (IsIndexInRange(index, this.ShopInventory.Count))
                    {
                        Print.PrintMessage(this.ShopInventory[index].ToString());
                    }
                    else
                    {
                        Print.PrintMessageWithAudio("Invalid item index.");
                    }
                }
                else
                {
                    Print.PrintMessageWithAudio("Please enter a valid integer number.");
                }
            }
            else
            {
                Print.PrintMessage("Invalid input.");
            }
        }


        private void ExecuteUserInput(string[] input)
        {
            string command = input[0];
            switch (command.ToLower())
            {
                case "buy":
                    Buy(input);
                    break;

                case "sell":
                    Sell();
                    break;

                case "inspect":
                    Inspect(input);
                    break;

                case "print":
                    PrintShopItems();
                    PrintShopCommands();
                    break;

                case "exit":
                    this.IsInShop = false;
                    break;

                default:
                    Print.PrintMessageWithAudio("Invalid command.");
                    break;
            }
        }
        #endregion
    }
}