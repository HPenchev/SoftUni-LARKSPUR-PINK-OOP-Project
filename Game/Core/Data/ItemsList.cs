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

    public class ItemsList
    {
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

        protected ItemsList(int playerLevel)
        {
            this.PlayerLevel = playerLevel;
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int randomItemIndex = random.Next(0, this.allItems.Count + 1);
                Item item = allItems[randomItemIndex];
                if(item is Weapon)
                {
                    item.Level = playerLevel;
                    item.AttackPoints = random.Next((int) item.AttackPoints, (playerLevel*1000)/4);
                    item.DefensePoints = 0;
                    item.HealthPoints = 0;
                    (item as IStatsable).CriticalChance = random.Next(0, playerLevel * 3);
                    (item as IStatsable).CritDamage = random.Next(0, playerLevel * 3);
                }

                if (item is Armor)
                {
                    item.Level = playerLevel;
                    item.AttackPoints = 0;
                    item.DefensePoints = random.Next(100, playerLevel*3);
                    item.HealthPoints = random.Next(50, playerLevel*100);
                    (item as IStatsable).AllResistance = random.Next(0, playerLevel * 3);
                    (item as IStatsable).AttackSpeed = random.Next(0, playerLevel * 30);
                    (item as IStatsable).ChanceToDodge = random.Next(0, playerLevel*5);
                }

                if (item is Spell)
                {
                    item.Level = playerLevel;
                    item.AttackPoints = item.AttackPoints += random.Next(0, playerLevel*100);
                }
                this.list.Add(item);
            }
        }

        private int PlayerLevel
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

                this.PlayerLevel = value;
            }
        }

        private List<Item> List
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