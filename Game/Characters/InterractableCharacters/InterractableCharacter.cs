namespace Game.Characters.InterractableCharacters
{
    using System;
    using System.Collections.Generic;
    using Game.Characters.Interfaces;

    public abstract class InterractableCharacter : Character, IInterractable
    {
        private int range;
        private int hitPoints;
        private int defensePoints;

        public InterractableCharacter(string id, Position mapPosition, Team team, int hitPoints, int defensePoints, int range)
            : base(id, mapPosition)
        {           
            this.HitPoints = hitPoints;
            this.DefensePoints = defensePoints;
            this.Team = team;
            this.Range = range;
            this.IsAlive = true;
            this.BattleMapPosition = new Position(0, 0);
        }

        public bool IsAlive { get; set; }

        public int HitPoints 
        {
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

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            set
            {
                this.defensePoints = this.UpdatePoints(value);
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Range can't be less than 0;");
                }

                this.range = value;
            }
        }

        public Position BattleMapPosition { get; set; }

        public abstract void InterractWithTarget();
       
        public abstract IInterractable PickTarget(IList<IInterractable> potentialTargets);

        public void MakeAMapMove(Direction direction)
        {
            this.MapPosition = this.Move(this.MapPosition, direction);
        }

        public void MakeABattleMapMove(Direction direction)
        {
            this.BattleMapPosition = this.Move(this.BattleMapPosition, direction);
        }
                
        protected int UpdatePoints(int value)
        {
            if (value < 0)
            {
                value = 0;
            }

            return value;
        }

        private Position Move(Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.Back:
                    position.Y--;
                    break;

                case Direction.Front:
                    position.Y++;
                    break;

                case Direction.Left:
                    position.X--;
                    break;

                case Direction.Right:
                    position.X++;
                    break;
            }

            return position;
        }
    }
}