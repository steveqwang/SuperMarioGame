using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.States;
using Game1.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.PhysicalProperty;
using Game1.Utility;
using Game1.Score;

namespace Game1.Items
{
    public class Flower : IItem
    {
        public Vector2 Location { get; set; }
        public ItemPhysicalProperty ItemPhysics { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);
        private ISprite sprite;

        public Flower(Vector2 location)
        {
            Location = location;
            sprite = ItemFactory.Instance.CreateFlowerSprite();
            HaveCollision = false;
            ItemPhysics = new ItemPhysicalProperty(this, true);
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

        }

        public void CollidedWithMario(IPlayer mario)
        {
            HaveCollision = true;
            if (mario.CurrentPowerState.StateName == Util.Instance.String_MarioStarSmallState)
            {
                mario.CurrentPowerState = new MarioStarBigState(mario);
                mario.Location -= new Vector2(Util.Instance.Zero, Util.Instance.Ten);
            }
            else if (mario.CurrentPowerState.StateName != Util.Instance.String_MarioStarBigState) {
                mario.CurrentPowerState = new MarioFireState(mario);
            }
            mario.CurrentAnimationState = new MarioRightIdleState(mario);
            mario.ScoreObjects.Add(new ScoreObject(Util.Instance.ItemScore, Location, true));
        }
    }
}
