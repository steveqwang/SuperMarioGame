using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Game1.Interfaces;
using Game1.Items;
using Game1.Sprites;
using Game1.Utility;


namespace Game1.Factories
{
    public class ItemFactory
    {
        private Texture2D starSpriteContent;
        private Texture2D greenMushroomSpriteContent;
        private Texture2D redMushroomSpriteContent;
        private Texture2D fireFlowerSpriteContent;
        private Texture2D goldSpriteContent;
        private Texture2D EnemiesPortalContent;

        private static readonly ItemFactory instance = new ItemFactory();
        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {

            starSpriteContent = content.Load<Texture2D>(Util.Instance.Star);
            greenMushroomSpriteContent = content.Load<Texture2D>(Util.Instance.Greenmushroom);
            redMushroomSpriteContent = content.Load<Texture2D>(Util.Instance.Redmushroom);
            fireFlowerSpriteContent = content.Load<Texture2D>(Util.Instance.Flower);
            goldSpriteContent = content.Load<Texture2D>(Util.Instance.Gold);
            EnemiesPortalContent = content.Load<Texture2D>("circlesmall");


        }
        public ISprite CreateStarSprite()
        {
            return new StaticSprite(starSpriteContent);
        }

        public ISprite CreateEnemiesPortalSprite()
        {
            return new StaticSprite(EnemiesPortalContent);
        }
        public ISprite CreateGreenMushroomSprite()
        {
            return new StaticSprite(greenMushroomSpriteContent);
        }
        public ISprite CreateRedMushroomSprite()
        {
            return new StaticSprite(redMushroomSpriteContent);
        }
        public ISprite CreateFlowerSprite()
        {
            return new StaticSprite(fireFlowerSpriteContent);
        }
        public ISprite CreateGoldSprite()
        {
            return new StaticSprite(goldSpriteContent);
        }

    }
}
