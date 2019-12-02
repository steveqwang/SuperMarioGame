using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1.States;
using Game1.Collisions;
using Game1.PhysicalProperty;
using Game1.Utility;
using Game1.Factories;
using Game1.GameTool;
using System.Collections;
using Game1.Sound;

namespace Game1.Enemies
{
    class Bowser : IBoss
    {
        public IEnemyActionState State { get; set; }
        public BossPhysicalProperty BossPhysics { get; set; }
        public Vector2 Location { get; set; }
        public bool IsControlled { get; set; }
        public int Life { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, State.Width, State.Height);
        private int deathTimer;
        private bool canBeDamaged;
        private int damageTimer;
        private int jumpTimer;
        private int randomTimer;
        private int randomNum;
        public bool IsActivate { get; set; }
        private int shootTimer;
        private int turnTimer;
        private int randomHeight;
        public IList<FireShot> fireShots { get; set; }
        private int heightFactor;

        public Bowser(Vector2 location)
        {
            BossPhysics = new BossPhysicalProperty(this);
            State = new BowserMoveState(BossPhysics.IsFacingLeft);
            Location = location;
            deathTimer = Util.Instance.Bowser_deathtimer;
            IsControlled = false;
            canBeDamaged = true;
            IsActivate = false;
            damageTimer = 0;
            jumpTimer = 0;
            randomTimer = 0;
            turnTimer = 0;
            randomNum = RandomNumber(20);
            Life = Util.Instance.Bowser_life;
            randomHeight = RandomNumber(40);
            fireShots = new List<FireShot>();
            shootTimer = 20;
            heightFactor = 0;

        }
        public void Jump()
        {
            if (IsActivate) {
                BossPhysics.Velocity = new Vector2(BossPhysics.Velocity.X, -350);
            } 
        }
        public int RandomNumber(int i)
        {
            Random random = new Random();
            return random.Next(i);
        }

        public void BeDead()
        {
            BossPhysics.IsAlive = false;
        }

        public void Shoot()
        {
            if (!BossPhysics.IsFacingLeft)
            {
                heightFactor = 80;
            }
            else
            {
                heightFactor = 0;

            }
            FireShot fireShot = new FireShot(new Vector2(Location.X + heightFactor, Location.Y + randomHeight), BossPhysics.IsFacingLeft);
            fireShots.Add(fireShot);
        }

        public void CollidedWithMario(IPlayer mario, Direction direction)
        {
            if (!BossPhysics.IsAlive)
            {
                return;
            }
            if (direction == Direction.Top || mario.CurrentPowerState is MarioStarBigState || mario.CurrentPowerState is MarioStarSmallState)
            {
                if (canBeDamaged)
                {
                    Life--;
                    //SoundManager.Instance.PlayPlayerDeadMusic();
                    canBeDamaged = false;
                }
                if (Life == 0) {
                    mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.BossScore, Location, true));
                    mario.Scores += 3000;
                }
            }
            else
            {
                mario.TakeDamage();
            }
        }

        public void CollidedWithShell(IEnemy shell)
        {
            TakeDamage();
        }

        public void CollideWithFireball(Fireball fireball)
        {
            TakeDamage();
        }

        public void TakeDamage()
        {
            if (!BossPhysics.IsAlive)
            {
                return;
            }
            if (canBeDamaged)
            {
                Life--;
                canBeDamaged = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (canBeDamaged)
            {
               State.Draw(spriteBatch, Location);
            }
            else if (damageTimer % 2 == Util.Instance.Zero)
            {
               State.Draw(spriteBatch, Location);
            }

            foreach (FireShot fireShot in fireShots)
            {
                fireShot.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gametime)
        {
            randomHeight = RandomNumber(40);
            if (Life <= 0)
            {
                BeDead();
            }
            if (!BossPhysics.IsAlive)
            {
                deathTimer++;
            }
            if (!canBeDamaged)
            {
                damageTimer++;
            }
            if (damageTimer == 50)
            {
                canBeDamaged = true;
                damageTimer = 0;
            }
            if (shootTimer == 0)
            {
                shootTimer = 20 + RandomNumber(100);
                Shoot();
            }
            else
            {
                --shootTimer;
            }
            foreach (FireShot fireShot in fireShots)
            {
                fireShot.Update(gametime);
            }
            jumpTimer++;
            if (jumpTimer == 80)
            {
                if (randomNum % 2 == 0)
                {
                    Jump();
                }    
                jumpTimer = 0;           
            }
            randomTimer++;
            if (randomTimer == 160)
            {
                randomNum = RandomNumber(20);
                randomTimer = 0;
            }
            turnTimer++;
            if (turnTimer == 80)
            {
                if (randomNum % 3 == 0 && IsActivate)
                {
                    BossPhysics.IsFacingLeft = !BossPhysics.IsFacingLeft;
                    State = new BowserMoveState(BossPhysics.IsFacingLeft);
                }
                turnTimer = 0;
            }

            if (deathTimer == Util.Instance.Koopa_update_ref100)
            {
                deathTimer = Util.Instance.Koopa_deathtimer_update_100case;
                Location += new Vector2(0, 1000);
            }
            else
            {
                State.Update(gametime);
                BossPhysics.Update(gametime);
                BossPhysics.BossMove();
            }
        }
    }
}
