using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game.Characters;
using Game.Core;
using Game.Interfaces;
using Game.Items.Potions;

namespace Game.Engine
{
    public class BattleEngineV2
    {
        private static Player player;
        private static List<Enemy> enemies;
        private static List<Spell> spells = new List<Spell>();
        private static List<HealthPotion> healthPotions = new List<HealthPotion>();
        private static List<ManaPotion> manaPotions = new List<ManaPotion>();
        private static List<Spell> lastUsedSpells = new List<Spell>();
        public BattleEngineV2(Player Inplayer, List<Enemy> Inenemies)
        {
            player = Inplayer;
            enemies = Inenemies;
        }

        internal void Run()
        {
            
            GetItems();
            while (enemies.Count >= 0)
            {
                int choice = SelectEnemy();
                Fight(choice);
            }
        }

        private void GetItems()
        {
            foreach (var item in player.Inventory)
            {
                if (item is Spell)
                {
                    spells.Add(item as Spell);
                }
                if (item is HealthPotion)
                {
                    healthPotions.Add(item as HealthPotion);
                }
                if (item is ManaPotion)
                {
                    manaPotions.Add(item as ManaPotion);
                }
            }
        }

        private void Fight(int choice)
        {
            PlayerTurn(enemies[choice]);
            EnemyTurn(enemies);
        }

        private void PlayerTurn(Enemy enemy)
        {

            bool isTunEnd = false;
            if (isTunEnd == false)
            {
                string playerAttackType = Console.ReadLine();
                switch (playerAttackType)
                {
                    case "hit":
                        PlayerHit(enemy);
                        isTunEnd = true;
                        break;
                    case "cast":
                        PlayerCast();
                        break;
                    case "health potion":
                        UseHealthPotion();
                        break;
                    case "mana potion":
                        UseManaPotion();
                        break;
                    default:
                        Console.WriteLine("invalid command. Please try again"); break;
                }
            }
            

        }

        private void UseManaPotion()
        {
            if (manaPotions.Count == 0 || manaPotions == null)
            {
                Console.WriteLine("there are no mana potions in the inventory");
            }
            else
            {
                player.ApplyItemEffects(manaPotions[0]);
                Console.WriteLine("Mana potion used. Hero mana: {0}", player.Mana);
                player.RemoveItem(manaPotions[0]);
            }
        }

        private void UseHealthPotion()
        {
            if (healthPotions.Count == 0 || healthPotions == null)
            {
                Console.WriteLine("there are no health potions in the inventory");
            }
            else
            {
                player.ApplyItemEffects(healthPotions[0]);
                Console.WriteLine("Health potion used. Hero health: {0}", player.HealthPoints);
                player.RemoveItem(healthPotions[0]);
            }
        }

        private void PlayerCast()
        {
            if (spells.Count == 0 || spells == null)
            {
                Console.WriteLine("there are no spells in the inventory");
            }
            else
            {
                for (int i = 0; i < spells.Count; i++)
                {
                    Console.WriteLine("ID: [{0}], Name: {1}", i, spells[i].Id);
                }
                string userSepllChoice = Console.ReadLine();
                int spellId;
                if (int.TryParse(userSepllChoice, out spellId))
                {
                    if (spellId == 0 && spellId < spells.Count)
                    {
                        if (spells[spellId].ManaCost <= player.Mana)
                        {
                            Console.WriteLine("Spell {0} has been used.", spells[spellId].Id);
                            player.ApplyItemEffects(spells[spellId]);
                            Console.WriteLine(player);
                            lastUsedSpells.Add(spells[spellId]);
                            spells.Remove(spells[spellId]);
                        }
                        else
                        {
                            Console.WriteLine("Not enought mana.");
                        }
                    }
                }
            }

        }

        private void PlayerHit(Enemy enemy)
        {
            enemy.HealthPoints -= player.CalculateDamage(enemy);
            lastUsedSpells.ForEach(n => player.RemoveItemEffects(n));
            lastUsedSpells.Clear();
            if (enemy.HealthPoints <= 0)
            {
                Console.WriteLine("Enemy Died");
                enemies.Remove(enemy);
            }
            ShowStats(enemy);
            
        }

        private void EnemyTurn(List<Enemy> enemies)
        {
            double enemiesDamage = 0;
            foreach (var enemy in enemies)
            {
                enemiesDamage += enemy.CalculateDamage(player) - player.AllResistance;
            }
            player.HealthPoints -= enemiesDamage;
            if (player.HealthPoints <= 0)
            {
                Console.WriteLine("You are dead");
                Engine engine = new Engine();
                engine.Run();
            }
        }

        private static void ShowStats(Enemy enemy)
        {
            Console.WriteLine("Hero healthpoints: {0}, Enemy healthpoints: {1}",
                player.HealthPoints, enemy.HealthPoints);
        }

        private int SelectEnemy()
        {
            while (true)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Console.WriteLine("ID: [{0}], Enemy healthpoints: {1}, Enemy attackpoints {2}", i, enemies[i].HealthPoints, enemies[i].AttackPoints);
                }
                Console.WriteLine("Please select enemy to attack: ");
                int selectedPlayer = int.Parse(Console.ReadLine());
                if (selectedPlayer >= 0 && selectedPlayer <= enemies.Count)
                {
                    return selectedPlayer;
                }
            }
        }
    }
}