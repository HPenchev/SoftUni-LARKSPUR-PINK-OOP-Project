namespace Game.Static
{
    using System.Collections.Generic;
    using Core;
    using Interfaces;

    public class Chest : GameObject, IStatic
    {
        private List<Item> items;
        private bool isUsed;

        public Chest(string id)
            : base(id)
        {
            this.items = new List<Item>();
        }

        public List<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public bool IsUsed
        {
            get { return this.isUsed; }
            set { this.isUsed = value; }
        }
    }
}