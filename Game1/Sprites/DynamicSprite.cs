using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Utility;

namespace Game1.Sprites
{
    public class DynamicSprite : Interfaces.ISprite
    {
        private readonly Texture2D texture;
        private int rows;
        private int columns;
        private int delay;
        private int maxDelay;
        private int currentFrame;
        private int totalFrames;
        public int Width { get; set; }
        public int Height { get; set; }

        public DynamicSprite(Texture2D texture, int rows, int columns, int maxDelay)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            Width = texture.Width / columns;
            Height = texture.Height / rows;
            currentFrame = Util.Instance.Zero;
            totalFrames = rows * columns;
            this.maxDelay = maxDelay;
            delay = Util.Instance.Zero;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(GameTime gametime)
        {
            if (delay == maxDelay)
            {
                delay = Util.Instance.Zero;
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = Util.Instance.Zero;
            }
            else
            {
                delay++;
            }
        }
    }
}