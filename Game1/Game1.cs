using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Game1.Controllers;
using Game1.Factories;
using Game1.Interfaces;
using Game1.Collisions;
using Game1.States;
using System;
using Game1.GameStates;

namespace Game1
{
   
    public class OurMarioGame : Game
    {
        //initialize lists for controller and gameobjects

        public IWorld World { get; set; }
        private static readonly OurMarioGame instance = new OurMarioGame();
        public static OurMarioGame Instance { get => instance; }
        GraphicsDeviceManager graphics;
        public GameStateManager gameStateManager;
        SpriteBatch spriteBatch;
        public List<IObjects> ObjectsList;
        public List<IController> ControllersList;
        public Camera.Camera viewCamera;
        public  AllCollisionHandler collisionDetection;
        public bool UseMouseController = false; 
        public float zoom { get; set; }
        public static Vector2 CameraLocation = new Vector2(0, 0);
        //initialize a vector2 varial for future position changes purpose
        public Vector2 MarioPosition { get; set; }



        public OurMarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            TextureInitialize();

           //World = WorldFactory.CreateWorldDeveloper();
            gameStateManager = new GameStateManager(this);
            World = gameStateManager.world;
            ControllersList = new List<IController>();
            ControllersList.Add(new KeybroadController(this));
            ControllersList.Add(new GamepadController(this));
            ControllersList.Add(new MouseController(this));
            collisionDetection = new AllCollisionHandler(gameStateManager);

            viewCamera = new Camera.Camera(GraphicsDevice.Viewport, this, gameStateManager.world);
            zoom = 1.3f;

            graphics.PreferredBackBufferWidth = 640;  
            graphics.PreferredBackBufferHeight = 480;   
            graphics.ApplyChanges();

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gametime)
        {
            
            foreach (IController controller in ControllersList)
            {
                if (controller is MouseController && UseMouseController)
                {
                    controller.Update(gametime);
                }
                else if (!(controller is MouseController))
                {
                    controller.Update(gametime);
                }
            }
            gameStateManager.Update(gametime);
            //World.Update(gametime);
            collisionDetection.CheckAllCollisions();

            //if (gameStateManager.world.Mario.resetWorld)
            //{
            //    gameStateManager.world = WorldFactory.CreateWorldDeveloper();
            //    ControllersList = new List<IController>();
            //    ControllersList.Add(new KeybroadController(this));
            //    ControllersList.Add(new GamepadController(this));
            //    ControllersList.Add(new MouseController(this));
            //    collisionDetection = new AllCollisionHandler(gameStateManager.world);
            //}
            //Console.WriteLine("Width: "+Window.ClientBounds.Width);
            base.Update(gametime);
        }

         private void SetBackgroundColor()
        {
            if (gameStateManager.isBlack)
            {
                GraphicsDevice.Clear(Color.Black);
            }
            else
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            SetBackgroundColor();




            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, GetViewMatrix());
           // World.Draw(spriteBatch);
            gameStateManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);

        }


        public void TextureInitialize()
        {
            BlockSpritesFactory.Instance.LoadTextures(Content);
            EnemySpritesFactory.Instance.LoadTextures(Content);
            MarioSpritesFactory.instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            ScenerySpriteFactory.Instance.LoadAllTextures(Content);
            GameSpriteFactory.Instance.LoadAllTextures(Content);
            MenuFactory.Instance.LoadAllTextures(Content);
            SoundFactory.Instance.LoadAllTextures(Content);
        }

        public Matrix GetViewMatrix()
        {
            Matrix viewMarix;
            
            if (gameStateManager.world.Mario.Location.X <= GraphicsDevice.Viewport.Width / 2 - 50)
            {
                viewMarix = Matrix.CreateTranslation(new Vector3(-GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 - graphics.PreferredBackBufferHeight, 0)) *
                         Matrix.CreateTranslation(new Vector3(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 0)) *
                         Matrix.CreateScale(zoom, zoom, 1);
                //Console.WriteLine(GraphicsDevice.Viewport.Width/2-50);
            }
            else
            {
                
                viewMarix = Matrix.CreateTranslation(new Vector3(-gameStateManager.world.Mario.Location.X - 50, GraphicsDevice.Viewport.Height / 2 - graphics.PreferredBackBufferHeight, 0)) *
                         Matrix.CreateTranslation(new Vector3(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 0)) *
                         Matrix.CreateScale(zoom, zoom, 1);
            }
            CameraLocation = new Vector2(Math.Max(0,gameStateManager.world.Mario.Location.X-(GraphicsDevice.Viewport.Width/2-50)), CameraLocation.Y);
            return viewMarix;
        }
    }
}
