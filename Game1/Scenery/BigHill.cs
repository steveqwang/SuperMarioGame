using Game1.Factories;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Scenery
{
    class BigHill : IScenery
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        Rectangle IObjects.Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);

        public BigHill(Vector2 Location)
        {
            this.Location = Location;
            sprite = ScenerySpriteFactory.Instance.CreateBigHillScenery();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }

        public void Update(GameTime gametime)
        {

        }
    }
}
