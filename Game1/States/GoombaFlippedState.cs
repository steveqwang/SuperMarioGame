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
    public class GoombaFlippedState : IEnemyActionState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private ISprite sprite;
        private IEnemy goomba;
        public GoombaFlippedState(IEnemy goomba)
        {
            this.goomba = goomba;
            sprite = EnemySpritesFactory.Instance.CreateGoombaFlippedSprite();
            //Width = sprite.Width;
            //Height = sprite.Height;
            Width = 0;
            Height = 0;
            goomba.EnemyPhysics.BeFlipped();
           
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gametime)
        {
            
        }
    }
}
