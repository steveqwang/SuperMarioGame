using Game1.Factories;
using Game1.Interfaces;
using Game1.PhysicalProperty;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Fireball : IGameObject
    {
        private ISprite sprite;
        
        public Vector2 Location { get; set; }
        public Vector2 Speed { get; set; }
        public bool IsLeft { get; set; }
        public Rectangle Rectangle => new Rectangle((int) Location.X, (int)Location.Y, sprite.Width, sprite.Height);
        public bool IsRemove { get; set; }
        public FireballPhysicalProperty FireballPhysicalProperty { get; private set; }
        private bool explode;
        private float explodeTime;
        private float fireballLife;

        public Fireball(Vector2 location, bool isLeft)
        {
            IsLeft = isLeft;
            FireballPhysicalProperty = new FireballPhysicalProperty(this, false);
            if (IsLeft)
            {
                sprite = GameSpriteFactory.Instance.CreateLeftFireBallSprite();
            }
            else
            {
                sprite = GameSpriteFactory.Instance.CreateRightFireBallSprite();
            }
            Location = location;
            explodeTime = 0.15f;
            fireballLife = 1.3f;
            IsRemove = false;
        }
        public void CollisionHorizontal(float horizonValue)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsRemove)
            {
                sprite.Draw(spriteBatch, Location);
            }
            else
            {
                Location += new Vector2(0, 1000);
            }

        }

        public void Update(GameTime gameTime)
        {
            if (!explode)
            {
                fireballLife = fireballLife - (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (fireballLife <= 0)
                {
                    IsRemove = true;
                }
                else
                {
                    if (IsLeft)
                    {
                        FireballPhysicalProperty.MoveLeft();
                    }
                    else
                    {
                        FireballPhysicalProperty.MoveRight();
                    }
                }
              
            }
            else
            {           
                explodeTime = explodeTime - (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(explodeTime <= 0)
                {
                    IsRemove = true;
                }
            }
            FireballPhysicalProperty.Update(gameTime);
            sprite.Update(gameTime);
            
        }
        public void Jump()
        {
            FireballPhysicalProperty.Jump();
        }
        public void Explode()
        {
            // not implemented yet
            explode = true;
            FireballPhysicalProperty.Locked = true;
            FireballPhysicalProperty.Velocity = Vector2.Zero;
            sprite = GameSpriteFactory.Instance.CreateExplodedFireBallSprite();
            
        }
    }
}
