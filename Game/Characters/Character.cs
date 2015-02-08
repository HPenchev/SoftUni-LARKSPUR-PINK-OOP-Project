using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Characters.Interfaces;

namespace Game.Characters
{
    public abstract class Character : GameObject 
    {
        public int GameXCoordinate { get; set; }

        public int GameYCoordinate { get; set; }
    }
}
