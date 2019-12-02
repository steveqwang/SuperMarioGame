using Game1.GameTool;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.GameStates;
using Game1.Utility;

namespace Game1.Collisions
{
    public class MarioCastleCollisionHandler
    {
        public void CheckMarioCastleCollision(Rectangle marioBox, IWorld Level, GameStateManager gameState)
        {
            foreach (FlagStuff flag in Level.FlagStuffs) {
                foreach (Castle castle in Level.Castles)
                {
                    Rectangle castleBox = castle.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(castleBox, marioBox);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, marioBox, castleBox);
                        if (flag.FinishFlagStuff) {
                            MarioCastleCollisionHandler.HandleCollision(gameState, castle, direction);
                        }
                    }
                }
            }
        }
        public static void HandleCollision(GameStateManager gameState, Castle castle, Direction direction)
        {
            IPlayer mario = gameState.world.Mario;
            Vector2 marioLocation = mario.Location;
            Vector2 castleLocation = castle.Location;

            float winDoorLeftSide = (castleLocation.X + 20);
            float winDoorRightSide = (castleLocation.X + castle.Rectangle.Width - 20);
            float winDoorUpSide = (castleLocation.Y + 20);

            if(mario.Location.X > winDoorLeftSide && mario.Location.X < winDoorRightSide && !(gameState.state is GameWinState))
            {
                gameState.ChangeToBowserWorld();
               
            }
        }
    }
}
