using System;
using System.Collections.Generic;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Interfaces;
using Game.Core.Data.Enums;

namespace Game.Core
{
    public abstract class Player : Character, IPlayer
    {
        private int inventorySize;    
        private decimal experience;
        private decimal gold;
        private List<IItem> inventory;
        private double mana;        

        protected Player(string id,
            double healthPoints,
            double defensePoints,
            double range,
            double attackPoints = 0,
            double attackSpeed = 1,
            int criticalChance = 0,
            int chanceToDoge = 0
            )
            : base(id, healthPoints, defensePoints, range, attackPoints, attackSpeed, criticalChance, chanceToDoge)
        {
            this.Level = PlayerConstants.PlayerStartingLevel;
            this.InventorySize = PlayerConstants.PlayerStartingInventorySize;            
            this.Experience = PlayerConstants.PlayerStartingExperience;
            this.Gold = PlayerConstants.PlayerStartingGold;
            this.Inventory = new List<IItem>();
            this.MapPosition = new Position(PlayerConstants.PlayerStartingX, PlayerConstants.PlayerStartingY);
            this.Team = Team.Light;
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

        public Position MapPosition { get; set; }

        public virtual void CastSpell(IItem item)
        {            
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