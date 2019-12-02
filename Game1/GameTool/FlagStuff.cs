using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Factories;

namespace Game1.GameTool
{
    public class FlagStuff : IGameObject
    {
        public Vector2 Speed { get; set; }
        public bool IsRemove { get; set; }
        public Vector2 Location { get; set; }
        public bool LowerFlagStuff { get; set; }
        public bool FinishFlagStuff { get; set; }
        public int FrameIndex { get; set; }

        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, flagStuffSprite.Width, flagStuffSprite.Height);

        private ISprite flagStuffSprite;
        private double deltaTime;
        private double flagTime;
       

        public FlagStuff(Vector2 location)
        {
            Location = location;
            flagStuffSprite = GameSpriteFactory.Instance.CreateFlagStuffSprite();
            IsRemove = false;
            LowerFlagStuff = false;
            FinishFlagStuff = false;
            FrameIndex = 1;
            flagTime = 0.1f;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            flagStuffSprite.Draw(spriteBatch, Location);
        }
        public void Update(GameTime gametime)
        {
            if (LowerFlagStuff)
            {
                flagStuffSprite.Update(gametime);
                if(FrameIndex == 5)
                {
                    LowerFlagStuff = false;
                    FinishFlagStuff = true;
                }
                deltaTime = deltaTime + gametime.ElapsedGameTime.TotalSeconds;
                if(deltaTime > flagTime)
                {
                    ++FrameIndex;
                    deltaTime = 0;

                }
            }
        }
    }
}
