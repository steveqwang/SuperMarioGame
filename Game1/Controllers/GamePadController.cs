using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Game1.Commands;
using Game1.Interfaces;
using Microsoft.Xna.Framework;

namespace Game1.Controllers
{
    public class GamepadController : IController
    {
        private readonly Dictionary<Buttons, ICommand> buttonCommandDict;


        public void Update(GameTime gametime)
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            foreach (KeyValuePair<Buttons, ICommand> buttonCommandPair in buttonCommandDict)
            {
                if (state.IsButtonDown(buttonCommandPair.Key))
                {
                    buttonCommandPair.Value.Execute();
                }
            }
        }

        public GamepadController(OurMarioGame TheGame)
        {
            OurMarioGame Game = TheGame;
            IPlayer Player = Game.gameStateManager.world.Mario;
            buttonCommandDict = new Dictionary<Buttons, ICommand>
            {
                { Buttons.Start, new PressQToQuitCommand(Game) },
                { Buttons.Back, new PressRToResetCommand(Game)},


                { Buttons.A, new MarioTurnSmallCommand(Player) },
                { Buttons.B, new MarioTurnBigCommand(Player) },
                { Buttons.X, new MarioTurnFireCommand(Player) },
                { Buttons.Y, new MarioTurnDeadCommand(Player) },

                { Buttons.LeftThumbstickUp, new MarioGoUpCommand(TheGame.gameStateManager)  },
                { Buttons.LeftThumbstickDown, new MarioGoDownCommand(TheGame.gameStateManager) },
                { Buttons.LeftThumbstickLeft, new MarioTurnLeftCommand(Player) },
                { Buttons.LeftThumbstickRight, new MarioTurnRightCommand(Player) },
            };
        }

    }
}
