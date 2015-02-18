namespace Game.Core
{
    public abstract class Map : GameObject
    {
        public double minX { get; set; }
        public double maxX{ get; set; }
        public double minY { get; set; }
        public double maxY { get; set; }

        protected Map(string id,  double minX, double minY, double maxX, double maxY) : base(id)
        {

        }
    }
}
