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
    public class FireShot : IGameObject
    {
        public Vector2 Speed { get; set; }
        public bool IsRemove { get; set; }
        public Vector2 Location { get; set; }
        private ISprite sprite;
        public bool IsLeft { get; set; }
        public Vector2 Velocity { get; set; }

        

        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);
        private float fireShotLife;

        public FireShot(Vector2 location, bool isLeft)
        {
            Velocity = new Vector2(0, 0);
            IsLeft = isLeft;
            if (IsLeft)
            {
                sprite = GameSpriteFactory.Instance.CreateLeftFireShotSprite();
            }else
            {
                sprite = GameSpriteFactory.Instance.CreateRightFireShotSprite();
            }
            Location = location;
            fireShotLife = Util.Instance.CreateFireShotLife;
            IsRemove = false;
        }

        public void MoveLeft()
        {
            Velocity = new Vector2(Util.Instance.FireShotMoveLeft, Velocity.Y);
        }

        public void MoveRight()
        {
            Velocity = new Vector2(Util.Instance.FireShotMoveRight, Velocity.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsRemove)
            {
                sprite.Draw(spriteBatch, Location);
            }
            else
            {
                Location += new Vector2(0, Util.Instance.Thousand);
            }

        }

        public void Update(GameTime gametime)
        {

            fireShotLife -= (float)gametime.ElapsedGameTime.TotalSeconds;
            if(fireShotLife <= 0)
            {
                IsRemove = true;
            }
            else
            {
                if (IsLeft)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }

            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;
            Location += Velocity * deltaTime;
            sprite.Update(gametime);
        }
    }
}
