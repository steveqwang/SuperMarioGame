using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Interfaces;
using Game1.Sprites;
using Microsoft.Xna.Framework.Content;
using Game1.Utility;

namespace Game1.Factories
{
    public class MarioSpritesFactory
    {
        private Texture2D deadMarioSpritesheet;
        private Texture2D fireMarioLeftCrouchSpritesheet;
        private Texture2D fireMarioLeftIdleSpritesheet;
        private Texture2D fireMarioLeftRunSpritesheet;
        private Texture2D fireMarioLeftJumpSpritesheet;
        private Texture2D fireMarioRightCrouchSpritesheet;
        private Texture2D fireMarioRightIdleSpritesheet;
        private Texture2D fireMarioRightRunSpritesheet;
        private Texture2D fireMarioRightJumpSpritesheet;
        private Texture2D smallMarioLeftIdleSpritesheet;
        private Texture2D smallMarioLeftRunSpritesheet;
        private Texture2D smallMarioLeftJumpSpritesheet;
        private Texture2D smallMarioRightIdleSpritesheet;
        private Texture2D smallMarioRightRunSpritesheet;
        private Texture2D smallMarioRightJumpSpritesheet;
        private Texture2D bigMarioLeftCrouchSpritesheet;
        private Texture2D bigMarioLeftIdleSpritesheet;
        private Texture2D bigMarioLeftRunSpritesheet;
        private Texture2D bigMarioLeftJumpSpritesheet;
        private Texture2D bigMarioRightCrouchSpritesheet;
        private Texture2D bigMarioRightIdleSpritesheet;
        private Texture2D bigMarioRightRunSpritesheet;
        private Texture2D bigMarioRightJumpSpritesheet;
        private Texture2D starSmallMarioLeftIdleSpritesheet;
        private Texture2D starSmallMarioLeftRunSpritesheet;
        private Texture2D starSmallMarioLeftJumpSpritesheet;
        private Texture2D starSmallMarioRightIdleSpritesheet;
        private Texture2D starSmallMarioRightRunSpritesheet;
        private Texture2D starSmallMarioRightJumpSpritesheet;
        private Texture2D starBigMarioLeftCrouchSpritesheet;
        private Texture2D starBigMarioLeftIdleSpritesheet;
        private Texture2D starBigMarioLeftRunSpritesheet;
        private Texture2D starBigMarioLeftJumpSpritesheet;
        private Texture2D starBigMarioRightCrouchSpritesheet;
        private Texture2D starBigMarioRightIdleSpritesheet;
        private Texture2D starBigMarioRightRunSpritesheet;
        private Texture2D starBigMarioRightJumpSpritesheet;
        //private Texture2D starBigMarioClimbSpritesheet;
        //private Texture2D starSmallMarioClimbSpritesheet;
        //private Texture2D bigMarioClimbSpritesheet;
        //private Texture2D smallMarioClimbSpritesheet;
        //private Texture2D fireMarioClimbSpritesheet;

        public static MarioSpritesFactory instance { get;  } = new MarioSpritesFactory();

        private MarioSpritesFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            //small,big,fire normal Mario
            deadMarioSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_deadMarioSpritesheet);
            fireMarioLeftCrouchSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioLeftCrouchSpritesheet);
            fireMarioLeftIdleSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioLeftIdleSpritesheet);
            fireMarioLeftRunSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioLeftRunSpritesheet);
            fireMarioLeftJumpSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioLeftJumpSpritesheet);
            fireMarioRightCrouchSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioRightCrouchSpritesheet);
            fireMarioRightIdleSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioRightIdleSpritesheet);
            fireMarioRightRunSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioRightRunSpritesheet);
            fireMarioRightJumpSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_fireMarioRightJumpSpritesheet);
            smallMarioLeftIdleSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_smallMarioLeftIdleSpritesheet);
            smallMarioLeftRunSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_smallMarioLeftRunSpritesheet);
            smallMarioLeftJumpSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_smallMarioLeftJumpSpritesheet);
            smallMarioRightIdleSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_smallMarioRightIdleSpritesheet);
            smallMarioRightRunSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_smallMarioRightRunSpritesheet);
            smallMarioRightJumpSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_smallMarioRightJumpSpritesheet);
            bigMarioLeftCrouchSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioLeftCrouchSpritesheet);
            bigMarioLeftIdleSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioLeftIdleSpritesheet);
            bigMarioLeftRunSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioLeftRunSpritesheet);
            bigMarioLeftJumpSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioLeftJumpSpritesheet);
            bigMarioRightCrouchSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioRightCrouchSpritesheet);
            bigMarioRightIdleSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioRightIdleSpritesheet);
            bigMarioRightRunSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioRightRunSpritesheet);
            bigMarioRightJumpSpritesheet = content.Load<Texture2D>(Util.Instance.Sprite_bigMarioRightJumpSpritesheet);

            starSmallMarioLeftIdleSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starSmallLeftIdleMario);
            starSmallMarioLeftRunSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starSmallLeftRunMario);
            starSmallMarioLeftJumpSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starSmallLeftJumpMario);
            starSmallMarioRightIdleSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starSmallRightIdleMario);
            starSmallMarioRightRunSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starSmallRightRUnMario);
            starSmallMarioRightJumpSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starSmallRightJumpMario);
            starBigMarioLeftCrouchSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigLeftCrouchMario);
            starBigMarioLeftIdleSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigLeftIdleMario);
            starBigMarioLeftRunSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigLeftRunMario);
            starBigMarioLeftJumpSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigLeftJumpMario);
            starBigMarioRightCrouchSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigRightCrouchMario);
            starBigMarioRightIdleSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigRightIdleMario);
            starBigMarioRightRunSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigRightRunMario);
            starBigMarioRightJumpSpritesheet = content.Load<Texture2D>(Util.Instance.SpriteStar_starBigRightJumpMario);

            //starBigMarioClimbSpritesheet;
            //starSmallMarioClimbSpritesheet;
            //bigMarioClimbSpritesheet;
            //smallMarioClimbSpritesheet;
            //fireMarioClimbSpritesheet;


        }

        public ISprite CreateDeadMarioSprite()
        {
            return new StaticSprite(deadMarioSpritesheet);
        }
        public ISprite CreateFireMarioLeftCrouchSprite()
        {
            return new StaticSprite(fireMarioLeftCrouchSpritesheet);
        }
        public ISprite CreateFireMarioLeftIdleSprite()
        {
            return new StaticSprite(fireMarioLeftIdleSpritesheet);
        }
        public ISprite CreateFireMarioLeftRunSprite()
        {
            return new DynamicSprite(fireMarioLeftRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateFireMarioLeftJumpSprite()
        {
            return new StaticSprite(fireMarioLeftJumpSpritesheet);
        }
        public ISprite CreateFireMarioRightCrouchSprite()
        {
            return new StaticSprite(fireMarioRightCrouchSpritesheet);
        }
        public ISprite CreateFireMarioRightIdleSprite()
        {
            return new StaticSprite(fireMarioRightIdleSpritesheet);
        }
        public ISprite CreateFireMarioRightRunSprite()
        {
            return new DynamicSprite(fireMarioRightRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateFireMarioRightJumpSprite()
        {
            return new StaticSprite(fireMarioRightJumpSpritesheet);
        }
        public ISprite CreateBigMarioLeftCrouchSprite()
        {
            return new StaticSprite(bigMarioLeftCrouchSpritesheet);
        }
        public ISprite CreateBigMarioLeftIdleSprite()
        {
            return new StaticSprite(bigMarioLeftIdleSpritesheet);
        }
        public ISprite CreateBigMarioLeftRunSprite()
        {
            return new DynamicSprite(bigMarioLeftRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateBigMarioLeftJumpSprite()
        {
            return new StaticSprite(bigMarioLeftJumpSpritesheet);
        }
        public ISprite CreateBigMarioRightCrouchSprite()
        {
            return new StaticSprite(bigMarioRightCrouchSpritesheet);
        }
        public ISprite CreateBigMarioRightIdleSprite()
        {
            return new StaticSprite(bigMarioRightIdleSpritesheet);
        }
        public ISprite CreateBigMarioRightRunSprite()
        {
            return new DynamicSprite(bigMarioRightRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateBigMarioRightJumpSprite()
        {
            return new StaticSprite(bigMarioRightJumpSpritesheet);
        }
        public ISprite CreateSmallMarioLeftIdleSprite()
        {
            return new StaticSprite(smallMarioLeftIdleSpritesheet);
        }
        public ISprite CreateSmallMarioLeftRunSprite()
        {
            return new DynamicSprite(smallMarioLeftRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateSmallMarioLeftJumpSprite()
        {
            return new StaticSprite(smallMarioLeftJumpSpritesheet);
        }
        public ISprite CreateSmallMarioRightIdleSprite()
        {
            return new StaticSprite(smallMarioRightIdleSpritesheet);
        }
        public ISprite CreateSmallMarioRightRunSprite()
        {
            return new DynamicSprite(smallMarioRightRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateSmallMarioRightJumpSprite()
        {
            return new StaticSprite(smallMarioRightJumpSpritesheet);
        }
        public ISprite CreateStarBigMarioLeftCrouchSprite()
        {
            return new StaticSprite(starBigMarioLeftCrouchSpritesheet);
        }
        public ISprite CreateStarBigMarioLeftIdleSprite()
        {
            return new StaticSprite(starBigMarioLeftIdleSpritesheet);
        }
        public ISprite CreateStarBigMarioLeftRunSprite()
        {
            return new DynamicSprite(starBigMarioLeftRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateStarBigMarioLeftJumpSprite()
        {
            return new StaticSprite(starBigMarioLeftJumpSpritesheet);
        }
        public ISprite CreateStarBigMarioRightCrouchSprite()
        {
            return new StaticSprite(starBigMarioRightCrouchSpritesheet);
        }
        public ISprite CreateStarBigMarioRightIdleSprite()
        {
            return new StaticSprite(starBigMarioRightIdleSpritesheet);
        }
        public ISprite CreateStarBigMarioRightRunSprite()
        {
            return new DynamicSprite(starBigMarioRightRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateStarBigMarioRightJumpSprite()
        {
            return new StaticSprite(starBigMarioRightJumpSpritesheet);
        }
        public ISprite CreateStarSmallMarioLeftIdleSprite()
        {
            return new StaticSprite(starSmallMarioLeftIdleSpritesheet);
        }
        public ISprite CreateStarSmallMarioLeftRunSprite()
        {
            return new DynamicSprite(starSmallMarioLeftRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateStarSmallMarioLeftJumpSprite()
        {
            return new StaticSprite(starSmallMarioLeftJumpSpritesheet);
        }
        public ISprite CreateStarSmallMarioRightIdleSprite()
        {
            return new StaticSprite(starSmallMarioRightIdleSpritesheet);
        }
        public ISprite CreateStarSmallMarioRightRunSprite()
        {
            return new DynamicSprite(starSmallMarioRightRunSpritesheet, Util.Instance.DynamicSprite_combo_1, Util.Instance.DynamicSprite_combo_3, Util.Instance.DynamicSprite_combo_5);
        }
        public ISprite CreateStarSmallMarioRightJumpSprite()
        {
            return new StaticSprite(starSmallMarioRightJumpSpritesheet);

        }
 
    }
}
