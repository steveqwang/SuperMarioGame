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

namespace Game1.States
{
     class MarioRightCrouchState : IMarioActionState
    {
        private ISprite sprite;
        private IPlayer player;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioRightCrouchState(IPlayer player)
        {
            this.player = player;
            switch (player.CurrentPowerState.StateName)
            {
                case "MarioBigState":
                    sprite = MarioSpritesFactory.instance.CreateBigMarioRightCrouchSprite();
                    break;
                case "MarioFireState":
                    sprite = MarioSpritesFactory.instance.CreateFireMarioRightCrouchSprite();
                    break;
                case "MarioStarBigState":
                    sprite = MarioSpritesFactory.instance.CreateStarBigMarioRightCrouchSprite();
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
            player.CurrentAnimationState = new MarioLeftCrouchState(player);
        }

        public void Right()
        {
            player.CurrentAnimationState = new MarioRightIdleState(player);
        }

        public void Up()
        {
            player.CurrentAnimationState = new MarioRightIdleState(player);
        }

        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Idle()
        {
            player.CurrentAnimationState = new MarioRightIdleState(player);
        }
    }
}
