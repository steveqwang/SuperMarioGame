using Game1.Interfaces;
using Game1.Player;
using Game1.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Commands
{
    public class MarioPowerupCommand : ICommand
    {
        public IPlayer player;
        public MarioPowerupCommand(IPlayer mario)
        {
            player = mario;
        }

        public void Execute()
        {
            
            
        }
    }
}
