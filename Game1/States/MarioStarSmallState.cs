using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.Player;

namespace Game1.States
{
    class MarioStarSmallState : IMarioPowerState
    {
        private IPlayer player;
        public string StateName { get => "MarioStarSmallState"; }

        public MarioStarSmallState(IPlayer player)
        {
            this.player = player;
        }
    }
}