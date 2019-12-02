using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Sprites;
using Game1.Interfaces;
using Game1.Utility;

namespace Game1.Factories
{
    public class ScenerySpriteFactory
    {
        private Texture2D bigBushContent;
        private Texture2D bigHillContent;
        private Texture2D bigCloudContent;
        private Texture2D smallBushContent;
        private Texture2D smallHillContent;
        private Texture2D smallCloudContent;
        private static readonly ScenerySpriteFactory instance = new ScenerySpriteFactory();

        private ScenerySpriteFactory()
        {

        }

        public static ScenerySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager content)
        {
            bigBushContent = content.Load<Texture2D>(Util.Instance.Scenery_bigBush);
            bigHillContent = content.Load<Texture2D>(Util.Instance.Scenery_bigHill);
            bigCloudContent = content.Load<Texture2D>(Util.Instance.Scenery_bigCloud);
            smallBushContent = content.Load<Texture2D>(Util.Instance.Scenery_smallBush);
            smallCloudContent = content.Load<Texture2D>(Util.Instance.Scenery_smalCloud);
            smallHillContent = content.Load<Texture2D>(Util.Instance.Scenery_smallHill);
        }

        public ISprite CreateBigBushScenery()
        {
            return new StaticSprite(bigBushContent);
        }
        public ISprite CreateBigHillScenery()
        {
            return new StaticSprite(bigHillContent);
        }
        public ISprite CreateBigCloudScenery()
        {
            return new StaticSprite(bigCloudContent);
        }
        public ISprite CreateSmallBushScenery()
        {
            return new StaticSprite(smallBushContent);
        }
        public ISprite CreateSmallHillScenery()
        {
            return new StaticSprite(smallHillContent);
        }
        public ISprite CreateSmallCloudScenery()
        {
            return new StaticSprite(smallCloudContent);
        }

    }
}
