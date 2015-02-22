using Game.Items.Potions;

namespace Game.Core.Data
{
    using System;
    using System.Collections.Generic;
    using Items.ArmorOfDragon;
    using Items.ArmorOfGandalf;
    using Items.Spells;
    using Items.WeaponOfNakov;
    using Exceptions.CharacterException;

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
            new WandOfNakov("Wand"),
            new HealthPotion("Health Potion"),
            new ManaPotion("Mana Potion")
        };
        private int playerLevel;
        private List<Item> itemsList;
        #endregion

        #region Constructors
        public RandomItemGenerator(int playerLevel)
        {
            this.ItemsList = new List<Item>();
            this.PlayerLevel = playerLevel;
            GetRandomItems();
            RandomizeItemsStats();
        }
        #endregion

        #region Properties
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

        public List<Item> ItemsList
        {
            get
            {
                return this.itemsList;
            }

            set
            {
                this.itemsList = value;
            }
        }
        #endregion

        #region Methods
        private void GetRandomItems()
        {
            Random random = new Random();
            for (int i = 0; i <= random.Next(Math.Abs(this.PlayerLevel - 2), this.PlayerLevel + 2); i++)
            {
                int randomItemIndex = random.Next(0, this.allItems.Count);
                Item item = this.allItems[randomItemIndex];
                item.Level = playerLevel;
                while (!ItemsList.Contains(item))
                {
                    this.ItemsList.Add(item);
                }
            }
        }

        private void RandomizeItemsStats()
        {
            Random random = new Random();
            foreach (var item in this.ItemsList)
            {
                if (item is Potion)
                {
                    (item as Potion).Price = (item as Potion).Price * random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    if (item is HealthPotion)
                    {
                        (item as HealthPotion).HealthPoints = item.HealthPoints * random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    }
                    if (item is ManaPotion)
                    {
                        (item as ManaPotion).Mana = item.HealthPoints * random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    }
                }
                else
                {
                    item.AttackPoints = item.AttackPoints*random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    item.DefensePoints = item.DefensePoints*random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    item.HealthPoints = item.HealthPoints*random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    item.Price = item.Price*random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    if (item is Equipment)
                    {
                        (item as Equipment).AttackSpeed = (item as Equipment).AttackSpeed*
                                                          random.Next(Math.Abs(playerLevel - 2),
                                                              playerLevel + 2);
                        (item as Equipment).CriticalChance = (item as Equipment).CriticalChance*
                                                             random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                        (item as Equipment).CriticalDamage = (item as Equipment).CriticalDamage*
                                                             random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                        (item as Equipment).ChanceToDodge = (item as Equipment).ChanceToDodge*
                                                            random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    }
                    if (item is Spell)
                    {
                        (item as Spell).ManaCost = (item as Spell).ManaCost*
                                                   random.Next(Math.Abs(playerLevel - 2), playerLevel + 2);
                    }
                }
            }
        }
        #endregion
    }
}