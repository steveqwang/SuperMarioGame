using Game1.Interfaces;
using Game1.States;
using Game1.Player;
using Microsoft.Xna.Framework;
using System;
using Game1.Factories;

namespace Game1.Collisions
{
    class MarioEnemyHandler
    {
        public void CheckMarioEnemyCollision(Rectangle marioBox, IWorld Level)
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyBox = enemy.Rectangle;
                Rectangle intersectionBox = Rectangle.Intersect(enemyBox, marioBox);
                if (!intersectionBox.IsEmpty)
                {
                    Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, marioBox, enemyBox);
                    MarioEnemyHandler.HandleCollision(Level.Mario, enemy, direction);

                }
            }
        }

        public static void HandleCollision(IPlayer mario,IEnemy enemy,Direction direction)
        {

            if (direction == Direction.Top)
            {
                mario.MarioPhysics.VerticalCalmDown();
                mario.MarioPhysics.ResetJump();
            }

            if (!(mario.CurrentAnimationState is MarioDeadState))
            {
                enemy.CollidedWithMario(mario, direction);
            }
        }

    }
}
