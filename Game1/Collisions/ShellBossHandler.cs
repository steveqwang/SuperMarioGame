using Game1.Player;
using Game1.Interfaces;
using Game1.States;
using Microsoft.Xna.Framework;
using System;
using Game1.Factories;
using Game1.Utility;
using Game1.GameStates;

namespace Game1.Collisions
{
    class ShellBossHandler
    {

        public void CheckShellBossCollision(IWorld Level, GameStateManager gameState)
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                if (enemy.State is KoopaStompedKickedState)
                {
                    Rectangle enemyBox = enemy.Rectangle;
                    foreach (IBoss boss in Level.Bosses)
                    {
                        if (boss != enemy)
                        {
                            Rectangle bossBox = boss.Rectangle;
                            Rectangle intersectionBox = Rectangle.Intersect(enemyBox, bossBox);
                            if (!intersectionBox.IsEmpty)
                            {
                                ShellBossHandler.HandleCollision(gameState.world.Mario, enemy, boss);
                            }
                        }
                    }
                }
            }
        }
        public static void HandleCollision(IPlayer mario, IEnemy enemy, IBoss boss)
        {
            boss.CollidedWithShell(enemy);
            if (boss.Life == 0) {
                mario.ScoreObjects.Add(new Score.ScoreObject(Util.Instance.BossScore, enemy.Location, true));
                mario.Scores += 3000;
            }        
            SoundFactory.Instance.PlayKickEnemySound();

        }
    }
}
