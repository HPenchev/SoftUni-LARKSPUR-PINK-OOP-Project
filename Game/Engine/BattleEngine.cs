using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using Game.Core;
using Game.Core.RandomGenerator;
using Game.Enemies;
using Game.Exceptions.CharacterException;

namespace Game.Engine
{
    public class BattleEngine
    {
        public BattleEngine(Player player, List<Enemy> enemies)
        {
            this.Player = player;
            this.Enemies = enemies;
            SpellsUsedByPlayer = new List<Spell>();
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

                Console.WriteLine("Player current stats:");
                Console.WriteLine(this.Player.ToString());
                foreach (Enemy enemy in this.Enemies)                

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
            Console.WriteLine("Please selct a number of the enemy you want to attack");
            List<Enemy> enemiesAlive = new List<Enemy>();
            foreach (Enemy enemyInList in this.Enemies)
            {
                if(enemyInList.IsAlive)
                {
                    enemiesAlive.Add(enemyInList);
                }
            }

            for (int i = 0; i < enemiesAlive.Count; i++)
            {
                Console.WriteLine(i + ". " + enemiesAlive[i]);
            }

            int targetedEnemy = -1;
            bool result = int.TryParse(Console.ReadLine(), out targetedEnemy);
            if (!result || targetedEnemy < 0 || targetedEnemy >= enemiesAlive.Count)
            {
                Console.WriteLine("Invalid number. Please try again!");
                InitiateAttack();
            }

            this.Player.Attack(enemiesAlive[targetedEnemy]);
        }

        private void CastSpell()
        {            
            IList<Spell> spells = GetSpells(this.Player);
            if (spells == null || spells.Count == 0)
            {
                Console.WriteLine("There are no spells to cast");
                PlayerMove();
            }

            Console.WriteLine("Please choose a number for the spell you want to cast: ");
            for (int i = 0; i < spells.Count; i++)
            {
                Console.WriteLine(i + ". " + spells[i]);
            }

            int spellNumber = -1;
            bool result = int.TryParse(Console.ReadLine(), out spellNumber);
            

            if (!result || spellNumber < 0 || spellNumber >= spells.Count)
            {
                Console.WriteLine("No such spell in inventory. Please choose again");
                CastSpell();
            }

            try 
            {
                this.Player.CastSpell(spells[spellNumber]);
                this.SpellsUsedByPlayer.Add(spells[spellNumber]);
            }
            catch (InsufficientManaException)
            {
                Console.WriteLine("You don't have enough mana for this spell");
            }
            finally
            {
                PlayerMove();
            }            
        }

        private List<Spell> GetSpells(Player player)
        {
            return this.Player.Inventory.OfType<Spell>().Select(item => item as Spell).ToList();
        }

        private void UsePotion()
        {
            List<Potion> potions = GetPotions(this.Player);
            if (potions == null || potions.Count == 0)
            {
                Console.WriteLine("There are no potions to use");
                PlayerMove();
            }

            Console.WriteLine("Please enter the number of the potion you want to use:");
            for (int i = 0; i < potions.Count; i++)
            {
                Console.WriteLine(i + ". " + potions[i]);
            }

            int potionNumber = -1;
            bool result = int.TryParse(Console.ReadLine(), out potionNumber);
           
            if (!result || potionNumber < 0 || potionNumber >= potions.Count)
            {
                Console.WriteLine("No such potion in inventory. Please choose again");
                UsePotion();
            }

            this.Player.ApplyItemEffects(potions[potionNumber]);
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
                Player.KillCounter++;
            }
        }
    }
}
