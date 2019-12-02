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
    public class BowserMoveState : IEnemyActionState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private ISprite sprite;
        public BowserMoveState(bool isLeft)
        {
            if (isLeft)
            {
                sprite = EnemySpritesFactory.Instance.CreateBowserMoveLeftSprite();
            }
            else
            {
                sprite = EnemySpritesFactory.Instance.CreateBowserMoveRightSprite();
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

