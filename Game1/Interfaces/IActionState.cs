using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Interfaces
{
    public interface IActionState
    {
        int Width { get; set; }
        int Height { get; set; }
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
