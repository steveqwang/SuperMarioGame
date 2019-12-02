using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Utility;

namespace Game1.States
{
    public class KoopaFlippedState : IEnemyActionState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private ISprite sprite;
        private IEnemy Koopa;
        public KoopaFlippedState(IEnemy Koopa) {
            this.Koopa = Koopa;
            sprite = EnemySpritesFactory.Instance.CreateKoopaFlippedSprite();
            Width = Util.Instance.Zero;
            Height = Util.Instance.Zero;
            Koopa.EnemyPhysics.BeFlipped();
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
