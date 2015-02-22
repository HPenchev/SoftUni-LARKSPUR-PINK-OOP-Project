namespace Game.Core.Data
{
    using System;
    using System.Collections.Generic;
    using Enemies;

    public class RandomEnemyGenerator
    {
        #region Fields
        private List<Enemy> enemiesList;
        private int playerLevel;
        private char enemyType;
        #endregion

        #region Constructors
        public RandomEnemyGenerator(int playerLevel, char enemyType)
        {
            this.EnemiesList = new List<Enemy>();
            this.PlayerLevel = playerLevel;
            this.EnemyType = enemyType;
            GetRandomEnemies();
            RandomizeEnemiesStats();
        }
        #endregion

        #region Properties
        private List<Enemy> EnemiesList
        {
            get
            {
                return this.enemiesList;
            }

            set
            {
                this.enemiesList = value;
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
                this.playerLevel = value;
            }
        }

        private char EnemyType
        {
            get
            {
                return this.enemyType;
            }

            set
            {
                this.enemyType = value;
            }
        }
        #endregion

        #region Methods
        private void GetRandomEnemies()
        {
            RandomItemGenerator itemGenerator = new RandomItemGenerator(this.PlayerLevel);
            if (this.EnemyType == 'M')
            {
                Minion minion = new Minion(DateTime.Now.Millisecond.ToString());
                minion.Inventory = itemGenerator.ItemsList;
                this.EnemiesList.Add(minion);
            }

            if (this.EnemyType == 'B')
            {
                Boss boss = new Boss(DateTime.Now.Millisecond.ToString());
                boss.Inventory = itemGenerator.ItemsList;
                this.EnemiesList.Add(boss);
            }

            if (this.EnemyType == '0') //// Mob
            {
                //// Add as many minions as the player's level
                for (int i = 0; i < this.PlayerLevel; i++)
                {
                    itemGenerator = new RandomItemGenerator(this.PlayerLevel);
                    Minion minion = new Minion(DateTime.Now.Millisecond.ToString());
                    minion.Inventory = itemGenerator.ItemsList;
                    this.EnemiesList.Add(minion);
                }
                // Add one Boss
                Boss boss = new Boss(DateTime.Now.Millisecond.ToString());
                itemGenerator = new RandomItemGenerator(this.PlayerLevel);
                boss.Inventory = itemGenerator.ItemsList;
                this.EnemiesList.Add(boss);
            }
        }
        private void RandomizeEnemiesStats()
        {
            Random random = new Random();
            foreach (var enemy in this.EnemiesList)
            {
                enemy.AttackPoints = enemy.AttackPoints * random.Next(Math.Abs(this.PlayerLevel - 2), this.PlayerLevel + 2);
                enemy.DefensePoints = enemy.DefensePoints * random.Next(Math.Abs(this.PlayerLevel - 2), this.PlayerLevel + 2);
                enemy.HealthPoints = enemy.HealthPoints * random.Next(Math.Abs(this.PlayerLevel - 2), this.PlayerLevel + 2);
            }
        }
        #endregion
    }
}