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
           RandomizeEnemiesStats(EnemiesList);
        }
        #endregion

        #region Properties
        public List<Enemy> EnemiesList
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

        public int PlayerLevel
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

        public char EnemyType
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

            if (this.EnemyType == '0') 
            {
                for (int i = 0; i < this.PlayerLevel; i++)
                {
                    itemGenerator = new RandomItemGenerator(this.PlayerLevel);
                    Minion minion = new Minion(DateTime.Now.Millisecond.ToString());
                  this.EnemiesList.Add(minion);
                }

                Boss boss = new Boss(DateTime.Now.Millisecond.ToString());
                itemGenerator = new RandomItemGenerator(this.PlayerLevel);
                boss.Inventory = itemGenerator.ItemsList;
                this.EnemiesList.Add(boss);
            }
        }

        private void RandomizeEnemiesStats(List<Enemy> list)
        {
            Random random = new Random();
            foreach (var enemy in list)
            {
                enemy.AttackPoints = enemy.AttackPoints * random.Next(Math.Abs(this.PlayerLevel - 2), this.PlayerLevel + 2);
                enemy.DefensePoints = enemy.DefensePoints * random.Next(Math.Abs(this.PlayerLevel - 2), this.PlayerLevel + 2);
                enemy.HealthPoints = enemy.HealthPoints * random.Next(Math.Abs(this.PlayerLevel - 2), this.PlayerLevel + 2);
            }
        }
        #endregion
    }
}