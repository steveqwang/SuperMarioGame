using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.Player;
using Game1.Utility;

namespace Game1.States
{
    class MarioBigState: IMarioPowerState
    {
        private IPlayer player;
        public string StateName { get => Util.Instance.String_MarioBigState; }

        public MarioBigState(IPlayer player)
        {
            this.player = player;
        }

    }
}
