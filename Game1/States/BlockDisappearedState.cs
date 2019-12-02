using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Factories;
using Game1.Interfaces;

namespace Game1.States
{
     class BlockDisappearedState : IBlockState
    {
        
        public ISprite Sprite { get; set; }
        public BlockDisappearedState()
        {
            Sprite = BlockSpritesFactory.Instance.CreateHiddenBlockSprite();
        }

        public void Disappear()
        {
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
