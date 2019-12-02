using Game1.Interfaces;
using Game1.Sprites;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Utility;

namespace Game1.Factories
{
    public class MenuFactory
    {
        public SpriteFont SpriteFont { get; set; }
        private Texture2D MainLogoSpritesheet;
        private Texture2D MushroomSpritesheet;
        private static readonly MenuFactory instance = new MenuFactory();

        public static MenuFactory Instance { get => instance; }
        public void LoadAllTextures(ContentManager content)
        {
            MainLogoSpritesheet = content.Load<Texture2D>(Util.Instance.Menu_MainLogo);
            SpriteFont = content.Load<SpriteFont>(Util.Instance.Menu_Consolas);
            MushroomSpritesheet = content.Load<Texture2D>(Util.Instance.Menu_MushroomSelector);
        }
        public ISprite CreateLogoSprite()
        {
            return new StaticSprite(MainLogoSpritesheet);
        }
        public SpriteFont CreateSpriteFont()
        {
            return SpriteFont;
        }
        public ISprite CreateMushroomSelector()
        {
            return new StaticSprite(MushroomSpritesheet);
        }
    }
}
