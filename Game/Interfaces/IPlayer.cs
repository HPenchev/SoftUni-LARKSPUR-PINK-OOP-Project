using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IPlayer
    {
        void Attack(ICharacter enemy);
        void CastSpell(IItem item);
        void Display(string args); // string args === stats || items
        void PickUpItem(IItem item);
        void RemoveItem(IItem item);
        ICharacter FindTarget(ICharacter enemy);
        //void Talk(ICharacter);
    }
}
