using System;
using System.Collections.Generic;
using Game.Interfaces;
using Game.Items;

namespace Game.Enemies
{
    using Core;
    public class Minion : Enemy
    {

        public Minion(string id) : base(id)
        {
           
        }

        public override ICharacter FindTarget(ICharacter player)
        {
            throw new System.NotImplementedException();
        }

        public override void Attack(ICharacter player)
        {
            throw new System.NotImplementedException();
        }
        
        public override void DropReward()
        {
        }
    }
}