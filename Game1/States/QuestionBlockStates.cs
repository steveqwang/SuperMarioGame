using Game1.Factories;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.States
{
    class QuestionBlockStates:IBlockState
    {
        public ISprite Sprite { get; set; }

        public QuestionBlockStates()
        {
            Sprite = BlockSpritesFactory.Instance.CreateQuestionBlockSprite();
        }
        public void Update(GameTime gametime)
        {

        }
        public void BecomeUsed()
        {
            Sprite = BlockSpritesFactory.Instance.CreateUsedBlockSprite();
            Sprite = ItemFactory.Instance.CreateGoldSprite();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }

    }
}
