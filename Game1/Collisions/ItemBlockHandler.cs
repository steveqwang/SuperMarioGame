using Game1.Player;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game1.Collisions
{
    class ItemBlockHandler
    {
        public void CheckItemBlockCollisionLoop(IList<IBlock> BlocksAround, Rectangle itemBox, IItem item)
        {
            foreach (IBlock block in BlocksAround)
            {
                if (block != null)
                {
                    Rectangle blockBox = block.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(blockBox, itemBox);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, itemBox, blockBox);
                        ItemBlockHandler.HandleCollision(item, block, direction);
                    }
                }
            }
        }

        public static void HandleCollision(IItem item, IBlock block, Direction direction)
        {
            block.CollisionWithItem(item, direction);
        }
        public static void UpateLocation(IItem item, IBlock block, Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    item.Location = new Vector2(item.Location.X, block.Location.Y - item.Rectangle.Height);
                    item.ItemPhysics.VerticalCalmDown();
                    break;

                case Direction.Right:
                    item.ItemPhysics.isFacingLeft = false;
                    item.ItemPhysics.changeDirection();
                    break;

                case Direction.Left:
                    item.ItemPhysics.isFacingLeft = true;
                    item.ItemPhysics.changeDirection();
                    break;
            }
        }
    }
}
