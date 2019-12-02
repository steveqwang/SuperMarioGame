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
    public class KoopaStompedKickedState : IEnemyActionState
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ISprite sprite;
        private IEnemy Koopa;
        public KoopaStompedKickedState(IEnemy Koopa)
        {
            this.Koopa = Koopa;
            sprite = EnemySpritesFactory.Instance.CreateKoopaStompedSprite();
            Width = sprite.Width;
            Height = sprite.Height;
            Koopa.EnemyPhysics.KoopaKickedSpeed();
            Koopa.EnemyPhysics.EnemyMove();
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
