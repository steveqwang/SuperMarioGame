using Game1.Collisions;
using Game1.Factories;
using Game1.Interfaces;
using Game1.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.PhysicalProperty;


namespace Game1.Blocks
{
    public class BrickBlock : IBlock
    {

        public Vector2 Location { get; set; }
        public BlocksPhysicalProperty BlockPhysics { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, State.Sprite.Width, State.Sprite.Height);
        
        private IBlockState State;

        public BrickBlock(Vector2 position)
        {
         
            State = new BrickShowedState();
            Location = position;
            BlockPhysics = new BlocksPhysicalProperty(this);
            HaveCollision = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Location);
        }

        public void Update(GameTime gametime)
        {
            BlockPhysics.Update(gametime);
        }

        public void Disappear() {
            State = new BlockDisappearedState();
            if (HaveCollision) {
                SoundFactory.Instance.PlayBreakBlockSound();
                HaveCollision = false;
                Location += new Vector2(0, 2000);
            }
        }
        public void CollisionWithMario(IWorld level, IPlayer mario, Direction direction)
        {
            if(direction == Direction.Bottom)
            {
                if (!(mario.CurrentPowerState is MarioSmallState) && !(mario.CurrentPowerState is MarioStarSmallState))
                {
                    Disappear();
                }
                else {
                    SoundFactory.Instance.PlayBumpBlockSound();
                    BlockPhysics.BlockJump();
                }
                
            }
            if(!(State is BlockDisappearedState))
            {
                MarioBlockHandler.UpateLocation(mario, this, direction);
            }
            
        }
        public void CollisionWithEnemy(IEnemy enemy, Direction direction)
        {
            if (!(State is BlockDisappearedState))
            {
                EnemyBlockHandler.UpateLocation(enemy, this, direction);
                if (direction == Direction.Top) {
                    enemy.BeFlipped();
                }
            }
        }

        public void CollisionWithBoss(IBoss boss, Direction direction)
        {
            if (!(State is BlockDisappearedState))
            {
                BossBlockHandler.UpateLocation(boss, this, direction);
                if (direction == Direction.Top)
                {
                    boss.TakeDamage();
                }
            }
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
