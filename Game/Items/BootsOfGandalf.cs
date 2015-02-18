using Game.Core;
using Game.Core.Data.Enums;

namespace Game.Items
{
    public class BootsOfGandalf : Armor
    {
        public BootsOfGandalf(string id)
            : base(id)
        {

            this.Id = "The Boots of Gandalf the gray.";
            this.AttackPoints = 0;
            this.AttackSpeed = 5;
            this.ChanceToDodge = 5;
            this.CriticalChance = 5;
            this.CriticalDamage = 25;
            this.DefensePoints = 100;
            this.HealthPoints = 200;
            this.Level = 4;
            this.Price = 130;
            this.Size = 2;
            this.ArmorType = ArmorType.Boots;
        }
    }
}
