namespace Game.Characters
{
    using Game.Characters.Interfaces;

    public abstract class Character : GameObject 
    {        
        public Character(string id, Position mapPosition)
            : base(id)
        {
            this.MapPosition = mapPosition;
        }

        public Position MapPosition { get; set; }              
    }
} 