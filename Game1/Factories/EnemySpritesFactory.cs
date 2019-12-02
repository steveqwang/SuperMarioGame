using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Game1.Interfaces;
using Game1.Sprites;

using Game1.Utility;

namespace Game1.Factories
{
    class EnemySpritesFactory
    {
        private Texture2D normalStandingGoombaContent;
        private Texture2D normalStandingLeftKoopaContent;
        private Texture2D BowserMoveLeftContent;
        private Texture2D BowserMoveRightContent;
        private Texture2D KoopaFlippedContent;
        private Texture2D KoopaStompedContent;
        private Texture2D GoombaStompedContent;
        private Texture2D GoombaFlippedContent;
        private Texture2D normalStandingRightKoopaContent;
        private static readonly EnemySpritesFactory instance = new EnemySpritesFactory();


        public static EnemySpritesFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpritesFactory()
        {
        }

        public void LoadTextures(ContentManager content)
        {

            normalStandingGoombaContent = content.Load<Texture2D>(Util.Instance.GoombaWalk);
            normalStandingLeftKoopaContent = content.Load<Texture2D>(Util.Instance.Koopa_walk_left);
            normalStandingRightKoopaContent = content.Load<Texture2D>(Util.Instance.Koopa_walk_right);
            KoopaFlippedContent = content.Load<Texture2D>(Util.Instance.KoopaFlipped);
            KoopaStompedContent = content.Load<Texture2D>(Util.Instance.KoopaStomped);
            GoombaStompedContent = content.Load < Texture2D>(Util.Instance.GoombaStomped);
            GoombaFlippedContent = content.Load<Texture2D>(Util.Instance.GoombaFlipped);
            BowserMoveLeftContent = content.Load<Texture2D>(Util.Instance.BowserMoveLeft);
            BowserMoveRightContent = content.Load<Texture2D>(Util.Instance.BowserMoveRight);
        }
        public ISprite CreateGoombaStandingSprite()
        {
            return new DynamicSprite(normalStandingGoombaContent, 1, 2, 20);
        }

        public ISprite CreateKoopaStandingSprite()
        {
            return new DynamicSprite(normalStandingLeftKoopaContent, 1, 2, 80);
        }
        public ISprite CreateKoopaStandingRightSprite()
        {
            return new DynamicSprite(normalStandingRightKoopaContent, 1, 2, 80);
        }
        public ISprite CreateKoopaFlippedSprite()
        {
            return new StaticSprite(KoopaFlippedContent);
        }
        public ISprite CreateKoopaStompedSprite()
        {
            return new StaticSprite(KoopaStompedContent);
        }
        public ISprite CreateGoombaFlippedSprite()
        {
            return new StaticSprite(GoombaFlippedContent);
        }
        public ISprite CreateGoombaStompedSprite()
        {
            return new StaticSprite(GoombaStompedContent);
        }
        public ISprite CreateBowserMoveLeftSprite()
        {
            return new DynamicSprite(BowserMoveLeftContent, 1, 4, 5);
        }
        public ISprite CreateBowserMoveRightSprite()
        {
            return new DynamicSprite(BowserMoveRightContent, 1, 4, 5);
        }
    }
}
