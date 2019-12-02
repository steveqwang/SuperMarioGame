using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Interfaces
{
    public interface IMarioAbilityState
    {
        void Run();
        void FireShoot();
        void Ability();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
