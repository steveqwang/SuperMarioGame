using Game1.Player;
using Game1.States;
using Game1.Interfaces;

namespace Game1.Commands
{
    class MarioTurnFireCommand : Interfaces.ICommand
    {
        private IPlayer player;

        //constructor
        public MarioTurnFireCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.CurrentPowerState = new MarioFireState(player);
            player.CurrentAnimationState = new MarioRightIdleState(player);
        }

    }
}
