using Game1.Player;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.Utility;

namespace Game1.Commands
{
    class MarioTurnLeftCommand : Interfaces.ICommand
    {
        private IPlayer player;

        //constructor
        public MarioTurnLeftCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            if (player.CurrentAnimationState is MarioDeadState || player.CurrentAnimationState is MarioEndGameState) return;
            player.isFacingLeft = true;
            player.IsIdle = false;
            player.Location += new Vector2(Util.Instance.Turn_left_vec_x, Util.Instance.Vector_initial_j);
            player.PreviousAnimationState = player.CurrentAnimationState;
            player.MarioPhysics.Run();
            player.CurrentAnimationState.Left();
        }
    }
}
