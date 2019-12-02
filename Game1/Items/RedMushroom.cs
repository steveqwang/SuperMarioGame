using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.Factories;
using Game1.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.PhysicalProperty;
using Game1.Utility;

namespace Game1.Items
{
    public class RedMushroom : IItem
    {
        public ItemPhysicalProperty ItemPhysics { get; set; }
        public Vector2 Location { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);
        private ISprite sprite;
        private bool isCollied;

        public RedMushroom(Vector2 location)
        {
            ItemPhysics = new ItemPhysicalProperty(this,true);
            Location = location;
            sprite = ItemFactory.Instance.CreateRedMushroomSprite();
            HaveCollision = false;
            isCollied = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!HaveCollision)
            {
                sprite.Draw(spriteBatch, Location);
            }

        }

        public void Update(GameTime gametime)
        {
            ItemPhysics.Update(gametime);
            ItemPhysics.ItemMove();
        }

        public void CollidedWithMario(IPlayer mario)
        {
            if (!(mario.CurrentAnimationState is MarioDeadState))
            {
                if (!isCollied)
                {
                    SoundFactory.Instance.PlayCollectionSound();
                    mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.ItemScore, Location, true));
                    isCollied = true;
                }
                HaveCollision = true;
                if (mario.CurrentPowerState.StateName == Util.Instance.String_MarioStarSmallState)
                {
                    mario.CurrentPowerState = new MarioStarBigState(mario);
                    mario.Location -= new Vector2(Util.Instance.Zero, Util.Instance.Ten);
                }
                else if (mario.CurrentPowerState.StateName != Util.Instance.String_MarioStarBigState && mario.CurrentPowerState.StateName != Util.Instance.String_MarioFireState)
                {
                    mario.CurrentPowerState = new MarioBigState(mario);
                    mario.Location -= new Vector2(Util.Instance.Zero, Util.Instance.Ten);
                }
                mario.CurrentAnimationState = new MarioRightIdleState(mario);
            }
        }
    }
}
