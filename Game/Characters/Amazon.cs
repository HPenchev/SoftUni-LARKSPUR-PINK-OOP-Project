namespace Game.Characters
{
    using System.Text;
    using Core;
    using Core.Data;
    using Core.Data.Constants.PlayerConstatns;
   
    public class Amazon : Player
    {
        #region Constructors
        public Amazon(string id) : base(id)
        {
            this.HealthPoints = AmazonConstants.HealthPoints;
            this.DefensePoints = AmazonConstants.DefencePoints;
            this.AttackPoints = AmazonConstants.AttackPoints;
            this.Mana = AmazonConstants.Mana;
            this.Range = AmazonConstants.Range;
            AddStartingItems();
        }
        #endregion
        
        #region Methods
        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Amazon,\n");
            playerToString.Append(base.ToString());
            return playerToString.ToString();
        }

        private void AddStartingItems()
        {
            RandomItemGenerator itemGenerator = new RandomItemGenerator(this.Level);
            this.Inventory.AddRange(itemGenerator.ItemsList);
            this.UpdateInventorySpace();
        }
        #endregion
    }
}