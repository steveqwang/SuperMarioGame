using Game1.Interfaces;
using Game1.States;
using Game1.Player;
using Microsoft.Xna.Framework;
using System;
using Game1.Factories;

namespace Game1.Collisions
{
    class MarioBossHandler
    {
        public void CheckMarioBossCollision(Rectangle marioBox, IWorld Level)
        {
            foreach (IBoss boss in Level.Bosses)
            {
                Rectangle bossBox = boss.Rectangle;
                Rectangle intersectionBox = Rectangle.Intersect(bossBox, marioBox);
                if (!intersectionBox.IsEmpty)
                {
                    Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, marioBox, bossBox);
                    HandleCollision(Level.Mario, boss, direction);

                }
            }
        }

        public static void HandleCollision(IPlayer mario, IBoss boss, Direction direction)
        {
          
            if (direction == Direction.Top)
            {
                mario.MarioPhysics.VerticalCalmDown();
                mario.MarioPhysics.ResetJump();
            }

            if (!(mario.CurrentAnimationState is MarioDeadState))
            {
                boss.CollidedWithMario(mario, direction);
            }
        }

    }
}
