using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Characters.Interfaces;

namespace Game.Characters.InterractableCharacters
{
    public abstract class AttackCharacter : InterractableCharacter, IAttack
    {
        private int attackPoints;

        public AttackCharacter(int hitPoints, int defensePoints, Team team, int range)
            : base(hitPoints, defensePoints, team, range)
        {
        }      

        public int AttackPoints { 
            get
            {
                return this.attackPoints;
            }

            set
            {
                value = UpdatePoints(value);
            }           
        }           

        public void Attack()
        {
            int damage = this.AttackPoints - this.Target.DefensePoints;

            this.Target.HitPoints -= damage;
        }               
    }
}
