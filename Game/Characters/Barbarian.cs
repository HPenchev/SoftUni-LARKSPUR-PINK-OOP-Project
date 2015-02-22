namespace Game.Characters
{
    using System.Text;
    using Core;
    using Core.Data;
    using Core.Data.Constants.PlayerConstatns;

    public class Barbarian : Player
    {
        #region Constructors
        public Barbarian(string id) : base(id)
        {
            this.HealthPoints = BarbarianConstants.HealthPoints;
            this.DefensePoints = BarbarianConstants.DefencePoints;
            this.AttackPoints = BarbarianConstants.AttackPoints;
            this.Mana = BarbarianConstants.Mana;
            this.Range = BarbarianConstants.Range;
            AddStartingItems();
        }
        #endregion
        
        #region Methods
        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Barberian,\n");
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