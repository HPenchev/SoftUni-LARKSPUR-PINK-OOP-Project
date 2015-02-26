using System.Drawing;

namespace Game.Core
{
    using System;

    public class Inventory
    {
        #region Fields
        private Player player;
        private bool isInInventory;
        #endregion

        #region Constructors
        public Inventory(Player player)
        {
            this.Player = player;
            this.isInInventory = true;
        }
        #endregion

        #region Properties
        public Player Player
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        public bool IsInInventory
        {
            get
            {
                return this.isInInventory;
            }

            set
            {
                this.isInInventory = value;
            }
        }
        #endregion

        #region Methods
        public void Run()
        {
            PrintInventory();
            while (this.IsInInventory)
            {
                PrintInventoryCommands();
                string[] input = GetUserInput();
                ExecuteUserInput(input);
            }
        }

        private void PrintInventory()
        {
            if (this.Player.Inventory.Count == 0)
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

                Print.PrintMessage(String.Format("Available gold: {0}", player.Gold));
                Console.WriteLine("{0}", new String('-', 10));
            }
        }

        private void PrintInventoryCommands()
        {
            Print.PrintMessageWithAudio("Available Commands:");
            Print.PrintMessage("inspect [index]");
            Print.PrintMessage("equip [index]");
            Print.PrintMessage("unequip [index]");
            Print.PrintMessage("remove [index]");
            Print.PrintMessage("print");
            Print.PrintMessage("exit");
        }

        private string[] GetUserInput()
        {
            Print.PrintMessageWithAudio("Awaiting input...");
            string[] input = Console.ReadLine().Split(' ');
            Console.WriteLine();
            return input;
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

        private bool IsValidInteger(string value)
        {
            int index;
            return int.TryParse(value, out index);
        }

        private bool IsEquiped(Item item)
        {
            if (item is Equipment)
            {
                if ((item as Weapon).IsEquiped || (item as Armor).IsEquiped)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ExecuteUserInput(string[] input)
        {
            string command = input[0];
            switch (command.ToLower())
            {
                case "equip":
                    Equip(input);
                    break;

                case "unequip":
                    Unequip(input);
                    break;

                case "inspect":
                    Inspect(input);
                    break;

                case "remove":
                    Remove(input);
                    break;

                case "print":
                    PrintInventory();
                    PrintInventoryCommands();
                    break;
                    
                case "exit":
                    Print.PrintMessageWithAudio("Exiting inventory.");
                    this.IsInInventory = false;
                    break;

                default:
                    Print.PrintMessageWithAudio("Invalid input.");
                    PrintInventoryCommands();
                    break;
            }
        }

        private void Inspect(string[] input)
        {
            if (input.Length > 1)
            {
                if (IsValidInteger(input[1]))
                {
                    int index = int.Parse(input[1]);
                    if (IsIndexInRange(index, this.Player.Inventory.Count))
                    {
                        Print.PrintMessage(player.Inventory[index].ToString());
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

        private void Remove(string[] input)
        {
            if (input.Length > 1)
            {
                if (IsValidInteger(input[1]))
                {
                    int index = int.Parse(input[1]);
                    if (IsIndexInRange(index, this.Player.Inventory.Count))
                    {
                        Item item = this.Player.Inventory[index];
                        if (IsEquiped(item))
                        {
                            Print.PrintMessageWithAudio("This item is equiped.");
                            Print.PrintMessageWithAudio("Are you sure you want to remove it?");
                            string choice = Console.ReadLine();
                            if (choice.ToLower().Contains("yes"))
                            {
                                this.Player.RemoveItem(item);
                            }
                            else
                            {
                                Print.PrintMessageWithAudio("Good, you can find that item useful later on.");
                            }
                        }
                        else
                        {
                            Print.PrintMessageWithAudio("Are you sure you want to remove it?");
                            string choice = Console.ReadLine();
                            if (choice.ToLower().Contains("yes"))
                            {
                                this.Player.RemoveItem(item);
                            }
                            else
                            {
                                Print.PrintMessageWithAudio("Good, you can find that item useful later on.");
                            }
                        }
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

        private void Unequip(string[] input)
        {
            if (input.Length > 1)
            {
                if (IsValidInteger(input[1]))
                {
                    int index = int.Parse(input[1]);
                    if (IsIndexInRange(index, this.Player.Inventory.Count))
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

        private void Equip(string[] input)
        {
            if (input.Length > 1)
            {
                if (IsValidInteger(input[1]))
                {
                    int index = int.Parse(input[1]);
                    if (IsIndexInRange(index, this.Player.Inventory.Count))
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
        #endregion
    }
}