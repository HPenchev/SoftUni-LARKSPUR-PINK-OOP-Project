namespace Game.Interfaces
{
    using System.Collections.Generic;
    using Core;

    public interface IPlayer
    {
        int InventorySize { get; set; }

        decimal Gold { get; set; }

        decimal Experience { get; set; }

        int Level { get; set; }

        double Mana { get; set; }

        List<Item> Inventory { get; set; }

       // double Attack(ICharacter enemy);

        void PickUpItem(List<Item> item);

        void RemoveItem(Item item);
    }
}