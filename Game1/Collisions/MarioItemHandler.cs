using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Player;
using Game1.Interfaces;
using Game1.States;
using Microsoft.Xna.Framework;

namespace Game1.Collisions
{
    
    public  class MarioItemHandler
    {
        public void CheckMarioItemCollision(Rectangle marioBox, IWorld Level)
        {

            foreach (IItem item in Level.Items)
            {
                Rectangle itemBox = item.Rectangle;
                Rectangle intersectionBox = Rectangle.Intersect(itemBox, marioBox);
                if (!intersectionBox.IsEmpty)
                {
                    MarioItemHandler.HandleCollision(Level.Mario, item);
                }
            }
        }
        public static void HandleCollision(IPlayer mario, IItem item) {
            if (mario.CurrentAnimationState is MarioDeadState) {
                return;
            }
            if (!item.HaveCollision) { // only execute when item does not have collision before
                item.CollidedWithMario(mario); 
            }
        }
    }
}
