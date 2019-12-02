 using Game1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Utility;
using Game1.Factories;
using Microsoft.Xna.Framework;

namespace Game1.Collisions
{
    class FireBallBlockHandler
    {
        public void FireBallHandleLoop(IList<IBlock> BlocksAround, Fireball fireball)
        {
            foreach (IBlock block in BlocksAround)
            {
                if (block != null)
                {
                    Rectangle blockBox = block.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(blockBox, fireball.Rectangle);
                    if (!intersectionBox.IsEmpty)
                    {
                        Direction direction = AllCollisionHandler.GetCollisionDirection(intersectionBox, fireball.Rectangle, blockBox);
                        HandleCollision(fireball, block, direction);
                    }
                }
            }
        }
        public static void HandleCollision(Fireball fireball, IBlock block, Direction direction)
        {
            block.CollisionWithGameObject(fireball, direction);
        }
        public static void UpdateLocation(Fireball fireball, IBlock block, Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    fireball.Location = new Microsoft.Xna.Framework.Vector2(fireball.Location.X, block.Location.Y - fireball.Rectangle.Height);
                    fireball.FireballPhysicalProperty.Velocity = new Microsoft.Xna.Framework.Vector2(fireball.FireballPhysicalProperty.Velocity.X, Util.Instance.Vector_fireball_j);
                    fireball.FireballPhysicalProperty.Jump();
                    break;
                case Direction.Bottom:
                    fireball.FireballPhysicalProperty.Jump();
                    fireball.Location = new Microsoft.Xna.Framework.Vector2(fireball.Location.X, block.Location.Y - fireball.Rectangle.Height);
                    fireball.FireballPhysicalProperty.Velocity = new Microsoft.Xna.Framework.Vector2(fireball.FireballPhysicalProperty.Velocity.X, Util.Instance.Vector_fireball_j);
                    fireball.FireballPhysicalProperty.Jump();
                    break;
                case Direction.Left:
                case Direction.Right:
                    fireball.Explode();
                    SoundFactory.Instance.PlayBumpBlockSound();
                    break;
            }
        }
    }
}
