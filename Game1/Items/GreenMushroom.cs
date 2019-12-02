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
using Game1.Sound;

namespace Game1.Items
{
    public class GreenMushroom : IItem
    {
        public ItemPhysicalProperty ItemPhysics { get; set; }
        public Vector2 Location { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);
        private ISprite sprite;

        public GreenMushroom(Vector2 location)
        {
            ItemPhysics = new ItemPhysicalProperty(this,true);
            Location = location;
            sprite = ItemFactory.Instance.CreateGreenMushroomSprite();
            HaveCollision = false;
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
                HaveCollision = true;
                mario.lifes += 1;
            }
            SoundFactory.Instance.PlayCollectionSound();

        }
    }
}
