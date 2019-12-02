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
    public class GameSpriteFactory
    {
        private Texture2D fireBallLeftSpriteContent;
        private Texture2D fireBallRightSpriteContent;
        private Texture2D fireBallExplodedSpriteContent;
        private Texture2D castleSpriteContent;
        private Texture2D flagStuffSpriteContent;
        private Texture2D fireShotLeftSpriteContent;
        private Texture2D fireShotRightSpriteContent;
        private Texture2D fireHellSpriteContent;
        //private Texture2D enemyHordSpriteContent;



        private static readonly GameSpriteFactory instance = new GameSpriteFactory();

        public static GameSpriteFactory Instance { get => instance; }


        public GameSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            fireBallLeftSpriteContent = content.Load<Texture2D>(Util.Instance.GameSprite_FireBallLeft);
            fireBallRightSpriteContent = content.Load<Texture2D>(Util.Instance.GameSprite_FireBallRight);
            fireBallExplodedSpriteContent = content.Load<Texture2D>(Util.Instance.GameSprite_FireballExplosion);
            castleSpriteContent = content.Load<Texture2D>(Util.Instance.GameSprite_Castle);
            flagStuffSpriteContent = content.Load<Texture2D>(Util.Instance.GameSprite_FlagStuff);
            fireShotLeftSpriteContent = content.Load<Texture2D>("GameSprite/FireShotLeft");
            fireShotRightSpriteContent = content.Load<Texture2D>("GameSprite/FireShotRight");
            fireHellSpriteContent = content.Load<Texture2D>("GameSprite/FireHell");
        }

        public ISprite CreateLeftFireBallSprite()
        {
            return new DynamicSprite(fireBallLeftSpriteContent, Util.Instance.CreateLeftFireBallSpriteY, Util.Instance.CreateLeftFireBallSpriteZ, Util.Instance.CreateLeftFireBallSpriteW);
        }

        public ISprite CreateRightFireBallSprite()
        {
            return new DynamicSprite(fireBallRightSpriteContent, Util.Instance.CreateRightFireBallSpriteY, Util.Instance.CreateRightFireBallSpriteZ, Util.Instance.CreateRightFireBallSpriteW);
        }

        public ISprite CreateLeftFireShotSprite()
        {
            return new DynamicSprite(fireShotLeftSpriteContent, Util.Instance.CreateLeftFireShotSpriteY, Util.Instance.CreateLeftFireShotSpriteZ, Util.Instance.CreateLeftFireShotSpriteW);
        }
        public ISprite CreateRightFireShotSprite()
        {
            return new DynamicSprite(fireShotRightSpriteContent, Util.Instance.CreateRightFireShotSpriteY, Util.Instance.CreateRightFireShotSpriteZ, Util.Instance.CreateRightFireShotSpriteW);
        }
        public ISprite CreateExplodedFireBallSprite()
        {
            return new DynamicSprite(fireBallExplodedSpriteContent, Util.Instance.CreateExplodedFireBallSpriteY, Util.Instance.CreateExplodedFireBallSpriteZ, Util.Instance.CreateExplodedFireBallSpriteW);
        }

        public ISprite CreateCastleSprite()
        {
            return new StaticSprite(castleSpriteContent);
        }

        public ISprite CreateFlagStuffSprite()
        {
            return new DynamicSprite(flagStuffSpriteContent, Util.Instance.CreateFlagStuffSpriteY, Util.Instance.CreateFlagStuffSpriteZ, Util.Instance.CreateFlagStuffSpriteW);
        }

        public ISprite CreateFireHellSprite()
        {
            return new DynamicSprite(fireHellSpriteContent, Util.Instance.CreateFireHellSpriteColumn, Util.Instance.CreateFireHellSpriteRow, Util.Instance.CreateFireHellSpriteDelay);
        }
    }
}
