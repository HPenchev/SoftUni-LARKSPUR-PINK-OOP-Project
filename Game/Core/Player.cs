using System.Linq;
using Game.Core.Data.Enums;

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
        private double mana;
        private double attackSpeed;
        private double allResistance;
        private double criticalChance;
        private double critDamage;
        private double chanceToDodge;

        protected Player(string id)
            : base(id)
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

        public void UnequipItem(Item item)
        {
            if (this.Inventory.Contains(item))
            {
                if ((item as Equipment).IsEquiped)
                {
                    (item as Equipment).IsEquiped = false;
                    RemoveItemEffects(item as Equipment);
                }
                else
                {
                    Console.WriteLine("That item is already unequiped.");
                }
            }
            else
            {
                Console.WriteLine("The inventory does not contain that item.");
            }
        }

        public void EquipItem(Item item)
        {
            if (item is Weapon)
            {
                WeaponType currentWeaponType = (item as Weapon).WeaponType; // weapon type check todo
                var query = this.Inventory
                    .Where(n => n is Weapon && (n as Weapon).IsEquiped)
                    .Select(n => n);
                if (!query.Any())
                {
                    (item as Weapon).IsEquiped = true;
                    Console.WriteLine("{0} has been equiped.", item.Id);
                    ApplyItemEffects(item as Equipment);
                }
                else
                {
                    Console.WriteLine("You can not equip two items of the same type.");
                }
            }
            else if (item is Armor)
            {
                ArmorType currentArmorType = (item as Armor).ArmorType;
                var query = this.Inventory
                    .Where(n => n is Armor && (n as Armor).IsEquiped && currentArmorType == (n as Armor).ArmorType)
                    .Select(n => n);
                if (!query.Any())
                {
                    (item as Armor).IsEquiped = true;
                    Console.WriteLine("{0} has been equiped.", item.Id);
                    ApplyItemEffects(item as Equipment);
                }
                else
                {
                    Console.WriteLine("You can not equip two items of the same type.");
                }
            }
            else
            {
                Console.WriteLine("This item can not be equiped");
            }
        }

        private void ApplyItemEffects(Equipment item)
        {
            this.AttackPoints += (item as Equipment).AttackPoints;
            this.AttackSpeed += (item as Equipment).AttackSpeed;
            this.ChanceToDodge += (item as Equipment).ChanceToDodge;
            this.CriticalChance += (item as Equipment).CriticalChance;
            this.CritDamage += (item as Equipment).CriticalDamage;
            this.DefensePoints += (item as Equipment).DefensePoints;
            this.HealthPoints += (item as Equipment).HealthPoints;
        }

        private void RemoveItemEffects(Equipment item)
        {
            this.AttackPoints -= (item as Equipment).AttackPoints;
            this.AttackSpeed -= (item as Equipment).AttackSpeed;
            this.ChanceToDodge -= (item as Equipment).ChanceToDodge;
            this.CriticalChance -= (item as Equipment).CriticalChance;
            this.CritDamage -= (item as Equipment).CriticalDamage;
            this.DefensePoints -= (item as Equipment).DefensePoints;
            if (this.HealthPoints <= (item as Equipment).HealthPoints)
            {
                this.HealthPoints = 1;
            }
            else
            {
                this.HealthPoints -= (item as Equipment).HealthPoints;
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
                        this.Inventory.Add(items[i]);
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
            if (Inventory.Contains(item))
            {
                this.Inventory.Remove(item);
                UpdateInventorySpace();
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