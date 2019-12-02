using Game1.Player;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using Game1.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.States;
using Game1.Blocks;
using Game1.GameTool;
using Game1.GameStates;
using Game1.Collisions;

namespace Game1.Collisions
{
    class MarioBlockHandler
    {
      
        private void ChangeWorld(IBlock block, Direction direction, IWorld Level, GameStateManager gameState)
        {
            if (direction == Direction.Top && block is Pipe)
            {
                Pipe tempPipe = (Pipe)block;
                if (!tempPipe.isEntrance) return;
                if (Level.Mario.CurrentAnimationState is MarioLeftCrouchState || Level.Mario.CurrentAnimationState is MarioRightCrouchState)
                {

                    gameState.ChangeWorld();
                }
            }

        }

        public  void CheckMarioBlockCollisionLoop(IPlayer mario, IList<IBlock> BlocksAround, IWorld Level, GameStateManager gameState)
        {

            foreach (IBlock block in BlocksAround)
            {
                if (block != null)
                {
                    Rectangle blockBox = block.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(blockBox, mario.Rectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, mario.Rectangle, blockBox);
                       HandleCollision(Level, Level.Mario, block, direction);
                        ChangeWorld(block, direction, Level, gameState);
                    }
                }
            }

        }
        public static void HandleCollision(IWorld level,IPlayer mario, IBlock block, Direction direction)
        {
            block.CollisionWithMario(level,mario, direction);
        }
        public static void UpateLocation(IPlayer mario,IBlock block, Direction direction) 
        {
            switch(direction)
            {
                case Direction.Top:
                    mario.Location = new Vector2(mario.Location.X,block.Location.Y-mario.Rectangle.Height + Util.Instance.Coli_mariBlock_Y_fix);
                    if (mario.CanStandOnBlock) {
                        StandOnBlock(mario);
                    }
                    mario.CanStandOnBlock = true;
                    break;

                case Direction.Left:
                    mario.Location = new Vector2(block.Location.X - mario.Rectangle.Width, mario.Location.Y);
                    mario.CanStandOnBlock = false;
                    break;

                case Direction.Right:
                    mario.Location = new Vector2(block.Location.X + block.Rectangle.Width, mario.Location.Y);
                    mario.CanStandOnBlock = false;
                    break;

                case Direction.Bottom:
                    mario.Location = new Vector2(mario.Location.X, block.Location.Y + block.Rectangle.Height);
                    Drop(mario);
                    break;
            }
        }

        public static void StandOnBlock(IPlayer mario) {
            mario.MarioPhysics.VerticalCalmDown();
            //mario.MarioPhysics.Accerlation = new Vector2(mario.MarioPhysics.Accerlation.X, 0);
            mario.MarioPhysics.ResetJump();
            mario.canKick = true;
            mario.Coefficient = 1;
        }
        private static void Drop(IPlayer mario)
        {
            mario.MarioPhysics.VerticalCalmDown();
         
        }
    }
}
