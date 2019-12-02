using Game1.Factories;
using Game1.Interfaces;
using Game1.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameStates
{
    class GameWinState : IGameState
    {
        public bool isPause { get; set; }
        float remaingTime = 2000f;
        private readonly SpriteFont spriteFont;
        GameStateManager gameStateManager;
        public GameWinState(GameStateManager gameStateManager)
        {
            spriteFont = MenuFactory.Instance.CreateSpriteFont();
            this.gameStateManager = gameStateManager;
        }

        public void Action()
        {

        }
        public void Left()
        {

        }
        public void Right()
        {

        }
        public void Down()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, "You Win", new Vector2(OurMarioGame.CameraLocation.X + 200, OurMarioGame.CameraLocation.Y + 175), Color.White);
        }

        public void Up()
        {

        }
        public void freezed() {

        }
        public void Update(GameTime gameTime)
        {
            remaingTime -= gameTime.ElapsedGameTime.Milliseconds;
            if (remaingTime <= 0)
            {
                BackToInitial();
            }
        }
        public void BackToInitial()
        {
            gameStateManager.state = new MenuState(gameStateManager);
            gameStateManager.isBlack = false;
            while (gameStateManager.world.Bosses.Count > 0)
            {
                gameStateManager.world.Bosses.RemoveAt(0);
            }
            
            //gameStateManager.Reset();
        }
    }
}
