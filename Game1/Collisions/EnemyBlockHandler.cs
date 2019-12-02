using Game1.Player;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using Game1.Utility;
using Game1.Factories;
using System.Collections.Generic;

namespace Game1.Collisions
{
    class EnemyBlockHandler
    {

        public void CheckEnemyBlockCollisionLoop(IList<IBlock> BlocksAround, IEnemy enemy)
        {
            foreach (IBlock block in BlocksAround)
            {
                if (block != null)
                {
                    Rectangle blockBox = block.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(blockBox, enemy.Rectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, enemy.Rectangle, blockBox);
                        EnemyBlockHandler.HandleCollision(enemy, block, direction);
                    }
                }
            }
        }
        public static void HandleCollision(IEnemy enemy, IBlock block, Direction direction)
        {
            block.CollisionWithEnemy(enemy, direction);
        }
        public static void UpateLocation(IEnemy enemy, IBlock block, Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    enemy.Location = new Vector2(enemy.Location.X, block.Location.Y - enemy.Rectangle.Height);
                    enemy.EnemyPhysics.EnemyMove();
                    enemy.EnemyPhysics.Accerlation = new Vector2(Util.Instance.Vector_initial_i, Util.Instance.Vector_initial_j);
                    enemy.EnemyPhysics.Velocity = new Vector2(enemy.EnemyPhysics.Velocity.X, Util.Instance.Vector_initial_j);
                    break;

                case Direction.Right:
                    enemy.EnemyPhysics.IsFacingLeft = false;
                    enemy.EnemyPhysics.EnemyMove();
                    enemy.CollidedWithBlock(block);
                    break;

                case Direction.Left:
                    enemy.EnemyPhysics.IsFacingLeft = true;
                    enemy.EnemyPhysics.EnemyMove();
                    enemy.CollidedWithBlock(block);
                    break;
            }

        }
    }
}
