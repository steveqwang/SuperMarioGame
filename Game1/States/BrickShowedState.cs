using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Factories;
using Game1.Interfaces;

namespace Game1.States
{
     class BrickShowedState : IBlockState
    {
        public ISprite Sprite { get; set; }

        public BrickShowedState() {
            Sprite = BlockSpritesFactory.Instance.CreateBrickBlockSprite();
        }
        
        

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }

        public void Update(GameTime gametime)
        {

        }
    }
}
