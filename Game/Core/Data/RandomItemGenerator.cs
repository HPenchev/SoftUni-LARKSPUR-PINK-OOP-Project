using System.ComponentModel.Design;
using Game.Exceptions.CharacterException;
using Game.Interfaces;
using Game.Items.ArmorOfDragon;
using Game.Items.ArmorOfGandalf;
using Game.Items.Spells;
using Game.Items.WeaponOfNakov;


namespace Game.Core.Data
{
    using System;
    using System.Collections.Generic;

    public class RandomItemGenerator
    {
        #region Fields
        protected List<Item> allItems = new List<Item>()
        {
            new BeltOfDragon("Belt"),
            new ChestArmorOfDragon("Dragon's Chest"),
            new BeltOfGandalf("Belt"),
            new BootsOfGandalf("Boots"),
            new ChestArmorOfGandalf("Gandalf's Chest"),
            new GlovesOfGandalf("Gloves of Gandalf"),
            new HelmetOfGandalf("Helmet"),
            new PantsOfGandalf("Pants"),
            new ShieldOfGandalf("Shield"),
            new SpellOfDefence("Defence Spell"),
            new SpellOfHealth("Health Spell"),
            new SpellOfInvulnerability("Spell"),
            new SpellOfRossi("Rossi's Spell"),
            new AxeOfNakov("Axe"),
            new BowOfNakov("Bow"),
            new SwordOfNakov("Sword"),
            new WandOfNakov("Wand")
        };
        private int playerLevel;
        private List<Item> list;
        #endregion

        public RandomItemGenerator(int playerLevel)
        {
            this.list = new List<Item>();
            this.PlayerLevel = playerLevel;
            Random random = new Random();
            for (int i = 0; i <= random.Next(this.PlayerLevel + 1, this.PlayerLevel + 3); i++)
            {
                int randomItemIndex = random.Next(0, this.allItems.Count);
                Item item = this.allItems[randomItemIndex];
                item.Level = playerLevel;
                while (!list.Contains(item)) ////todo same item type check
                {
                    this.list.Add(item);
                }
            }
        }

        public int PlayerLevel
        {
            get
            {
                return this.playerLevel;
            }
            set
            {
                if (value < 0)
                {
                    throw new NegativePlayerLevelException("The player level can not be negative.");
                }

                this.playerLevel = value;
            }
        }

        public List<Item> List
        {
            get
            {
                return this.list;
            }

            set
            {
                this.list = value;
            }
        }
    }
}