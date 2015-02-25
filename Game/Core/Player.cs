namespace Game.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data.Constants.PlayerConstatns;
    using Data.Enums;
    using Exceptions.CharacterException;
    using Interfaces;

    [Serializable]
    public abstract class Player : Character, IPlayer, IStatsable
    {
        #region Fields
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
        #endregion

        #region Constructors
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
        #endregion

        #region Properties
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
        #endregion

        #region Methods
        public void UnequipItem(Item item)
        {
            if (this.Inventory.Contains(item))
            {
                if ((item as Equipment).IsEquiped)
                {
                    (item as Equipment).IsEquiped = false;
                    RemoveItemEffects(item);
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
                    ApplyItemEffects(item);
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
                    ApplyItemEffects(item);
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

        public void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthPoints;

            if (item is Potion)
            {
                this.Mana += (item as Potion).Mana;
            }
            else
            {
                this.AttackPoints += item.AttackPoints;
                this.DefensePoints += item.DefensePoints;
                if (item is Equipment)
                {
                    this.AttackSpeed += (item as Equipment).AttackSpeed;
                    this.ChanceToDodge += (item as Equipment).ChanceToDodge;
                    this.CriticalChance += (item as Equipment).CriticalChance;
                    this.CritDamage += (item as Equipment).CriticalDamage;
                }
            }
        }

        public void RemoveItemEffects(Item item)
        {
            this.AttackPoints -= item.AttackPoints;
            this.DefensePoints -= item.DefensePoints;
            if (this.HealthPoints <= item.HealthPoints)
            {
                this.HealthPoints = 1;
            }
            else
            {
                this.HealthPoints -= item.HealthPoints;
            }

            if (item is Spell)
            {
                RemoveItem(item);
            }

            if (item is Equipment)
            {
                this.AttackSpeed -= (item as Equipment).AttackSpeed;
                this.ChanceToDodge -= (item as Equipment).ChanceToDodge;
                this.CriticalChance -= (item as Equipment).CriticalChance;
                this.CritDamage -= (item as Equipment).CriticalDamage;
                (item as Equipment).IsEquiped = false;
            }
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

        public void CalculateLevelByExperience()
        {
            if (this.Experience % 100 == 0)
            {
                this.Level++;
                Console.WriteLine("Level UP! you can check your updated stats!");
                LevelUpUpdate();
            }
        }

        public void CastSpell(Spell spell)
        {
            if (spell.ManaCost > this.Mana)
            {
                throw new InsufficientManaException();
            }
            else
            {
                this.ApplyItemEffects(spell);
            }
        }

        protected override double CalculateDamage()
        {
            double damage = this.AttackPoints;

            int criticalStrikeChence = RandomGenerator.RandomGenerator.Rnd.Next(0, (int)this.CriticalChance * 2);

            if (criticalStrikeChence > 8)
            {
                damage += damage * this.CritDamage;
                Console.WriteLine("Critical!");
            }

            return damage;
        }

        private void LevelUpUpdate()
        {
            this.AttackPoints *= 1.2;
            this.HealthPoints *= 1.2;
            this.Mana *= 1.2;
            this.InventorySize += 2;
            this.attackSpeed *= 1.1;
            this.allResistance *= 1.1;
        }
        #endregion
    }
}