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

            this.Player.CastSpell(spell);
            this.SpellsUsedByPlayer.Add(spell);
        }

        private List<Spell> GetSpells(Character character)
        {
            List<Spell> spells =
                (List<Spell>)from item in character.Inventory
                             where item is Spell
                             select item;
            return spells;
        }

        private void UsePotion()
        {
            throw new NotImplementedException();
        }

        private void EnemyMove(Enemy enemy)
        {
            List<Spell> spells = GetSpells(enemy);
            int chenceToSpell = RandomGenerator.rnd.Next(10);
            if (spells.Count > 0 && chenceToSpell < 2)
            {
                int spellToUse = RandomGenerator.rnd.Next(spells.Count);
                enemy.CastSpell(spells[spellToUse]);
            }
            else
            {
                enemy.Attack(this.Player);
            }
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
            }
        }
    }
}
