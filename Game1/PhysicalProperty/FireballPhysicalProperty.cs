using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Interfaces;

namespace Game1.PhysicalProperty
{
    public class FireballPhysicalProperty
    {
        private Fireball fireball;
        public Vector2 Velocity { get; set; }
        public Vector2 Location { get; set; }
        public bool Locked;
        private Vector2 Acceleration;
        public FireballPhysicalProperty(Fireball fireball, bool locked)
        {
            this.fireball = fireball;
            Location = fireball.Location;
            Velocity = new Vector2(0, 0);

            if (fireball.IsLeft)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
            Acceleration = new Vector2(0, 80);

            Locked = locked;
        }

        public void Jump()
        {
            Velocity += new Vector2(0f, -50f);
        }

        public void MoveLeft()
        {
            Velocity = new Vector2(-200f, Velocity.Y);
        }

        public void MoveRight()
        {
            Velocity = new Vector2(200f, Velocity.Y);
        }
        public void Update(GameTime gameTime)
        {
            if (!Locked)
            {
                float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                Velocity += Acceleration * deltaTime;
                fireball.Location += Velocity * deltaTime;
            }
            
        }
    }
}
