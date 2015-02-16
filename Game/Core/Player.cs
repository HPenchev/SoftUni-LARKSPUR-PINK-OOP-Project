using System;
using System.Collections.Generic;
using Game.Core.Data.Constants.PlayerConstatns;
using Game.Interfaces;
using Game.Core.Data.Enums;
using Game.Exceptions;

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

        public List<IItem> Equipment { get; set; }

        public virtual void CastSpell(IItem item)
        {            
        }

        public void Display(string args)
        {
            throw new NotImplementedException(); // switch case or in the engine, should display different things depending on the args passed
        }

        public void PickUpItem(IItem item)
        {
            if (this.InventorySize < item.Size)
            {
                throw new InsufficientExecutionStackException("Not enough space in inventory");
            }

            this.Inventory.Add(item);
            this.inventorySize -= item.Size;
        }
        
        public void RemoveItem(IItem item)
        {
            for (int i = 0; i < this.Inventory.Count; i++)
            {
                if (this.Inventory[i].Id == item.Id)
                {
                    this.InventorySize += this.Inventory[i].Size;
                    if(this.InventorySize > PlayerConstants.PlayerStartingInventorySize)
                    {
                        this.InventorySize = PlayerConstants.PlayerStartingInventorySize;
                    }

                    this.Inventory.RemoveAt(i);
                    return;
                }
            }
            
            throw new ItemNotInStashException("Item not in stash");  
        }

        public ICharacter FindTarget(ICharacter enemy)
        {
            throw new NotImplementedException(); // TargetNotFoundException
        }

        public void EquipItem(IItem item)
        {
            if (item is Armor)
            {
                EquipArmor(item);
            }
            else
            {
                EquipWeapon(item);
            }
        }

        public void BuyItem(Item item)
        {
            if (this.Gold < item.Price)
            {
                throw new InsufficientGoldException("Not enough gold");
            }
            
            this.PickUpItem(item);
            this.Gold -= item.Price;
        }

        public void SellItem(Item item)
        {
            this.RemoveItem(item);
            this.Gold += item.Price;
        }

        protected virtual void EquipWeapon(IItem item)
        {
            CheckLevelEquipability(item);

            Weapon itemRemoved = null;
            for (int i = 0; i < this.Equipment.Count; i++)
            {
                if (this.Equipment[i] is Weapon)
                {
                    itemRemoved = (Weapon)this.Equipment[i];
                    this.Equipment.RemoveAt(i);
                }
            }
            SwitchBetweenStashAndEquipment(item, itemRemoved);
        }
        
        private void EquipArmor(IItem item)
        {
            CheckLevelEquipability(item);

            Armor itemRemoved = null;
            for (int i = 0; i < this.Equipment.Count; i++)
            {
                if((this.Equipment[i] is Armor) && ((Armor)this.Equipment[i]).ArmorType == ((Armor)item).ArmorType)
                {
                    itemRemoved = (Armor)this.Equipment[i];                    
                    this.Equipment.RemoveAt(i);                    
                }               
            }
            SwitchBetweenStashAndEquipment(item, itemRemoved);
        }

        private void CheckLevelEquipability(IItem item)
        {
            if (item.Level > this.Level)
            {
                throw new LevelException("You don't have the level needed yet");
            }
        }

        private void SwitchBetweenStashAndEquipment(IItem item, Item itemRemoved)
        {

            this.Equipment.Add(item);
            ApplyItemEffects(item);
            this.RemoveItem(item);
            if (itemRemoved != null)
            {
                this.RemoveItemEffects(itemRemoved);
                this.PickUpItem(itemRemoved);
            }
        }

        private void ApplyItemEffects(IItem item)
        {
            this.AttackPoints += item.AttackPoints;
            this.DefensePoints += item.DefensePoints;
            this.HealthPoints += item.HealthPoints;
        }

        private void RemoveItemEffects(IItem item)
        {
            this.AttackPoints -= item.AttackPoints;
            this.DefensePoints -= item.DefensePoints;
            this.HealthPoints -= item.HealthPoints;
        }
    }
}