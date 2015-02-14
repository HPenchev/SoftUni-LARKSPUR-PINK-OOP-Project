namespace Game.Core
{
    using Game.Interfaces;
    using Game.Core.Data.Enums;
    public abstract class Character : GameObject, ICharacter
    {
        private bool isAlive = true;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private double range;
        
        protected Character(
            string id, 
            double healthPoints,
            double defensePoints, 
            double range, 
            double attackPoints = 0, 
            double attackSpeed = 1,
            int criticalChance = 0,
            int chanceToDoge = 0,
            int level = 1)
            : base(id)
        {
            this.IsAlive = true;
            this.Level = level;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Range = range;
            this.CriticalChance = criticalChance;
            this.ChanceToDodge = chanceToDoge;
        }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public int Level { get; set; }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            set { this.defensePoints = value; }
        }       

        public double Range
        {
            get { return this.range; }
            set { this.range = value; }
        }

        public int CriticalChance { get; set; } // Chance to do double damage in %

        public double AttackSpeed { get; set; }

        public int ChanceToDodge { get; set; } // Chence to avoid enemy hit in %               
        
        public Position BattleMapPosition { get; set; }

        public Team Team { get; set; }

        public void Attack(ICharacter enemy)
        {
            double damage = this.CalculateDamage(this.AttackPoints, enemy.DefensePoints, this.AttackSpeed, this.CriticalChance, enemy.ChanceToDodge);
            enemy.HealthPoints -= damage;
            if (enemy.HealthPoints <= 0)
            {
                enemy.IsAlive = false;
            }
        }

        private double CalculateDamage(double attackPoints, double defensePoints, double attackSpeed, int chanceToCritical, int chanceToDoge)
        {
            double damage = attackPoints - defensePoints;
            if (damage < 1)
            {
                damage = 1;
            }

            int criticalHitRandom = Randomizer.rand.Next(100) + 1;
            if (chanceToCritical >= criticalHitRandom)
            {
                damage *= 2; 
            }

            int dodgeRandom = Randomizer.rand.Next(100) + 1;

            if (chanceToDoge >= dodgeRandom)
            {
                damage = 0;
            }

            return damage;
        }
    }
}
