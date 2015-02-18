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
        private List<IItem> inventory;
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
            this.Inventory = new List<IItem>();
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

        public List<IItem> Inventory
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

        public void PickUpItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string id)
        {
            throw new NotImplementedException();
        }

        public ICharacter FindTarget(ICharacter enemy)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder basePlayer = new StringBuilder();
            basePlayer.Append(base.ToString());
            int avavailableSpaceInInventory = this.InventorySize - this.Inventory.Count;
            basePlayer.AppendFormat(
                "Kils: {10},\nFree space in inventory: {0},\nLevel: {1},\nExperience: {2},\nGold: {3}\nMana: {4},\nAttack speed: {5},\nAllresistance: {6},\nCritical damage: {7},\nCritical chance: {8},\nChance to dodge {9}.",
                avavailableSpaceInInventory,
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