using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Sprites
{
    public class StaticSprite : Interfaces.ISprite
    {
        private readonly Texture2D texture;
        public int Width { get; set; }
        public int Height { get; set; }

        public StaticSprite(Texture2D texture)
        {
            this.texture = texture;
            Width = texture.Width;
            Height = texture.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }

        public void Update(GameTime gametime)
        {
            // nothing to update here
        }
    }
}