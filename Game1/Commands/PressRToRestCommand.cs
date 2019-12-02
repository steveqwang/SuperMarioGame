using Game1.Commands;
using Game1.Player;
using Game1.Interfaces;
using System.Collections.Generic;
using Game1.Controllers;
using Game1.Collisions;
using Game1.Factories;
using Game1.GameStates;

namespace Game1.Commands
{
    class PressRToResetCommand : Interfaces.ICommand
    {
        private OurMarioGame GameClass;

        public void Execute()
        {
            if(GameClass.gameStateManager.state is WorldState)
            {
                WorldState temp = (WorldState)GameClass.gameStateManager.state;
                if(temp.level == WorldState.WorldLevel.World1_1)
                {
                    GameClass.gameStateManager.ChangeToPrimaryWorld();
                }else if(temp.level == WorldState.WorldLevel.World1_2)
                {
                    GameClass.gameStateManager.ChangeToUnderground();
                }
                else
                {
                    GameClass.gameStateManager.ChangeToBowserWorld();
                }
            }
            
            //GameClass.ControllersList = new List<IController>();
            //GameClass.ControllersList.Add(new KeybroadController(GameClass));
            //GameClass.ControllersList.Add(new GamepadController(GameClass));
            //GameClass.ControllersList.Add(new MouseController(GameClass));
            //GameClass.collisionDetection = new AllCollisionHandler(GameClass.gameStateManager);
        }
        public PressRToResetCommand(OurMarioGame CurrentGameClass)
        {
            this.GameClass = CurrentGameClass;
        }

    }
}

