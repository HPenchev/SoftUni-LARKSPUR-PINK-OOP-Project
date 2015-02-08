using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters.Interfaces
{
    public interface IHeal
    {
        int HealingPoints { get; set; }

        void Healing();
    }
}
