using Game1.Player;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.Utility;
using Game1.GameStates;

namespace Game1.Commands
{
    class MarioGoDownCommand : Interfaces.ICommand
    {
        private GameStateManager gameStateManager;
        //constructor
        public MarioGoDownCommand(GameStateManager gameStateManager)
        {
            //this.player = player;
            this.gameStateManager = gameStateManager;
        }
        public void Execute()
        {
            //player.IsIdle = false;
            //if (player.CurrentPowerState is MarioBigState || player.CurrentPowerState is MarioStarBigState || player.CurrentPowerState is MarioFireState)
            //{
            //    player.Location += new Vector2(Util.Instance.Vector_initial_i, Util.Instance.Go_down_vec2_y);
            //}

            gameStateManager.Down();
            //player.CurrentAnimationState.Down();
        }
    }
}
