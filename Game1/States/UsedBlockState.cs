using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Factories;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.States
{

    public enum Bonus { Gold, Star, Flower, GreenShroom, RedShroom}

    class UsedBlockState : IBlockState
    {
        public ISprite Sprite { get; set; }

      

        public UsedBlockState()
        {
            Sprite = BlockSpritesFactory.Instance.CreateUsedBlockSprite();

            

        }
        
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
         
          
            Sprite.Draw(spriteBatch, location);
           
        }

        public void Update(GameTime gametime)
        {
            Sprite.Update(gametime);
        }
    }
}
