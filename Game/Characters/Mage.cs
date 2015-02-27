namespace Game.Characters
{
    using System;
    using System.Text;
    using Core;
    using Core.Data;
    using Core.Data.Constants.PlayerConstatns;

    [Serializable]
    public class Mage : Player
    {
        #region Constructors
        public Mage(string id)
            : base(id)
        {
            this.HealthPoints = MageConstants.HealthPoints;
            this.DefensePoints = MageConstants.DefencePoints;
            this.AttackPoints = MageConstants.AttackPoints;
            this.Mana = MageConstants.Mana;
            this.Range = MageConstants.Range;
            AddStartingItems();
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Mage,\n");
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