using Game1.Collisions;
using Game1.Factories;
using Game1.Interfaces;
using Game1.Items;
using Game1.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Game1.Utility;
using Game1.PhysicalProperty;

namespace Game1.Blocks
{
    public class QuestionBlock : IBlock
    {
        public Vector2 Location { get; set; }
        public BlocksPhysicalProperty BlockPhysics { get; set; }
        public bool HaveCollision { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, State.Sprite.Width, State.Sprite.Height);
        private IBlockState State;
        private enum Bonus { Gold, Star, Flower, GreenShroom, RedShroom }
        Bonus caseNumber;
        bool hasBeUsed;
        public QuestionBlock(Vector2 position)
        {
            State = new QuestionBlockStates();
            Location = position;
            hasBeUsed = false;
            BlockPhysics = new BlocksPhysicalProperty(this);
        }
        public void BecomeUsed()
        {
            State = new UsedBlockState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Location);
        }

        public void Update(GameTime gametime)
        {
            BlockPhysics.Update(gametime);
        }
        public void CollisionWithMario(IWorld level,IPlayer mario, Direction direction)
        {
            if(direction == Direction.Bottom)
            {    
                BecomeUsed();
                if (!hasBeUsed)
                {
                    SoundFactory.Instance.PlayBumpBlockSound();
                    caseNumber = (Bonus)(new Random()).Next(Util.Instance.QBrandomLimitLow, Util.Instance.QBrandomLimitHigh);
                    level.Items.Add(InitiateBonus(caseNumber));
                    hasBeUsed = true;
                    BlockPhysics.BlockJump();
                }
                
            }
            MarioBlockHandler.UpateLocation(mario, this, direction);
        }
       
        private  IItem InitiateBonus(Bonus caseNumber)
        {
            IItem item;
            switch (caseNumber)
            {
                case Bonus.Gold:
                    item = new Gold(new Vector2(Location.X+Util.Instance.Gold_positionFix_x, Location.Y - Util.Instance.Bonus_positionFix_y), false);
                    break;
                case Bonus.Star:
                    item = new Star(new Vector2(Location.X, Location.Y - Util.Instance.Bonus_positionFix_y));
                    break;
                case Bonus.Flower:
                    item = new Flower(new Vector2(Location.X, Location.Y - Util.Instance.Bonus_positionFix_y));
                    break;
                case Bonus.GreenShroom:
                    item = new GreenMushroom(new Vector2(Location.X, Location.Y - Util.Instance.Bonus_positionFix_y));
                    break;
                default:
                    item = new RedMushroom(new Vector2(Location.X, Location.Y - Util.Instance.Bonus_positionFix_y));
                    break;
            }
            return item;
        }
        public void CollisionWithEnemy(IEnemy enemy, Direction direction)
        {
            EnemyBlockHandler.UpateLocation(enemy, this, direction);
            if (direction == Direction.Top)
            {
                enemy.BeFlipped();
            }
        }

        public void CollisionWithBoss(IBoss boss, Direction direction)
        {
            BossBlockHandler.UpateLocation(boss, this, direction);
            if (direction == Direction.Top)
            {
                boss.TakeDamage();
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
