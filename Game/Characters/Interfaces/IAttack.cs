using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters.Interfaces
{
    public interface IAttack
    {
        int AttackPoints { get; set; }

        void Attack();
    }
}
