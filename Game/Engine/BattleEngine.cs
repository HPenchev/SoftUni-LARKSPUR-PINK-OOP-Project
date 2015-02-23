using System;
using System.Collections.Generic;
using System.Linq;
using Game.Core;
using Game.Core.RandomGenerator;
using Game.Enemies;

namespace Game.Engine
{
    public class BattleEngine
    {
        public BattleEngine(Player player, List<Enemy> enemies)
        {
            this.Player = player;
            this.Enemies = enemies;
        }

        private Player Player { get; set; }

        private List<Enemy> Enemies { get; set; }

        public List<Spell> SpellsUsedByPlayer { get; set; }

        public void Run()
        {
            while (true)
            {
                foreach (Spell spellUsed in this.SpellsUsedByPlayer)
                {
                    this.Player.RemoveItemEffects(spellUsed);
                }

                this.SpellsUsedByPlayer.Clear();

                if (this.Player.IsAlive == false)
                {
                    Console.WriteLine("You are dead");
                    Engine.MainMenu();
                }

                if (CheckWhetherAllEnemiesAreDead(this.Enemies))
                {
                    Console.WriteLine("Congratulations, you are the winner!");
                    CollectVictoryProfit();
                    return;
                }

                Console.WriteLine("Current stats:");
                Console.WriteLine(this.Player.ToString());
                foreach (Enemy enemy in this.Enemies)
                {
                    Console.WriteLine(enemy.ToString());
                }

                PlayerMove();
                foreach (Enemy enemy in this.Enemies)
                {
                    EnemyMove(enemy);
                }
            }
        }

        private bool CheckWhetherAllEnemiesAreDead(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsAlive)
                {
                    return false;
                }
            }

            return true;
        }

        private void PlayerMove()
        {
            Console.WriteLine("Make your choise:");
            Console.WriteLine("1 for attack an enemy");
            Console.WriteLine("2 for casting a spell");
            Console.WriteLine("3 for using a potion");

            string playersChoise = Console.ReadLine();

            switch (playersChoise)
            {
                case "1": InitiateAttack();
                    break;
                case "2": CastSpell();
                    break;
                case "3": UsePotion();
                    break;
                default: Console.WriteLine("Invalid choise. Please try again");
                    PlayerMove();
                    break;
            }
        }

        private void InitiateAttack()
        {
            Console.WriteLine("Please enter the ID of the enemy you want to hit");
            string id = Console.ReadLine();

            Character targetedEnemy =
                (Character)from enemy in this.Enemies
                           where enemy.Id == id
                           select enemy;

            this.Player.Attack(targetedEnemy);
        }

        private void CastSpell()
        {
            List<Spell> spells = GetSpells(this.Player);
            if (spells == null || spells.Count == 0)
            {
                Console.WriteLine("There are no spells to cast");
                PlayerMove();
            }

            Console.WriteLine("Please enter the id of the spell you want to cast:");
            Spell spell = null;
            string spellID = Console.ReadLine();
            foreach (Spell spellInInventory in spells)
            {
                if (spellInInventory.Id == spellID)
                {
                    spell = spellInInventory;
                    break;
                }
            }

            if (spell == null)
            {
                Console.WriteLine("No such spell in inventory. Please choose again");
                CastSpell();
            }

            this.Player.ApplyItemEffects(spell);
            this.SpellsUsedByPlayer.Add(spell);
            PlayerMove();
        }

        private List<Spell> GetSpells(Player player)
        {
            List<Spell> spells =
                (List<Spell>)from item in player.Inventory
                             where item is Spell
                             select item;
            return spells;
        }

        private void UsePotion()
        {
            List<Potion> potions = GetPotions(this.Player);
            if (potions == null || potions.Count == 0)
            {
                Console.WriteLine("There are no potions to use");
                PlayerMove();
            }

            Console.WriteLine("Please enter the id of the potion you want to use:");
            Potion potion = null;
            string potionID = Console.ReadLine();
            foreach (Potion potionInInventory in potions)
            {
                if (potionInInventory.Id == potionID)
                {
                    potion = potionInInventory;
                    break;
                }
            }

            if (potion == null)
            {
                Console.WriteLine("No such potion in inventory. Please choose again");
                UsePotion();
            }

            this.Player.ApplyItemEffects(potion);
            PlayerMove();
        }

        private void EnemyMove(Enemy enemy)
        {
            enemy.Attack(this.Player);            
        }

        private List<Potion> GetPotions(Player player)
        {
            List<Potion> potions =
                (List<Potion>)from item in player.Inventory
                             where item is Potion
                             select item;
            return potions;
        }

        private void CollectVictoryProfit()
        {
            foreach (Enemy enemy in this.Enemies)
            {
                this.Player.Gold += enemy.Gold;
                this.Player.Experience += 100;
                if (enemy is Boss)
                {
                    this.Player.Experience += 200;
                }

                Player.Inventory.AddRange(enemy.Inventory);
            }
        }
    }
}
