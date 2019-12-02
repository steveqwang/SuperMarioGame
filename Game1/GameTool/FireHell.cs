using Game1.Factories;
using Game1.Interfaces;
using Game1.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Game1.GameTool
{
    public class FireHell : IGameObject
    {
        public Vector2 Speed { get; set; }
        public bool IsRemove { get; set; }
        public Vector2 Location { get; set; }
        private ISprite sprite;
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);
        public Vector2 Velocity { get; set; }
        private float fireHellLife;

        public FireHell (Vector2 location)
        {
            Velocity = new Vector2(0, -100);
            sprite = GameSpriteFactory.Instance.CreateFireHellSprite();
            Location = location;
            IsRemove = false;
            fireHellLife = (float)Util.Instance.Five;
        }

        public void Move()
        {
            Velocity = new Vector2(Velocity.X, Util.Instance.FireHellVelocity);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsRemove)
            {
                sprite.Draw(spriteBatch, Location);
            }
            else
            {
                Location = new Vector2(Location.X, 224);
                IsRemove = false;
            }
        }

        public void Update(GameTime gametime)
        {
            fireHellLife -= (float)gametime.ElapsedGameTime.TotalSeconds;
            if(fireHellLife <= 0)
            {
                IsRemove = true;
                fireHellLife = (float)Util.Instance.Five;

            }
            else
            {
                Move();
            }
            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;
            Location += Velocity * deltaTime;
            sprite.Update(gametime);
        }
    }
}
