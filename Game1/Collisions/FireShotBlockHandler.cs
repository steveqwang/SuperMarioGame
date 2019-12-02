using Game1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Utility;
using Game1.Factories;
using Microsoft.Xna.Framework;
using Game1.GameTool;

namespace Game1.Collisions
{
    public class FireShotBlockHandler
    {
        public void FireShotHandleLoop(IList<IBlock> BlocksAround, FireShot fireshot)
        {
            foreach (IBlock block in BlocksAround)
            {
                if (block != null)
                {
                    Rectangle blockBox = block.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(blockBox, fireshot.Rectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, fireshot.Rectangle, blockBox);
                        HandleCollision(fireshot, block, direction);
                    }
                }
            }
        }

        private void HandleCollision(FireShot fireshot, IBlock block, Direction direction)
        {
            fireshot.IsRemove = true;
        }
    }
}
