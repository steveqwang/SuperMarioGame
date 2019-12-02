using Game1.Player;
using Game1.Interfaces;
using Game1.States;
using Microsoft.Xna.Framework;
using System;
using Game1.Utility;
using Game1.Factories;
using System.Collections.Generic;

namespace Game1.Collisions
{
    class BossBlockHandler
    {

        public void CheckBossBlockCollisionLoop(IList<IBlock> BlocksAround, IBoss boss)
        {
            foreach (IBlock block in BlocksAround)
            {
                if (block != null)
                {
                    Rectangle blockBox = block.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(blockBox, boss.Rectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, boss.Rectangle, blockBox);
                        BossBlockHandler.HandleCollision(boss, block, direction);
                    }
                }
            }
        }
        public static void HandleCollision(IBoss boss, IBlock block, Direction direction)
        {
            block.CollisionWithBoss(boss, direction);
        }
        public static void UpateLocation(IBoss boss, IBlock block, Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    boss.Location = new Vector2(boss.Location.X, block.Location.Y - boss.Rectangle.Height);
                    boss.BossPhysics.BossMove();
                    boss.BossPhysics.Accerlation = new Vector2(Util.Instance.Vector_initial_i, Util.Instance.Vector_initial_j);
                    boss.BossPhysics.Velocity = new Vector2(boss.BossPhysics.Velocity.X, Util.Instance.Vector_initial_j);
                    break;

                case Direction.Right:
                    if (!boss.IsControlled)
                    {
                        boss.BossPhysics.IsFacingLeft = false;
                        boss.BossPhysics.BossMove();
                        boss.State = new BowserMoveState(boss.BossPhysics.IsFacingLeft);
                    }
                    break;

                case Direction.Left:
                    if (!boss.IsControlled)
                    {
                        boss.BossPhysics.IsFacingLeft = true;
                        boss.BossPhysics.BossMove();
                        boss.State = new BowserMoveState(boss.BossPhysics.IsFacingLeft);
                    }
                    break;
            }

        }
    }
}
