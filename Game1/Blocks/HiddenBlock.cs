using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.States;
using Game1.Interfaces;
using Game1.Collisions;
using Game1.Factories;

namespace Game1.Blocks
{
    class HiddenBlock: IBlock
    {

        public Vector2 Location { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, State.Sprite.Width, State.Sprite.Height);
        private IBlockState State;

        public HiddenBlock(Vector2 position)
        {
            State = new HiddenBlockState();
            Location = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Location);
        }

        public void Update(GameTime gametime)
        {
       
        }

        public void BecomeUsed()
        {
            State = new UsedBlockState();
        }
        public void CollisionWithMario(IWorld level, IPlayer mario, Direction direction)
        {
            if (direction == Direction.Bottom)
            {
                BecomeUsed();
                SoundFactory.Instance.PlayBumpBlockSound();
            }
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
