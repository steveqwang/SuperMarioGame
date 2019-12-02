using Game1.Player;
using Game1.States;
using Game1.Interfaces;

namespace Game1.Commands
{
    class MarioTurnSmallCommand : Interfaces.ICommand
    {
        private IPlayer player;

        //constructor
        public MarioTurnSmallCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.CurrentPowerState = new MarioSmallState(player);
            player.CurrentAnimationState = new MarioRightIdleState(player);
        }

    }
}
