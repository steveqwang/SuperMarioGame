using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.Utility;

namespace Game1.PhysicalProperty
{
    public class BossPhysicalProperty
    {
        private IBoss boss;
        public Vector2 Velocity { get; set; }
        public Vector2 Accerlation { get; set; }
        public bool IsFacingLeft { get; set; }
        public bool IsAlive { get; set; }
        private float bossSpeed;


        public BossPhysicalProperty(IBoss boss)
        {
            bossSpeed = 32f;
            IsFacingLeft = true;
            this.boss = boss;
            IsAlive = true;
            BossMove();
            
        }

        public void BossMove()
        {
            Accerlation = new Vector2(Util.Instance.Zero, Util.Instance.Thousand);
            SetSpeed();
            Velocity = new Vector2(bossSpeed, Velocity.Y);
        }

        

        private void SetSpeed()
        {
            if (IsFacingLeft)
            {
                bossSpeed = -Math.Abs(bossSpeed);
            }
            else
            {
                bossSpeed = Math.Abs(bossSpeed);
            }
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
            boss.Location += Velocity * deltaTime;
        }
    }
}
