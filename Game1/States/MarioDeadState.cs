using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Interfaces;
using Game1.Factories;
using Game1.Player;
using Game1.Sound;

namespace Game1.States
{
     class MarioDeadState : IMarioActionState
    {
        private ISprite sprite;
        public int Width { get; set ; }
        public int Height { get; set; }

        public MarioDeadState()
        {
            sprite = MarioSpritesFactory.instance.CreateDeadMarioSprite();
            Width = sprite.Width;
            Height = sprite.Height;
            SoundManager.Instance.PlayPlayerDeadMusic();
        }
        public void Down()
        {
            // Nothing to do here 
        }

        public void Left()
        {
            // Nothing to do here
        }

        public void Right()
        {
            // Nothing to do here
        }

        public void Up()
        {
            // Nothing to do here
        }
        public void Idle()
        {
            // Nothing to do here
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

    }
}
