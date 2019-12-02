using Game1.Player;
using Game1.Interfaces;

namespace Game1.Commands
{
    class MarioTurnIdleCommand : Interfaces.ICommand
    {
        private IPlayer player;

        //constructor
        public MarioTurnIdleCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.CurrentAnimationState.Idle();
        }

    }
}
