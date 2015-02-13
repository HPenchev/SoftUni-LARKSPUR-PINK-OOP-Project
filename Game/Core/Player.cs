using System;
using System.Collections.Generic;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Interfaces;

namespace Game.Core
{
    public abstract class Player : Character, IPlayer
    {
        private int inventorySize;
        private int level;
        private decimal experience;
        private decimal gold;
        private List<IItem> inventory;
        private double mana;        
        private double allResistance;       

        protected Player(string id)
            : base(id)
        {
            this.InventorySize = PlayerConstants.PlayerStartingInventorySize;
            this.Level = PlayerConstants.PlayerStartingLevel;
            this.Experience = PlayerConstants.PlayerStartingExperience;
            this.Gold = PlayerConstants.PlayerStartingGold;
            this.Inventory = new List<IItem>();
            this.MapPosition = new Position(PlayerConstants.playerStartingX, PlayerConstants.playerStartingY);
        }

        public int InventorySize
        {
            get 
            { 
                return this.inventorySize;
            }
            set
            {
                if (value < PlayerConstants.PlayerStartingInventorySize)
                {
                    value = PlayerConstants.PlayerStartingInventorySize;
                }

                this.inventorySize = value;
            }
        }

        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        public decimal Experience
        {
            get { return this.experience; }
            set { this.experience = value; }
        }

        public List<IItem> Inventory
        {
            get { return this.inventory; }
            set { this.inventory = value; }
        }

        public decimal Gold
        {
            get { return this.gold; }
            set { this.gold = value; }
        }

        public double Mana
        {
            get { return this.mana; }
            set { this.mana = value; }
        }                

        public double AllResistance
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }        

        private void CalculateAllStats()
        {
            //calc attackSpeed , cacl crit, doge
            //deff with allres will be taken in the engine
            throw new NotImplementedException();
        }

        

        public void CastSpell(IItem item)
        {
            throw new NotImplementedException();
            // NotEnoughManaException
        }

        public void Display(string args)
        {
            throw new NotImplementedException(); // switch case or in the engine, should display different things depending on the args passed
        }

        public void PickUpItem(IItem item)
        {
            //todo check size of the inventory, if space is available pick item 
            // NotEnoughSpaceException
        }

        public void RemoveItem(IItem item)
        {
            throw new NotImplementedException(); // ItemNotFoundException
        }

        public ICharacter FindTarget(ICharacter enemy)
        {
            throw new NotImplementedException(); // TargetNotFoundException
        }
    }
}