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

namespace Game1.Enemies
{
    class Koopa : IEnemy
    {
        public IEnemyActionState State { get; set; }
        public EnemyPhysicalProperty EnemyPhysics { get; set; }
        public int Coefficient { get; set; }

        public Vector2 Location { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, State.Width, State.Height);

        private int deathTimer;
        private int kickTimer;
        private int reviveTimer;
        private bool shouldDraw;
        private bool isStomped;
        private bool isKicked;


        public Koopa(Vector2 location)
        {
            EnemyPhysics = new EnemyPhysicalProperty(this);
            State = new KoopaMoveState(EnemyPhysics.IsFacingLeft);
            Location = location;
            deathTimer = Util.Instance.Koopa_deathtimer;
            kickTimer = Util.Instance.Koopa_kicktimer;
            reviveTimer = Util.Instance.Koopa_revivetimer;
            shouldDraw = true;
            isStomped = false;
            isKicked = false;
            Coefficient = 1;
        }

        public void BeFlipped()
        {
            if (!(State is KoopaFlippedState))
            {
                State = new KoopaFlippedState(this);
                EnemyPhysics.IsAlive = false;
            }
   
        }

        public void BeStomped()
        {
            State = new KoopaStompedState();
            EnemyPhysics.IsAlive = false;
            reviveTimer = Util.Instance.Koopa_deathtimer_BeStomped;
            if (!isStomped)
            {
                SoundFactory.Instance.PlayStompEnemySound();
                isStomped = true;
            }
        }

        public void BeKicked()
        {
            EnemyPhysics.IsAlive = true;
            State = new KoopaStompedKickedState(this);
            if (!isKicked)
            {
                SoundFactory.Instance.PlayKickEnemySound();
                isKicked = true;
            }
        }

        public void Revive()
        {
            bool tempFaceingDirection = EnemyPhysics.IsFacingLeft;
            State = new KoopaMoveState(EnemyPhysics.IsFacingLeft);
            EnemyPhysics = new EnemyPhysicalProperty(this);
            EnemyPhysics.IsFacingLeft = tempFaceingDirection;
            deathTimer = Util.Instance.Koopa_deathtimer_revive;
            kickTimer = Util.Instance.Koopa_kicktimer_revive;
            reviveTimer = Util.Instance.Koopa_revivetimer_revive;
            isStomped = false;
            isKicked = false;
            Coefficient = 1;
        }

        public void SwitchDirection()
        {
            State = new KoopaMoveState(EnemyPhysics.IsFacingLeft);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (shouldDraw) {
                State.Draw(spriteBatch, Location);
            }
            else
            {
                Location += new Vector2(Util.Instance.Koopa_draw_vecx, Util.Instance.Koopa_draw_vecy);
            }

        }

        public void Update(GameTime gametime)
        {
            if (State is KoopaFlippedState)
            {
                deathTimer++;
            }

            if (State is KoopaStompedKickedState)
            {
                kickTimer++;
            }

            if (State is KoopaStompedState)
            {
                reviveTimer++;
            }
            else
            {
                reviveTimer = Util.Instance.Koopa_revivetimer_update;
            }

            if (reviveTimer == Util.Instance.Koopa_update_ref250) {
                Revive();
            }

            if (deathTimer == Util.Instance.Koopa_update_ref100)
            {
                shouldDraw = false;
                deathTimer = Util.Instance.Koopa_deathtimer_update_100case;
            }
            else
            {
                State.Update(gametime);
                EnemyPhysics.Update(gametime);
                EnemyPhysics.EnemyMove();
            }
        }

        public void CollidedWithMario(IPlayer mario, Direction direction)
        {
            if (State is KoopaFlippedState)
            {
                return;
            }
            if (State is KoopaMoveState || State is KoopaStompedKickedState)
            {
                if (mario.CurrentPowerState is MarioStarBigState || mario.CurrentPowerState is MarioStarSmallState)
                {
                    BeFlipped();
                    mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.EnemyScore * mario.Coefficient, Location, true));
                    mario.Scores += 100 ;
                }
                else if (direction == Direction.Top)
                {
                    BeStomped();
                    mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.EnemyScore * mario.Coefficient, Location, true));
                    Coefficient = 1;
                    isKicked = false;
                    mario.canKick = false;
                    mario.Scores += 100 * mario.Coefficient;
                    mario.Coefficient++;
                    kickTimer = Util.Instance.Koopa_kicktimer_dirtop;
                }
                else
                {
                    if (State is KoopaStompedKickedState) {
                        if (kickTimer >= Util.Instance.Koopa_kickref) {
                            mario.TakeDamage();
                        }
                    }
                    if(State is KoopaMoveState)
                    {
                        mario.TakeDamage();
                       // mario.lifes--;
                    }
                }
            }

            if ((State is KoopaStompedState) && mario.canKick)
            {
                if (mario.CurrentPowerState is MarioStarBigState || mario.CurrentPowerState is MarioStarSmallState)
                {
                    BeFlipped();
                    mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.EnemyScore, Location, true));
                    mario.Scores += 100;
                }
                else
                {
                    if (direction == Direction.Left)
                    {
                        EnemyPhysics.IsFacingLeft = false;
                    }
                    else if (direction == Direction.Right)
                    {
                        EnemyPhysics.IsFacingLeft = true;
                    }
                    BeKicked();
                }
            }
        }

        public void CollidedWithBlock(IBlock block)
        {
            if (!(State is KoopaStompedKickedState)) {
                SwitchDirection();
            } 
        }

        public void CollidedWithShell(IEnemy shell)
        {
            BeFlipped();
        }

        public void CollideWithFireball(Fireball fireball)
        {
            BeFlipped();
        }
    }
}
