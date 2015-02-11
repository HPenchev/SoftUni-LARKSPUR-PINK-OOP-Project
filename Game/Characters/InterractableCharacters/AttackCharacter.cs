namespace Game.Characters.InterractableCharacters
{
    using Game.Characters.Interfaces;

    public abstract class AttackCharacter : InterractableCharacter, IAttack
    {
        private int attackPoints = 0;

        public AttackCharacter(
            string id, 
            Position mapPosition,
            Team team, 
            int hitPoints, 
            int defensePoints,
            int range, 
            int attackPoints)
            : base(id, mapPosition, team, hitPoints, defensePoints, range)
        {
            this.AttackPoints = attackPoints;
        }      

        public int AttackPoints
        { 
            get
            {
                return this.attackPoints;
            }

            set
            {
                this.attackPoints = this.UpdatePoints(value);
            }           
        }           

        public override void InterractWithTarget()
        {
            int damage = this.AttackPoints - this.Target.DefensePoints;

            this.Target.HitPoints -= damage;
        }               
    }
}