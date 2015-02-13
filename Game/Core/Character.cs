using Game.Interfaces;

namespace Game.Core
{
    public abstract class Character : GameObject, ICharacter
    {
        protected bool isAlive = true;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private double range;
       
        protected Character(string id)
            : base(id)
        {
            this.IsAlive = true;
        }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

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

        public int CriticalChance { get; set; } //Chance to do double damage in %

        public double AttackSpeed { get; set; }

        public int ChanceToDodge { get; set; } //Chence to avoid enemy hit in %               

        public Position MapPosition { get; set; }

        public Position BattleMapPosition { get; set; }

        public void Attack(ICharacter enemy)
        {
            double damage = CalculateDamage(this.AttackPoints, enemy.DefensePoints, this.AttackSpeed, this.CriticalChance, enemy.ChanceToDodge);
            enemy.HealthPoints -= damage;
            if (enemy.HealthPoints <= 0)
            {
                enemy.IsAlive = false;
            }
        }

        private double CalculateDamage(double attackPoints, double defensePoints, double attackSpeed, int chanceToCritical, int chanceToDoge)
        {
            double damage = (attackPoints - defensePoints);
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
