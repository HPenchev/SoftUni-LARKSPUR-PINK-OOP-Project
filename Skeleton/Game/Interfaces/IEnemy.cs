using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IEnemy
    {
        ICharacter FindTarget(ICharacter player); //target not found exception
        void Attack(ICharacter player);
        void DropReward(); // should drop gold and items
    }
}
