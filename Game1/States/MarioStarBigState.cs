using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.Player;

namespace Game1.States
{
    class MarioStarBigState : IMarioPowerState
    {
        private readonly IPlayer player;
        public string StateName { get => "MarioStarBigState"; }

        public MarioStarBigState(IPlayer player)
        {
            this.player = player;
        }
    }
}