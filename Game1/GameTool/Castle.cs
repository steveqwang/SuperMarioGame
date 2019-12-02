using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Factories;

namespace Game1.GameTool
{
    public class Castle : IGameObject
    {
        public Vector2 Speed { get; set; }
        public bool IsRemove { get; set; }
        public Vector2 Location { get; set; }

        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, castleSprite.Width, castleSprite.Height);

        private ISprite castleSprite;

        public Castle(Vector2 location)
        {
            castleSprite = GameSpriteFactory.Instance.CreateCastleSprite();
            IsRemove = false;
            Location = location;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            castleSprite.Draw(spriteBatch, Location);

        }

        public void Update(GameTime gametime)
        {

        }
    }
}
