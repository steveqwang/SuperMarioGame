using Game1.Factories;
using Game1.Interfaces;
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
    public class WorldState : IGameState
    {
        public bool isPause { get; set; }
        public enum WorldLevel {World1_1,World1_2,World2_2};
        public WorldLevel level;
        private readonly SpriteFont spriteFont;
        private int PauseCoolDown;
        private bool canPause;
        public  string World_ID;
        private double timercounter;
        public bool timeFreeze;
        GameStateManager gameStateManager;
        private int overTimer;
        public WorldState(GameStateManager gameStateManager, WorldLevel level)
        {
            isPause = false;
            canPause = false;
            PauseCoolDown = Util.Instance.Hundred;
            
            spriteFont = MenuFactory.Instance.CreateSpriteFont();
            this.gameStateManager = gameStateManager;
            timercounter = Util.Instance.Zero;
            this.level = level;
            timeFreeze = false;
            changeWorldID();
            overTimer = 0;
        }
        public void Action()
        {
            Pause();
        }
        public void Pause()
        {
            if (!canPause) return;
            isPause = !isPause;
            canPause = false;
        }
        public void Down()
        {
            gameStateManager.world.Mario.Down();
        }
         public void Left()
        {

        }
        public void Right()
        {

        }
        public void freezed() {
            timeFreeze = true;
        }
        private void changeWorldID()
        {
            switch (level)
            {
                case WorldLevel.World1_1:
                    World_ID = Util.Instance.String_1_1;
                    break;
                case WorldLevel.World1_2:
                    World_ID = Util.Instance.String_1_2;
                    break;
                case WorldLevel.World2_2:
                    World_ID = Util.Instance.String_2_2;
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            gameStateManager.world.Draw(spriteBatch);
            changeWorldID();
            spriteBatch.DrawString(spriteFont, Util.Instance.String_World + World_ID, new Vector2(OurMarioGame.CameraLocation.X+Util.Instance.Zero, OurMarioGame.CameraLocation.Y), Color.White);
            spriteBatch.DrawString(spriteFont, Util.Instance.String_Scores + gameStateManager.world.Mario.Scores, new Vector2(OurMarioGame.CameraLocation.X +Util.Instance.One5ty, OurMarioGame.CameraLocation.Y), Color.White);
            spriteBatch.DrawString(spriteFont, Util.Instance.String_life + gameStateManager.world.Mario.lifes, new Vector2(OurMarioGame.CameraLocation.X + Util.Instance.Zero, OurMarioGame.CameraLocation.Y + Util.Instance.Twenty), Color.White);
            spriteBatch.DrawString(spriteFont, Util.Instance.String_Timer + (int)gameStateManager.Totaltimer, new Vector2(OurMarioGame.CameraLocation.X + Util.Instance.One5ty, OurMarioGame.CameraLocation.Y + Util.Instance.Twenty), Color.White);
            if (isPause)
            {

                spriteBatch.DrawString(spriteFont, Util.Instance.String_PAUSE , new Vector2(OurMarioGame.CameraLocation.X + Util.Instance.FourHundreds, OurMarioGame.CameraLocation.Y+ Util.Instance.ThreeHundreds), Color.White);
            }
        }

        public void Up()
        {
            gameStateManager.world.Mario.MarioPhysics.Jump();
            gameStateManager.world.Mario.Up();
        }

        public void Update(GameTime gameTime)
        {

            if (!isPause && !timeFreeze) {
                gameStateManager.Totaltimer -= (gameTime.ElapsedGameTime.TotalSeconds);
            }
               
            
            
            if (gameStateManager.Totaltimer <= 0)
            {
                gameStateManager.Totaltimer = Util.Instance.TotalTimer;
                gameStateManager.world.Mario.lifes -- ;
            }
            if (!canPause)
            {
                PauseCoolDown--;
                if(PauseCoolDown <= 0)
                {
                    canPause = true;
                    PauseCoolDown = Util.Instance.Hundred;
                }
            }
            if (isPause) return;
            if(gameStateManager.world.Mario.lifes == 0)
            {
                overTimer++;
                if (overTimer == 200) {
                    gameStateManager.state = new GameOverState(gameStateManager);
                    overTimer = 0;
                }
                
            }
            gameStateManager.world.Update(gameTime);
            gameStateManager.world.UpdatePortal(gameTime, gameStateManager.world);
        }

    }
}
