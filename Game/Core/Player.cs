using System;
using System.Collections.Generic;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Core.Data.Enums;
using Game.Exceptions;
using Game.Interfaces;

namespace Game.Core
{
    public abstract class Player : Character, IPlayer, IStatsable
    {
        private int inventorySize;
        private int level;
        private decimal experience;
        private decimal gold;
        private List<IItem> inventory;
        private double mana;
        private double attackSpeed;
        private double allResistance;
        private double critChance;
        private double critDamage;
        private double chanceToDoge;

        public int InventorySize
        {
            get { return inventorySize; }
            set { inventorySize = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public decimal Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        public decimal Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public List<IItem> Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public double Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        public double AttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }

        public int CriticalChance
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int ChanceToDodge
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public double AllResistance
        {
            get { return allResistance; }
            set { allResistance = value; }
        }

        public double CritChance
        {
            get { return critChance; }
            set { critChance = value; }
        }

        public double CritDamage
        {
            get { return critDamage; }
            set { critDamage = value; }
        }

        public double ChanceToDoge
        {
            get { return chanceToDoge; }
            set { chanceToDoge = value; }
        }

        protected Player(string id)
            : base(id)
        {
            this.Level = PlayerConstants.PlayerStartingLevel;
            this.InventorySize = PlayerConstants.PlayerStartingInventorySize;
            this.Experience = PlayerConstants.PlayerStartingExperience;
            this.Gold = PlayerConstants.PlayerStartingGold;
            this.Inventory = new List<IItem>();
        }

        public abstract void Attack(ICharacter enemy);
        
        public void CastSpell(Spell id)
        {
            //todo
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
    }
}