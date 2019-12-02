using Game1.Player;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.PhysicalProperty;
using Game1.Utility;
using Game1.Factories;

namespace Game1.Commands
{
    class MarioFireBallCommand : Interfaces.ICommand
    {
      
        private IPlayer player;
        private int delay = Util.Instance.Fireball_command_delay;
        // constructor
        
        public MarioFireBallCommand(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            if(player.CurrentPowerState is MarioFireState)
            {
                if(delay == Util.Instance.Fireball_command_delay)
                {
                    SoundFactory.Instance.PlayFireballSound();
                    Fireball fireball = new Fireball(player.Location, player.isFacingLeft);
                    player.fireballs.Add(fireball);
                    player.fireballPhysicalProperties.Add(new FireballPhysicalProperty(fireball, false));
                }
                delay--;
                if (delay == Util.Instance.Fireball_command_delay_zero)
                {
                    delay = Util.Instance.Fireball_command_delay;
                }
                
            }
        }
    }
}
