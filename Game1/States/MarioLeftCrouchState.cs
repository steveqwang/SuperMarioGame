using Game1.Interfaces;
using Game1.Player;
using Game1.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.States
{
     class MarioLeftCrouchState : IMarioActionState
    {
        private ISprite sprite;
        private IPlayer player;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioLeftCrouchState(IPlayer player)
        {
            this.player = player;
            switch (player.CurrentPowerState.StateName)
            {
                case "MarioFireState":
                    sprite = MarioSpritesFactory.instance.CreateFireMarioLeftCrouchSprite();
                    break;
                case "MarioBigState":
                    sprite = MarioSpritesFactory.instance.CreateBigMarioLeftCrouchSprite();
                    break;
                case "MarioStarBigState":
                    sprite = MarioSpritesFactory.instance.CreateStarBigMarioLeftCrouchSprite();
                    break;
            }
            Width = sprite.Width;
            Height = sprite.Height;
        } 

        public void Down()
        {
            // Nothing to do here
        }

        public void Left()
        {
            player.CurrentAnimationState = new MarioLeftIdleState(player);
        }

        public void Right()
        {
            player.CurrentAnimationState = new MarioRightCrouchState(player);
        }

        public void Up()
        {
            player.CurrentAnimationState = new MarioLeftIdleState(player);
        }
        public void Idle()
        {
            player.CurrentAnimationState = new MarioLeftIdleState(player);
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
