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
     class MarioRightIdleState : IMarioActionState
    {
        private ISprite sprite;
        private IPlayer player;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioRightIdleState(IPlayer player)
        {
            this.player = player;
            switch (player.CurrentPowerState.StateName)
            {
                case "MarioSmallState":
                    sprite = MarioSpritesFactory.instance.CreateSmallMarioRightIdleSprite();
                    break;
                case "MarioBigState":
                    sprite = MarioSpritesFactory.instance.CreateBigMarioRightIdleSprite();
                    break;
                case "MarioFireState":
                    sprite = MarioSpritesFactory.instance.CreateFireMarioRightIdleSprite();
                    break;
                case "MarioStarSmallState":
                    sprite = MarioSpritesFactory.instance.CreateStarSmallMarioRightIdleSprite();
                    break;
                case "MarioStarBigState":
                    sprite = MarioSpritesFactory.instance.CreateStarBigMarioRightIdleSprite();
                    break;
            }
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Down()
        {
            if ((player.CurrentPowerState.StateName != "MarioSmallState") && (player.CurrentPowerState.StateName != "MarioStarSmallState"))
            {
                player.CurrentAnimationState = new MarioRightCrouchState(player);
            }
        }

        public void Left()
        {
            player.CurrentAnimationState = new MarioLeftIdleState(player);
        }

        public void Right()
        {
            player.CurrentAnimationState = new MarioRightRunState(player);
        }

        public void Up()
        {
            player.CurrentAnimationState = new MarioRightJumpState(player);
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
        }
    }
}
