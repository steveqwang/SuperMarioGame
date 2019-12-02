using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Game1.Commands;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Game1.Player;

namespace Game1.Controllers
{
    public class KeybroadController : IController
    {
        OurMarioGame Game;
        //implement the defautl Update() method
        public void Update(GameTime gametime)
        {
            KeyboardState state = Keyboard.GetState();
            foreach (KeyValuePair<Keys, ICommand> CurrentPair in MappingDictionary)
            {
                if (state.IsKeyDown(CurrentPair.Key))
                {
                    if(CurrentPair.Key == Keys.Enter && Game.gameStateManager.state.isPause || !Game.gameStateManager.state.isPause)
                    {
                        CurrentPair.Value.Execute();
                    }
                    
                }
            }
        }
        private readonly Dictionary<Keys, ICommand> MappingDictionary;

        public KeybroadController(OurMarioGame TheGame)
        {
             Game = TheGame;
            IPlayer Player = Game.gameStateManager.world.Mario;

            MappingDictionary = new Dictionary<Keys, ICommand>
            {
                { Keys.Q, new PressQToQuitCommand(Game) },
                //{ Keys.R, new PressRToResetCommand(Game)},

                { Keys.A, new MarioTurnLeftCommand(Player) },
                { Keys.Left, new MarioTurnLeftCommand(Player) },
                { Keys.D, new MarioTurnRightCommand(Player) },
                { Keys.Right, new MarioTurnRightCommand(Player) },

                { Keys.S, new MarioGoDownCommand(TheGame.gameStateManager) },
                { Keys.Down, new MarioGoDownCommand(TheGame.gameStateManager) },
                { Keys.W, new MarioGoUpCommand(TheGame.gameStateManager) },
                { Keys.Up, new MarioGoUpCommand(TheGame.gameStateManager) },

                //{ Keys.U, new MarioTurnBigCommand(Player) },
                //{ Keys.Y, new MarioTurnSmallCommand(Player) },
                //{ Keys.I, new MarioTurnFireCommand(Player) },
                //{ Keys.O, new MarioTurnDeadCommand(Player) },
                //{ Keys.M, new MouseCommand(Game)},

               { Keys.B, new MarioPowerupCommand(Player) },
                {Keys.LeftShift, new MarioFireBallCommand(Player) },
                {Keys.Enter,new ActionCommand(TheGame.gameStateManager) },

            };
        }
        
    }
}
