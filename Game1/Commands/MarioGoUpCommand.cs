using Game1.Player;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.PhysicalProperty;
using Game1.States;
using Game1.GameStates;

namespace Game1.Commands
{
    class MarioGoUpCommand : Interfaces.ICommand
    {
        private GameStateManager gameStateManager;
        //constructor
        public MarioGoUpCommand(GameStateManager gameStateManager)
        {
            // this.player = player;
            //marioPhysics = player.MarioPhysics;
            this.gameStateManager = gameStateManager;
        }
        public void Execute()
        {
            gameStateManager.Up();
           // if (player.CurrentAnimationState is MarioDeadState) return;
           // player.IsIdle = false;
            // player.Location += new Vector2(0, -2);

            //marioPhysics.jump();
           // player.CurrentAnimationState.Up();



        }
    }
}
