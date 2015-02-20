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
            this.Inventory.Add(new ArmorOfGandalf("Gandi's Chest"));
            this.Inventory.Add(new WandOfNakov("Nakov's middle finger"));
            this.Inventory.Add(new BootsOfGandalf("Gandi's dirty shoes."));
            this.Inventory.Add(new SpellOfHealth("Gandalf's apple"));
        }
    }
}