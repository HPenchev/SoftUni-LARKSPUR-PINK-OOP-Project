namespace Game.Characters
{
    using System;
    using System.Text;
    using Core;
    using Core.Data;
    using Core.Data.Constants.PlayerConstatns;

    [Serializable]
    public class Druid : Player
    {
        #region Constructors
        public Druid(string id)
            : base(id)
        {
            this.HealthPoints = DruidConstants.HealthPoints;
            this.DefensePoints = DruidConstants.DefencePoints;
            this.AttackPoints = DruidConstants.AttackPoints;
            this.Mana = DruidConstants.Mana;
            this.Range = DruidConstants.Range;
            AddStartingItems();
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Driud,\n");
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