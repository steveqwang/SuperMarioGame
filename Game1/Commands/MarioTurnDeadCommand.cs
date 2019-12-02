using Game1.Player;
using Game1.States;
using Game1.Interfaces;

namespace Game1.Commands
{
    class MarioTurnDeadCommand : Interfaces.ICommand
    {
        private IPlayer player;

        //constructor
        public MarioTurnDeadCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.CurrentAnimationState = new MarioDeadState();
        }

    }
}
