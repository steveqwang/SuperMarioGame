using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Game1.Sprites;
using Game1.Utility;
using Game1.Items;
using Game1.Factories;


namespace Game1.Items
{
    public class EnemyPortal : IObjects
    {

        public EnemyPortal(Vector2 location)
        {
            sprite = ItemFactory.Instance.CreateEnemiesPortalSprite();
            Location = location;
            spawnTimer = Util.Instance.FiveF;
        }
        
        public Vector2 Location { get; set; }
        public IWorld Level { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, sprite.Width, sprite.Height);

        private ISprite sprite;
        private double spawnTimer;

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch, Location);
        }

        public void Update(GameTime gametime)
        {
            //spawnTimer -= gametime.ElapsedGameTime.TotalSeconds;
            //if (spawnTimer <= 0)
            //{
            //    SpawnEnemy();
            //    spawnTimer = 5f;
            //}
            //sprite.Update(gametime);
        }

        public void UpdateWithLevel(GameTime gametime, IWorld Level)
        {
            spawnTimer -= gametime.ElapsedGameTime.TotalSeconds;
            if (spawnTimer <= 0)
            {
                SpawnEnemy(Level);
                spawnTimer = 5f;
            }
            sprite.Update(gametime);
        }

        private void SpawnEnemy(IWorld Level)
        {
            Random rng = new Random();

            float val = (float)rng.NextDouble();
            if (val < 0.15f)
            {
                Level.Enemies.Add(new Enemies.Koopa(Location));
                //OurMarioGame.Instance.gameStateManager.world.Enemies.Add(new Enemies.Koopa(Location));
                //OurMarioGame.World.Items.Add(new Gold(new Vector2(Location.X + Util.Instance.Gold_positionFix_x, Location.Y - Util.Instance.Bonus_positionFix_y), false));
            }
            else if ((val >= 0.15f)&&(val< 0.6f))
            {
                Level.Enemies.Add(new Enemies.Goomba(Location));

                //OurMarioGame.Instance.gameStateManager.world.Enemies.Add(new Enemies.Goomba(Location));
                //OurMarioGame.World.Items.Add(new Gold(new Vector2(Location.X + Util.Instance.Gold_positionFix_x, Location.Y - Util.Instance.Bonus_positionFix_y), false));
            }
            else if((val >= 0.6f) && (val < 0.8f))
            {
                Level.Items.Add(new Gold(Location, false));
            }
            else
            {
                Level.Items.Add(new RedMushroom(Location));
            }
        }
    }
}