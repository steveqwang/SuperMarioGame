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
     class MarioRightJumpState : IMarioActionState
    {
        private ISprite sprite;
        private IPlayer player;
        public int Width { get; set; }
        public int Height { get; set; }

        public MarioRightJumpState(IPlayer player)
        {
            this.player = player;
            switch (player.CurrentPowerState.StateName)
            {
                case "MarioSmallState":
                    sprite = MarioSpritesFactory.instance.CreateSmallMarioRightJumpSprite();
                    break;
                case "MarioBigState":
                    sprite = MarioSpritesFactory.instance.CreateBigMarioRightJumpSprite();
                    break;
                case "MarioFireState":
                    sprite = MarioSpritesFactory.instance.CreateFireMarioRightJumpSprite();
                    break;
                case "MarioStarSmallState":
                    sprite = MarioSpritesFactory.instance.CreateStarSmallMarioRightJumpSprite();
                    break;
                case "MarioStarBigState":
                    sprite = MarioSpritesFactory.instance.CreateStarBigMarioRightJumpSprite();
                    break;
            }
            Width = sprite.Width;
            Height = sprite.Height;
        }

        public void Down()
        {
            player.CurrentAnimationState = new MarioRightIdleState(player); 
        }

        public void Left()
        {
            player.CurrentAnimationState = new MarioLeftJumpState(player);
        }

        public void Right()
        {
            player.CurrentAnimationState = new MarioRightIdleState(player);
        }

        public void Up()
        {
            // Nothing to do here
        }
        public void Idle()
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

    }
}
