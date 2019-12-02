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
using Game1.Utility;


namespace Game1.GameStates
{
    class GameOverState:IGameState
    {
        public bool isPause { get; set; }
        private enum Option { Play, Quit };

        int remaingTime = Util.Instance.TwoThousands;
        private SpriteFont spriteFont;
        private ISprite selector = MenuFactory.Instance.CreateMushroomSelector();
        private Vector2[] optionsLocations;
        private int OptionIndex;
        private Option[] options;
        private bool canExecute;
        private float remainingTime = Util.Instance.Hundred;


        GameStateManager gameStateManager;
        public GameOverState(GameStateManager gameStateManager)
        {
            SoundManager.Instance.PlayGameOverSong();
            spriteFont = MenuFactory.Instance.CreateSpriteFont();
            OptionIndex = Util.Instance.Zero;
            options = new Option[2];
            optionsLocations = new Vector2[] { new Vector2(OurMarioGame.CameraLocation.X + 150, OurMarioGame.CameraLocation.Y + 100), new Vector2(OurMarioGame.CameraLocation.X + 150, OurMarioGame.CameraLocation.Y + 150) };
            options[0] = Option.Play;
            options[1] = Option.Quit;
            canExecute = true;
            this.gameStateManager = gameStateManager;
        }

        public void Action()
        {
            switch (options[OptionIndex])
            {
                case Option.Play:
                    backToInitial();
                    break;
                case Option.Quit:
                    gameStateManager.Quit();
                    break;
            }
        }
        public void Left()
        {

        }
        public void Right()
        {

        }
        public void Down()
        {
            if (!canExecute) return;
            OptionIndex = (OptionIndex == options.Length - 1) ? 0 : OptionIndex + 1;
            canExecute = false;
            SoundFactory.Instance.PlayFireballSound();
        }
        public void freezed()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, Util.Instance.String_Game_Over, new Vector2(OurMarioGame.CameraLocation.X + 200, OurMarioGame.CameraLocation.Y+50), Color.White);
            spriteBatch.DrawString(spriteFont, Util.Instance.String_tryAgain, new Vector2(OurMarioGame.CameraLocation.X + 200, OurMarioGame.CameraLocation.Y + 100), Color.White);
            spriteBatch.DrawString(spriteFont, Util.Instance.String_Quit, new Vector2(OurMarioGame.CameraLocation.X + 200, OurMarioGame.CameraLocation.Y + 150), Color.White);
            selector.Draw(spriteBatch, optionsLocations[OptionIndex]);
        }

        public void Up()
        {
            if (!canExecute) return;
            OptionIndex = (OptionIndex == Util.Instance.Zero) ? options.Length - 1 : OptionIndex - 1;
            canExecute = false;
            SoundFactory.Instance.PlayFireballSound();
        }

        public void Update(GameTime gameTime)
        {
            if (!canExecute)
            {
                remainingTime -= gameTime.ElapsedGameTime.Milliseconds;
                if (remainingTime <= Util.Instance.Zero)
                {
                    canExecute = true;
                    remainingTime = Util.Instance.Hundred;
                }
            }
        }
        public void backToInitial()
        {
            gameStateManager.state = new WorldState(gameStateManager,WorldState.WorldLevel.World1_1);
            gameStateManager.Reset();
        }
    }
}
