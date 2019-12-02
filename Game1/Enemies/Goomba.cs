using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.States;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1.Collisions;
using Game1.PhysicalProperty;
using Game1.Utility;
using Game1.Factories;

namespace Game1.Enemies
{
    class Goomba : IEnemy
    {
        public IEnemyActionState State { get; set; }

        public int Coefficient { get; set; }
        public Vector2 Location { get ; set ; }
        public EnemyPhysicalProperty EnemyPhysics { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Location.X, (int)Location.Y, State.Width, State.Height);

        private bool isStomped;
        private int deathTimer;
        private bool shouldDraw;

        public  Goomba(Vector2 location) {

            State = new GoombaMoveState();
            EnemyPhysics = new EnemyPhysicalProperty(this);
            Location = location;
            deathTimer = Util.Instance.Goomba_D_timer;
            shouldDraw = true;
            isStomped = false;
            Coefficient = 1;
        }

        public void BeFlipped()
        {
            if (!(State is GoombaFlippedState))
            {
                State = new GoombaFlippedState(this);
                EnemyPhysics.IsAlive = false;
            }
        }

        public void BeStomped()
        {
            State = new GoombaStompedState();
            EnemyPhysics.IsAlive = false;
            isStomped = true;
            if (isStomped)
            {
                SoundFactory.Instance.PlayBreakBlockSound();

                isStomped = false;
            }
        }

        public void CollidedWithMario(IPlayer mario, Direction direction)
        {
            if((State is GoombaStompedState) || (State is GoombaFlippedState))
            {
                return;
            }
            if(direction == Direction.Top)
            {
                BeStomped();
                mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.EnemyScore*mario.Coefficient, Location, true));
                mario.Scores += 100 * mario.Coefficient;
                mario.Coefficient++;
            }
            else if(mario.CurrentPowerState is MarioStarBigState|| mario.CurrentPowerState is MarioStarSmallState)
            {
                BeFlipped();
                mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.EnemyScore*mario.Coefficient, Location, true));
                mario.Scores += 100;
            }
            else
            {
                mario.TakeDamage();
                //mario.lifes--;
            }
        }

        public void SwitchDirection()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (shouldDraw) {
                State.Draw(spriteBatch, Location);
            }
            else
            {
                Location += new Vector2(Util.Instance.Goomba_draw_vec_x, Util.Instance.Goomba_draw_vec_y);
            }
            
        }

        public void Update(GameTime gametime)
        {
            if (!EnemyPhysics.IsAlive)
            {
                deathTimer++;
            }

            if (deathTimer == Util.Instance.Goomba_deathtime_ref)
            {
                shouldDraw = false;  
                deathTimer = Util.Instance.Goomba_deathtimer;
            }
            else
            {
                State.Update(gametime);
                EnemyPhysics.Update(gametime);
                EnemyPhysics.EnemyMove();
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

        public void CollidedWithBlock(IBlock block)
        {
            SwitchDirection();
        }
    }
}
