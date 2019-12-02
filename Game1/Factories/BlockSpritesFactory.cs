using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Game1.Interfaces;
using Game1.Sprites;
using Game1.Utility;


namespace Game1.Factories
{
    public class BlockSpritesFactory
    {
        private Texture2D beveledBlockContent;
        private Texture2D brickBlockContent;
        private Texture2D hiddenBlockContent;
        private Texture2D groundBlockContent;
        private Texture2D usedBlockContent;
        private Texture2D pipeContent;
        private Texture2D questionBlockContent;

        private static readonly BlockSpritesFactory instance = new BlockSpritesFactory();


        public static BlockSpritesFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpritesFactory()
        {
        }

        public void LoadTextures(ContentManager content)
        {

            beveledBlockContent= content.Load<Texture2D>(Util.Instance.BeveledBlock);
            brickBlockContent = content.Load<Texture2D>(Util.Instance.Brick);
            hiddenBlockContent = content.Load<Texture2D>(Util.Instance.Hidden);
            groundBlockContent = content.Load<Texture2D>(Util.Instance.Ground);
            usedBlockContent = content.Load<Texture2D>(Util.Instance.Used);
            pipeContent = content.Load<Texture2D>(Util.Instance.PipeLarge);
            questionBlockContent = content.Load<Texture2D>(Util.Instance.Question);
        }

        public ISprite CreateBeveledBlockSprite()
        {
            return new StaticSprite(beveledBlockContent);
        }
        public ISprite CreateQuestionBlockSprite()
        {
            return new StaticSprite(questionBlockContent);
        }
        public ISprite CreateBrickBlockSprite()
        {
            return new StaticSprite(brickBlockContent);
        }
        public ISprite CreateHiddenBlockSprite()
        {
            return new StaticSprite(hiddenBlockContent);
        }
        public ISprite CreateGroundBlockSprite()
        {
            return new StaticSprite(groundBlockContent);
        }
        public ISprite CreateUsedBlockSprite()
        {
            return new StaticSprite(usedBlockContent);
        }
        public ISprite CreatePipeSprite()
        {
            return new StaticSprite(pipeContent);
        }

    }
}
