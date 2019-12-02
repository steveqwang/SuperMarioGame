using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.PhysicalProperty;
using Game1.Utility;
using Game1.World;
using Game1.Score;

namespace Game1.Items
{
  public  class Gold : IItem
    {
        public ItemPhysicalProperty ItemPhysics { get; set; }
        public Vector2 Location { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);
        private ISprite sprite;
        private bool isStatic;

        public Gold(Vector2 location, bool isStatic)
        {
            this.isStatic = isStatic;
            Location = location;
            //if (!isStatic)
            //{
                ItemPhysics = new ItemPhysicalProperty(this, false);
            //}
            sprite = ItemFactory.Instance.CreateGoldSprite();
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
            if (!isStatic)
            {
                ItemPhysics.Update(gametime);
            }
           
        }

        public void CollidedWithMario(IPlayer mario) {
            HaveCollision = true;
            mario.Scores += Util.Instance.Hundred;
            SoundFactory.Instance.PlayCollectionSound();
            mario.ScoreObjects.Add(new ScoreObject(Util.Instance.ItemScore, Location, true));
        }
    }
}
