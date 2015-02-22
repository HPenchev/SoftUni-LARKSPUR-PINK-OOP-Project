using Game.Core.Data;
using Game.Items.ArmorOfGandalf;
using Game.Items.Spells;
using Game.Items.WeaponOfNakov;

namespace Game.Characters
{
    using System.Text;
    using Core;
    using Core.Data.Constants.PlayerConstatns;

    public class Mage : Player
    {
        public Mage(string id) : base(id)
        {
            this.HealthPoints = MageConstants.HealthPoints;
            this.DefensePoints = MageConstants.DefencePoints;
            this.AttackPoints = MageConstants.AttackPoints;
            this.Mana = MageConstants.Mana;
            this.Range = MageConstants.Range;
            AddStartingItems();
        }

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
    }
}