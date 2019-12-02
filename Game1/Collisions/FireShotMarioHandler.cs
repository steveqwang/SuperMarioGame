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
    public class FireShotMarioHandler
    {
        public void FireShotHandleLoop(IPlayer mario, FireShot fireshot)
        {
            Rectangle marioBox = mario.Rectangle;
            Rectangle intersectionBox = Rectangle.Intersect(marioBox, fireshot.Rectangle);
            if (!intersectionBox.IsEmpty)
            {
                Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, mario.Rectangle, fireshot.Rectangle);
                HandleCollision(mario, fireshot, direction);
            }
        }

        private void HandleCollision(IPlayer mario, FireShot fireshot, Direction direction)
        {
            fireshot.IsRemove = true;
            if(!(mario.CurrentPowerState is MarioStarBigState || mario.CurrentPowerState is MarioStarSmallState))
            {
                mario.TakeDamage();
            }
            
        }
    }
}
