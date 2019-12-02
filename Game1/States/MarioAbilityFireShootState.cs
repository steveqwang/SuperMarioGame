using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Player;
using Game1.World;

namespace Game1.States
{
    public class MarioAbilityFireShootState : IMarioAbilityState
    {
        private MarioPlayer mario;
        private bool shootMode;
        private bool keyDown;
        private bool keyUp;
        public IWorld World { get; set; }

        public MarioAbilityFireShootState(MarioPlayer mario)
        {
            this.mario = mario;
            shootMode = true;
            keyDown = false;
            keyUp = false;
            World = World;
        }

        public void Ability()
        {
            if (shootMode && keyUp)
            {
                World.Fireballs.Add(new Fireball(mario.Location, mario.isFacingLeft));
            }
            keyUp = false;
            keyDown = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void FireShoot()
        {
      
        }

        public void Run()
        {
            mario.CurrentAbilityState = new MarioAbilityRunState(mario);
        }

        public void Update(GameTime gameTime)
        {
            if (!keyDown)
            {
                keyUp = true;
            }
            keyDown = false;
        }
    }
}
