using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.Utility;

namespace Game1.PhysicalProperty
{
    public class EnemyPhysicalProperty
    {
        private IEnemy enemy;
        public Vector2 Velocity { get; set; }
        public Vector2 Accerlation { get; set; }
        public bool IsFacingLeft { get; set; }
        public bool IsAlive { get; set; }
        public bool IsOnBlock { get; set; }
        private float enemySpeed;

        public EnemyPhysicalProperty(IEnemy enemy)
        {
            enemySpeed = Util.Instance.Float_16f;
            this.enemy = enemy;
            IsFacingLeft = true;
            IsAlive = true;
            IsOnBlock = true;
            EnemyMove();
        }

        public void EnemyMove()
        {
            Accerlation = new Vector2(Util.Instance.Zero, Util.Instance.Thousand);
            SetSpeed();
            Velocity = new Vector2(enemySpeed, Velocity.Y);
        }

        private void SetSpeed()
        {
            if (IsFacingLeft)
            {
                enemySpeed = -Math.Abs(enemySpeed);
            }
            else
            {
                enemySpeed = Math.Abs(enemySpeed);
            }
        }

        public void KoopaKickedSpeed()
        {
            enemySpeed = 150f;
        }

        public void BeFlipped()
        {
            enemy.Location += new Vector2(Util.Instance.Zero, Util.Instance.Float_neg20f);
        }


        public void Update(GameTime gametime)
        {
            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;
            if (Velocity.Y > 256)
            {
                Velocity = new Vector2(Velocity.X, 256);
            }
            else
            {
                Velocity += Accerlation * deltaTime;
            }
            if (!IsAlive)
            {
                Velocity = new Vector2(Util.Instance.Zero, Velocity.Y);
            }
            enemy.Location += Velocity * deltaTime;
        }
    }
}
