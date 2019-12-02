using Game1.Factories;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.States;
using Game1.Commands;
using Game1.Collisions;
using Game1.Controllers;
using Game1.Utility;
using Game1.CheatCodes;

namespace Game1.GameStates
{
    public class GameStateManager
    {
        public IGameState state;
        public IWorld world;
        private OurMarioGame GameClass;
        public double Totaltimer { get; set; }
        public bool isPrimary = true;
        public bool isBlack;
        Vector2 oldLocation;
        private IWorld oldWorld;
        private AllCheatCodesManager CheatCodeManager;
        public GameStateManager(OurMarioGame game)
        {
            isBlack = false;
            state = new MenuState(this);
            world = WorldFactory.CreateWorldDeveloper();
            CheatCodeManager = new AllCheatCodesManager(this);
            GameClass = game;
            Totaltimer = Util.Instance.TotalTimer;
        }
        public void Action()
        {
            state.Action();
        }
        public void Up()
        {
            state.Up();
            
        }
        public void Down()
        {
            state.Down();
        }
        public void Pause()
        {

        }
        public void freezeTimer() {
            if (state is WorldState) {
                state.freezed();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {

            
            if (state is WorldState)
            {
                CheatCodeManager.Update(gameTime);
                if (world.Bosses.Count > 0) { 
                bool AllDead = true;
                foreach (IBoss boss in world.Bosses)
                {
                    if (boss.BossPhysics.IsAlive) AllDead = false;
                }
                if (AllDead)
                {
                    state = new GameWinState(this);
                }
            }
            }
            if (state is WorldState && world.Mario.resetWorld)
            {
                if (world.Mario.lifes > 0)
                {

                    int original = world.Mario.lifes;
                    Reset();
                    world.Mario.lifes = original;
                    WorldState temp = (WorldState)state;
                    state = new TransitionState(this, original, temp.level);
                }
                else 
                {
                    state = new GameOverState(this);
                }
                
            }
            state.Update(gameTime);
        }
        public void ChangeWorld()
        {
            int oldScores = world.Mario.Scores;
            int oldLifes = world.Mario.lifes;
            IMarioPowerState oldState = world.Mario.CurrentPowerState;
            if (isPrimary)
            {
                oldLocation = world.Mario.Location;
                ChangeToUnderground();
                
            }
            else
            {
                ChangeToPrimaryWorld();
                world.Mario.Location = new Vector2(oldLocation.X,oldLocation.Y-20);
                
            }
            isPrimary = !isPrimary;
            world.Mario.Scores = oldScores;
            world.Mario.lifes = oldLifes;
            world.Mario.CurrentPowerState = oldState;
            
            
        }
        public void ChangeToUnderground()
        {
            isBlack = false;
            oldWorld = world;
            world = WorldFactory.CreateUndergroundWorld();
            GameClass.collisionDetection = new AllCollisionHandler(this);
            GameClass.ControllersList = new List<IController>();
            GameClass.ControllersList.Add(new KeybroadController(GameClass));
           GameClass.ControllersList.Add(new GamepadController(GameClass));
            GameClass.ControllersList.Add(new MouseController(GameClass));
            WorldState temp = (WorldState)state;
            temp.level = WorldState.WorldLevel.World1_2;
            state = temp;
        }
        public void ChangeToPrimaryWorld ()
        {
            isBlack = false;
            if (oldWorld != null)
            {
                world = oldWorld;
            }
            else
            {
                world = WorldFactory.CreateWorldDeveloper();
            }
            
            GameClass.collisionDetection = new AllCollisionHandler(this);
            GameClass.ControllersList = new List<IController>();
            GameClass.ControllersList.Add(new KeybroadController(GameClass));
            GameClass.ControllersList.Add(new GamepadController(GameClass));
            GameClass.ControllersList.Add(new MouseController(GameClass));
            WorldState temp = (WorldState)state;
            temp.level = WorldState.WorldLevel.World1_1;
            state = temp;
        }
        public void ChangeToBowserWorld()
        {
            isBlack = true;
            int oldScores = world.Mario.Scores;
            int oldLifes = world.Mario.lifes;
            IMarioPowerState oldState = world.Mario.CurrentPowerState;

            world = WorldFactory.CreateBowserWorld();
            
            world.Mario.Scores = oldScores;
            world.Mario.lifes = oldLifes;
            world.Mario.CurrentPowerState = oldState;
            GameClass.collisionDetection = new AllCollisionHandler(this);
            GameClass.ControllersList = new List<IController>();
            GameClass.ControllersList.Add(new KeybroadController(GameClass));
            GameClass.ControllersList.Add(new GamepadController(GameClass));
            GameClass.ControllersList.Add(new MouseController(GameClass));
            if(state is WorldState)
            {
                WorldState temp = (WorldState)state;
                temp.level = WorldState.WorldLevel.World2_2;
                state = temp;
            }
            
        }
        public void Reset()
        {
            new PressRToResetCommand(GameClass).Execute();
            Totaltimer = Util.Instance.TotalTimer;
            world.Mario.resetWorld = false;
        }
       
        public void Quit()
        {
            GameClass.Exit();
        }
    }
}
