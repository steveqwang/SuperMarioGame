using Game1.Interfaces;
using Game1.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.States
{
    internal class MarioAbilityRunState : IMarioAbilityState
    {
        private MarioPlayer mario;

        public MarioAbilityRunState(MarioPlayer mario)
        {
            this.mario = mario;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public void Ability()
        {

        }

        public void FireShoot()
        {
            mario.CurrentAbilityState = new MarioAbilityFireShootState(mario);
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}