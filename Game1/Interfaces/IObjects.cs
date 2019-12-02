using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.Interfaces
{
    public interface IObjects
    {
        Vector2 Location { get; set; }
        Rectangle Rectangle { get; }
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch);
    }
}
