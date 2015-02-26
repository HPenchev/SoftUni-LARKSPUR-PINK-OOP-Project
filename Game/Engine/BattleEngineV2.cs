using System;
using System.Collections.Generic;
using System.Drawing;
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
            Print.PrintMessage(String.Format("Hero health: {0}, Enemy health: {1}", player.HealthPoints, enemy.HealthPoints));

            bool isTunEnd = false;
            while (isTunEnd == false)
            {
                ShowCommands();
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
                    case "stats":
                        Print.PrintMessage(player.ToString());
                        break;
                    default:
                        Print.PrintMessage("invalid command. Please try again"); 
                        break;
                }

            }

        }

        private void ShowCommands()
        {
            Print.PrintMessage("Available commands: [hit], [cast], [health potion], [mana potion], [stats]");
        }

        private void UseManaPotion()
        {
            if (manaPotions.Count == 0 || manaPotions == null)
            {
           Print.PrintMessageWithAudio("there are no mana potions in the inventory");
            }
            else
            {
                player.ApplyItemEffects(manaPotions[0]);
                Print.PrintMessage(String.Format("Mana potion used. Hero mana: {0}", player.Mana));
                player.RemoveItem(manaPotions[0]);
                manaPotions.Remove(manaPotions[0]);

            }
        }

        private void UseHealthPotion()
        {
            if (healthPotions.Count == 0 || healthPotions == null)
            {
                Print.PrintMessageWithAudio("there are no health potions in the inventory");
            }
            else
            {
                player.ApplyItemEffects(healthPotions[0]);
                Print.PrintMessage(String.Format("Health potion used. Hero health: {0}", player.HealthPoints));
                player.RemoveItem(healthPotions[0]);
                healthPotions.Remove(healthPotions[0]);

            }
        }

        private void PlayerCast()
        {
            if (spells.Count == 0 || spells == null)
            {
                Print.PrintMessageWithAudio("there are no spells in the inventory");
            }
            else
            {
                for (int i = 0; i < spells.Count; i++)
                {
                    Print.PrintMessage(String.Format("ID: [{0}], Name: {1}", i, spells[i].Id));
                }
                string userSepllChoice = Console.ReadLine();
                int spellId;
                if (int.TryParse(userSepllChoice, out spellId))
                {
                    if (spellId == 0 && spellId < spells.Count)
                    {
                        if (spells[spellId].ManaCost <= player.Mana)
                        {
                            Print.PrintMessage(String.Format("Spell {0} has been used.", spells[spellId].Id));
                            player.ApplyItemEffects(spells[spellId]);
                            Print.PrintMessage(player.ToString());
                            lastUsedSpells.Add(spells[spellId]);
                            spells.Remove(spells[spellId]);
                        }
                        else
                        {
                            Print.PrintMessageWithAudio("Not enought mana.");
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
                Print.PrintMessageWithAudio("Enemy Died");
                player.Experience += (decimal)enemy.HealthPoints;
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
                player.IsAlive = false;
                Print.PrintMessageWithAudio("You are dead");
                Print.PrintMessage("Press any key to continue.....");
                //string key = Console.ReadLine();
                Console.Clear();
                Engine engine = new Engine();
                engine.Run();
            }
        }

        private static void ShowStats(Enemy enemy)
        {
            Print.PrintMessage(String.Format("Hero healthpoints: {0}, Enemy healthpoints: {1}",
                player.HealthPoints, enemy.HealthPoints));
        }

        private int SelectEnemy()
        {
            while (true)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Print.PrintMessage(String.Format("ID: [{0}], Enemy healthpoints: {1}, Enemy attackpoints {2}", i, enemies[i].HealthPoints, enemies[i].AttackPoints));
                }
                Print.PrintMessageWithAudio("Please select enemy to attack: ");
                int selectedPlayer;
                if (int.TryParse(Console.ReadLine(), out selectedPlayer))
                {
                    if (selectedPlayer >= 0 && selectedPlayer <= enemies.Count)
                    {
                        return selectedPlayer;
                    }
                }
                Print.PrintMessage("Please enter a valid number");
            }
        }
    }
}