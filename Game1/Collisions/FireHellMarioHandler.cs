using Game1.GameTool;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Game1.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Collisions
{
    public class FireHellMarioHandler
    {

        public void FireHellHandleLoop(IPlayer mario, FireHell fireHell)
        {
            Rectangle marioBox = mario.Rectangle;
            Rectangle intersectionBox = Rectangle.Intersect(marioBox, fireHell.Rectangle);
            if (!intersectionBox.IsEmpty)
            {
                Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, mario.Rectangle, fireHell.Rectangle);
                HandleCollision(mario, fireHell, direction);
            }
        }

        private void HandleCollision(IPlayer mario, FireHell fireHell, Direction direction)
        {
            fireHell.IsRemove = true;
            if (!(mario.CurrentPowerState is MarioStarBigState || mario.CurrentPowerState is MarioStarSmallState))
            {
                mario.TakeDamage();

            }

        }

    }
}
