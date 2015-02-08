using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters.Interfaces
{
    public interface IInterractable
    {
        bool IsAlive { get; set; }

        int HitPoints { get; set; }

        int DefensePoints { get; set; }

        Team Team { get; set; }

        IInterractable Target { get; set; }

        int Range { get; set; }
    }
}
