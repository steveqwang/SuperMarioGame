using Game1.GameStates;
using Game1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Commands
{
    public class ActionCommand : ICommand
    {
        GameStateManager gameStateManager;
        public ActionCommand(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
        }

        public void Execute()
        {
            gameStateManager.Action();
        }
    }
}

