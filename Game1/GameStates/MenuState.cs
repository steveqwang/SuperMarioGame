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
    public class MenuState:IGameState
    {
        public bool isPause { get; set; }

        GameStateManager gameStateManager;
        private enum Option { Play,Quit};
        private ISprite logo = MenuFactory.Instance.CreateLogoSprite();
        private int OptionIndex;
        private Option[] options;
        private Vector2[] optionsLocations;
        private bool canExecute;
        private float remainingTime = Util.Instance.Hundred;
        private ISprite selector = MenuFactory.Instance.CreateMushroomSelector();
        SpriteFont spriteFont = MenuFactory.Instance.CreateSpriteFont();
        public MenuState(GameStateManager gameStateManager)
        {
            SoundManager.Instance.PlayMenuSong();
            this.gameStateManager = gameStateManager;
            OptionIndex = Util.Instance.Zero;
            options = new Option[2];
            optionsLocations = new Vector2[]{ new Vector2(Util.Instance.One3rty, Util.Instance.Hundred),new Vector2(Util.Instance.One3rty, Util.Instance.TwoHundreds) };
            options[0] = Option.Play;
            options[1] = Option.Quit;
            canExecute = true;
        }
        // TODO: Change the use of magic variables and number to refering constants in Util class
        public void Draw(SpriteBatch spriteBatch)
        {
            logo.Draw(spriteBatch, new Vector2(Util.Instance.One5ty, Util.Instance.Zero));
            spriteBatch.DrawString(spriteFont, Util.Instance.String_Begin, new Vector2(Util.Instance.Two2ty, Util.Instance.Hundred), Color.White);
            spriteBatch.DrawString(spriteFont, Util.Instance.String_Quit, new Vector2(Util.Instance.Two2ty, Util.Instance.TwoHundreds), Color.White);
            selector.Draw(spriteBatch, optionsLocations[OptionIndex]);
        }
        public void Up()
        {
            if (!canExecute) return;
            OptionIndex = (OptionIndex == Util.Instance.Zero) ? options.Length - 1 : OptionIndex - 1;
            canExecute = false;
            SoundFactory.Instance.PlayFireballSound();
        }
        public void Down()
        {
            Console.WriteLine(canExecute+ Util.Instance.String_longSpace+ remainingTime);
            if (!canExecute) return;
            OptionIndex = (OptionIndex == options.Length-1) ? 0 : OptionIndex + 1;
            canExecute = false;
            SoundFactory.Instance.PlayFireballSound();
        }
        public void Left()
        {

        }
        public void Right() { }
        public void freezed()
        {

        }
        public void Action()
        {
            switch(options[OptionIndex]){
                case Option.Play:
                    gameStateManager.state = new TransitionState(gameStateManager,3,WorldState.WorldLevel.World1_1);
                    SoundManager.Instance.PlayMainSong();
                    break;
                case Option.Quit:
                    gameStateManager.Quit();
                    break;
            }
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
    }
}
