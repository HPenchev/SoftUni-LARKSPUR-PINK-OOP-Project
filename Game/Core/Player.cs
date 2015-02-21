using System.Linq;

namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Data.Constants.PlayerConstatns;
    using Interfaces;

    public abstract class Player : Character, IPlayer, IStatsable
    {
        private int killCounter;
        private int inventorySize;
        private int level;
        private decimal experience;
        private decimal gold;
        private List<Item> inventory;
        private double mana;
        private double attackSpeed;
        private double allResistance;
        private double criticalChance;
        private double critDamage;
        private double chanceToDodge; 

        protected Player(string id) : base(id)
        {
            this.Experience = PlayerConstants.PlayerStartingExperience;
            this.Level = PlayerConstants.PlayerStartingLevel;
            this.InventorySize = PlayerConstants.PlayerStartingInventorySize;
            this.Experience = PlayerConstants.PlayerStartingExperience;
            this.Gold = PlayerConstants.PlayerStartingGold;
            this.Inventory = new List<Item>();
            this.KillCounter = PlayerConstants.KillCounter;
        }

        public int KillCounter
        {
            get
            {
                return this.killCounter;
            }

            set
            {
                this.killCounter = value;
            }
        }

        public int InventorySize
        {
            get
            {
                return this.inventorySize;
            }

            set
            {
                this.inventorySize = value;
            }
        }

        public decimal Gold
        {
            get
            {
                return this.gold;
            }

            set
            {
                this.gold = value;
            }
        }

        public decimal Experience
        {
            get
            {
                return this.experience;
            }

            set
            {
                this.experience = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
            }
        }

        public double Mana
        {
            get
            {
                return this.mana;
            }

            set
            {
                this.mana = value;
            }
        }

        public List<Item> Inventory
        {
            get
            {
                return this.inventory;
            }

            set
            {
                this.inventory = value;
            }
        }

        public double AttackSpeed
        {
            get
            {
                return this.attackSpeed;
            }

            set
            {
                this.attackSpeed = value;
            }
        }

        public double CriticalChance
        {
            get
            {
                return this.criticalChance;
            }

            set
            {
                this.criticalChance = value;
            }
        }

        public double ChanceToDodge
        {
            get
            {
                return this.chanceToDodge;
            }

            set
            {
                this.chanceToDodge = value;
            }
        }

        public double CritDamage
        {
            get
            {
                return this.critDamage;
            }

            set
            {
                this.critDamage = value;
            }
        }

        public double AllResistance
        {
            get
            {
                return this.allResistance;
            }

            set
            {
                this.allResistance = value;
            }
        }

        public void Attack(ICharacter enemy)
        {
            throw new NotImplementedException();
        }

        public void CastSpell(Spell id)
        {
            throw new NotImplementedException();
        }

        public void Display(string args)
        {
            throw new NotImplementedException();
        }

        public void PickUpItem(List<Item> items)
        {
            string answer = string.Empty;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("Do you want to add {0} to your inventory.", items[i].Id);
                answer = Console.ReadLine();
                if (answer.ToLower().Contains("yes"))
                {
                    if (this.InventorySize - items[i].Size <= 0)
                    {
                        Console.WriteLine("Your Inventory is Full.\nPlease remove something.");
                    }
                    else
                    {
                        this.inventory.Add(items[i]);
                        Console.WriteLine("You have added {0} to your inventory.", items[i].Id);
                    }
                }
                else
                {
                    Console.WriteLine("It's crap anyway.");
                    continue;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void UpdateInventorySpace()
        {
            int itemsSize = this.Inventory.Sum(n => n.Size);
            this.InventorySize = PlayerConstants.PlayerStartingInventorySize - itemsSize;
        }

        public void RemoveItem(Item item)
        {
            if (inventory.Contains(item))
            {
                this.inventory.Remove(item);
                Console.WriteLine("{0} has been removed.", item.Id);
            }
            else
            {
                Console.WriteLine("No such Item in Inventory.");
            }
        }

        public ICharacter FindTarget(ICharacter enemy)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder basePlayer = new StringBuilder();
            basePlayer.Append(base.ToString());
            basePlayer.AppendFormat(
                "Kils: {10},\nFree space in inventory: {0},\nLevel: {1},\nExperience: {2},\nGold: {3}\nMana: {4},\nAttack speed: {5},\nAllresistance: {6},\nCritical damage: {7},\nCritical chance: {8},\nChance to dodge {9}.",
                this.InventorySize,
                this.Level,
                this.Experience,
                this.Gold,
                this.Mana,
                this.AttackSpeed,
                this.AllResistance,
                this.CritDamage,
                this.CriticalChance,
                this.ChanceToDodge,
                this.KillCounter);
            return basePlayer.ToString();
        }
    }
}