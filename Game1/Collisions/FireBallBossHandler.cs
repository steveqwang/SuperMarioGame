using Game1.Factories;
using Game1.Interfaces;
using Game1.States;
using Game1.Utility;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Collisions
{
    class FireBallBossHandler
    {
        public void FireBallHandleLoop(IList<IBlock> BlocksAround, Fireball fireball, Rectangle fireballBox, IWorld Level, IPlayer mario)
        {
            foreach (IBoss boss in Level.Bosses)
            {
                if (boss.BossPhysics.IsAlive) {
                    Rectangle bossBox = boss.Rectangle;
                    Rectangle intersectionBox = Rectangle.Intersect(fireballBox, bossBox);

                    if (!intersectionBox.IsEmpty)
                    {
                        FireBallBossHandler.HandleCollision(fireball, boss);
                        if (boss.Life == 0)
                        {
                            mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.BossScore, boss.Location, true));
                            mario.Scores += 3000;
                        }
                    }
                }
                
            }
        }
        public static void HandleCollision(Fireball fireball, IBoss boss)
        {
            fireball.Explode();
            boss.CollideWithFireball(fireball);
            SoundFactory.Instance.PlayKickEnemySound();
        }
    }
}
