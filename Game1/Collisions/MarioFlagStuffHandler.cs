using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Factories;
using Game1.GameTool;
using Game1.Interfaces;
using Game1.States;
using Game1.Player;
using Microsoft.Xna.Framework;
using Game1.Utility;
using Game1.GameStates;

namespace Game1.Collisions
{
    public class MarioFlagStuffHandler
    {
        public void CheckMarioFlagCollision(Rectangle marioBox, IWorld Level, GameStateManager gameState)
        {
            foreach (FlagStuff flag in Level.FlagStuffs)
            {
                Rectangle flagBox = flag.Rectangle;
                Rectangle intersectionBox = Rectangle.Intersect(flagBox, marioBox);
                if (!intersectionBox.IsEmpty)
                {
                    Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, marioBox, flagBox);
                    MarioFlagStuffHandler.HandleCollision(Level.Mario, flag, direction, gameState);
                }
            }
        }
        public static void HandleCollision(IPlayer mario, FlagStuff flagStuff, Direction direction, GameStateManager gameState)
        {
            Vector2 marioLocation = mario.Location;
            Vector2 flagStuffLocation = flagStuff.Location;
            mario.Location = new Vector2(flagStuff.Location.X, mario.Location.Y);
            gameState.world.Mario.Scores += (int)gameState.Totaltimer;
            gameState.freezeTimer();

            if (!flagStuff.FinishFlagStuff)
            {
                if(flagStuff.FrameIndex == 1)
                {
                    SoundFactory.Instance.PlayReachFlagStuffSound();
                }
                flagStuff.LowerFlagStuff = true;
                mario.MarioPhysics.IsEndGame = true;
                mario.CurrentAnimationState = new MarioClimbState(mario);
                mario.MarioPhysics.DragFlag();
                mario.MarioPhysics.ResetJump();
            }
            else
            {
                mario.Location += new Vector2(Util.Instance.TwoFive,Util.Instance.Zero);
                mario.MarioPhysics.IsEndGame = true;
                mario.CurrentAnimationState = new MarioEndGameState(mario);
            }

            
        }
    }
}
