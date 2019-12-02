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
    class FireBallEnemyHandler
    {
        public void FireBallHandleLoop(IList<IBlock> BlocksAround, Fireball fireball, Rectangle fireballBox, IWorld Level, IPlayer mario)
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyBox = enemy.Rectangle;
                Rectangle intersectionBox = Rectangle.Intersect(fireballBox, enemyBox);

                if (!(enemy.State is KoopaFlippedState))
                {
                    if (!intersectionBox.IsEmpty)
                    {
                        FireBallEnemyHandler.HandleCollision(fireball, enemy);
                        mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.EnemyScore, enemy.Location, true));
                    }
                }

            }
        }
        public static void HandleCollision(Fireball fireball, IEnemy enemy)
        {
            fireball.Explode();
            enemy.CollideWithFireball(fireball);
            SoundFactory.Instance.PlayKickEnemySound();
        }
    }
}
