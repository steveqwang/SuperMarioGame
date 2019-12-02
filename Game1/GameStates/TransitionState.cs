using Game1.Factories;
using Game1.Interfaces;
using Game1.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.GameStates
{
    public class TransitionState:IGameState
    {
        public bool isPause { get; set; }
        GameStateManager gameStateManager;
        int remaingTime;
        private SpriteFont spriteFont;
        int oldLifes;
        WorldState.WorldLevel level;
        public TransitionState(GameStateManager gameStateManager,int oldLifes, WorldState.WorldLevel level)
        {
            this.gameStateManager = gameStateManager;
            spriteFont = MenuFactory.Instance.CreateSpriteFont();
            this.oldLifes = oldLifes;
            remaingTime = Util.Instance.TwoThousands;
            this.level = level;
        }


        public void freezed()
        {

        }
        public void Action()
        {
            
        }

        public void Down()
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont,"Remaining Life:  "+oldLifes, new Vector2(OurMarioGame.CameraLocation.X + 150, OurMarioGame.CameraLocation.Y + 100), Color.White);
            spriteBatch.DrawString(spriteFont, level.ToString(), new Vector2(OurMarioGame.CameraLocation.X + 200, OurMarioGame.CameraLocation.Y + 50), Color.White);

        }

        public void Left()
        {
            
        }

        public void Right()
        {
            
        }

        public void Up()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            remaingTime -= gameTime.ElapsedGameTime.Milliseconds;
            
            if (remaingTime <= 0)
            {

                    if (level == WorldState.WorldLevel.World1_1)
                    {
                    gameStateManager.state = new WorldState(gameStateManager,level);
                    gameStateManager.ChangeToPrimaryWorld();
                }
                else if(level == WorldState.WorldLevel.World1_2)
                    {
                    gameStateManager.state = new WorldState(gameStateManager, level);
                    gameStateManager.ChangeToUnderground();
                    }
                    else if(level == WorldState.WorldLevel.World2_2)
                    {
                    gameStateManager.state = new WorldState(gameStateManager, level);
                    gameStateManager.ChangeToBowserWorld();
                    }
                }
                
                    
                    gameStateManager.world.Mario.lifes = oldLifes;
                    
                
                gameStateManager.world.Mario.resetWorld = false;
            }
        }
    }

