using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Interfaces
{
    interface IBlockState
    {
        ISprite Sprite { get; set; }
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
