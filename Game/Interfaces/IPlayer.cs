using Game.Core;

namespace Game.Interfaces
{
    public interface IPlayer
    {
        void Attack(ICharacter enemy);
        void CastSpell(Spell id);
        void Display(string args); // string args === stats || items
        void PickUpItem(IItem item);
        void RemoveItem(string Id);
        ICharacter FindTarget(ICharacter enemy);
        //void Talk(ICharacter);
    }
}
