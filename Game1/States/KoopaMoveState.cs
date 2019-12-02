using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.States
{
    public class KoopaMoveState : IEnemyActionState
    {
        private ISprite sprite;
        public int Width { get; set; }
        public int Height { get; set; }
        public KoopaMoveState(bool isLeft)
        {
            if (isLeft)
            {
                sprite = EnemySpritesFactory.Instance.CreateKoopaStandingSprite();
            }
            else
            {
                sprite = EnemySpritesFactory.Instance.CreateKoopaStandingRightSprite();
            }
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }
    }
}
