using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.States;
using Game1.Interfaces;
using Game1.Collisions;
using Game1.Factories;

namespace Game1.Blocks
{
    public class Pipe: IBlock
    {
        public Vector2 Location { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, blockSprite.Width, blockSprite.Height);
        private ISprite blockSprite;
        public bool isEntrance;

        public Pipe(Vector2 position, bool isEntrance)
        {
            this.isEntrance = isEntrance;
            blockSprite = BlockSpritesFactory.Instance.CreatePipeSprite();
            Location = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, Location);
        }

        public void Update(GameTime gametime)
        {
        }
        public void CollisionWithMario(IWorld level, IPlayer mario, Direction direction)
        {

            MarioBlockHandler.UpateLocation(mario, this, direction);
        }

        public void CollisionWithEnemy(IEnemy enemy, Direction direction)
        {
            EnemyBlockHandler.UpateLocation(enemy, this, direction);
        }
        public void CollisionWithBoss(IBoss boss, Direction direction)
        {
            BossBlockHandler.UpateLocation(boss, this, direction);
        }
        public void CollisionWithItem(IItem item, Direction direction)
        {
            ItemBlockHandler.UpateLocation(item, this, direction);
        }

        public void CollisionWithGameObject(Fireball fireball, Direction direction)
        {
            FireBallBlockHandler.UpdateLocation(fireball, this, direction);
        }
    }
}
