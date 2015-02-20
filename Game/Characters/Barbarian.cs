using Game.Items.ArmorOfDragon;
using Game.Items.ArmorOfGandalf;
using Game.Items.WeaponOfNakov;

namespace Game.Characters
{
    using System.Text;
    using Core;
    using Core.Data.Constants.PlayerConstatns;

    public class Barbarian : Player
    {
        public Barbarian(string id) : base(id)
        {
            this.HealthPoints = BarbarianConstants.HealthPoints;
            this.DefensePoints = BarbarianConstants.DefencePoints;
            this.AttackPoints = BarbarianConstants.AttackPoints;
            this.Mana = BarbarianConstants.Mana;
            this.Range = BarbarianConstants.Range;
            AddStartingItems();
        }

        public override string ToString()
        {
            StringBuilder playerToString = new StringBuilder();
            playerToString.Append("Player Type: Barberian,\n");
            playerToString.Append(base.ToString());
            return playerToString.ToString();
        }

        private void AddStartingItems()
        {
            this.Inventory.Add(new SwordOfNakov("Sword"));
            this.Inventory.Add(new ShieldOfGandalf("Shield"));
            this.Inventory.Add(new ChestArmorOfDragon("Armor"));
            this.Inventory.Add(new BootsOfGandalf("Boots"));
        }
    }
}