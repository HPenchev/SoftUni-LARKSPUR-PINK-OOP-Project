using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Characters.Interfaces;

namespace Game.Characters.InterractableCharacters
{
    public abstract class InterractableCharacter : Character, IInterractable
    {
        private int range;
        private int hitPoints;
        private int defensePoints;

        public InterractableCharacter(int hitPoints, int defensePoints, Team team, int range)
        {
            this.HitPoints = hitPoints;
            this.DefensePoints = defensePoints;
            this.Team = team;
            this.Range = range;
            this.IsAlive = true;            
        }

        public bool IsAlive { get; set; }

        public int HitPoints {
            get
            {
                return this.hitPoints;
            }

            set
            {
                if (value <= 0)
                {
                    this.IsAlive = false;
                }

                this.hitPoints = value;
            }
        }

        public int DefensePoints {
            get
            {
                return this.defensePoints;
            }
            set
            {
                this.defensePoints = UpdatePoints(value);
            }
        }

        public Team Team { get; set; }

        public IInterractable Target { get; set; }
        
        public int Range
        {
            get
            {
                return this.range;
            }

            set
            {
                if (range < 0)
                {
                    throw new ArgumentOutOfRangeException("Range can't be less than 0;");
                }

                this.range = value;
            }
        }

        public int BattleXCoordinate { get; set; }

        public int BattleYCoordinate { get; set; }

        public abstract void InterractWithTarget();
       
        protected abstract IInterractable PickTarget(IList<IInterractable> potentialTargets);

        protected int UpdatePoints(int value)
        {
            if (value < 0)
            {
                value = 0;
            }

            return value;
        }
    }
}
