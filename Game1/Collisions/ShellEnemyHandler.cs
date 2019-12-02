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
    class ShellEnemyHandler
    {

        public void CheckShellEnemyCollision(IWorld Level, GameStateManager gameState)
        {
            foreach (IEnemy enemy1 in Level.Enemies)
            {
                if (enemy1.State is KoopaStompedKickedState)
                {
                    Rectangle enemy1Box = enemy1.Rectangle;
                    foreach (IEnemy enemy2 in Level.Enemies)
                    {
                        if (enemy2 != enemy1)
                        {
                            Rectangle enemy2Box = enemy2.Rectangle;
                            Rectangle intersectionBox = Rectangle.Intersect(enemy1Box, enemy2Box);
                            if (!intersectionBox.IsEmpty)
                            {
                                ShellEnemyHandler.HandleCollision(gameState.world.Mario, enemy1, enemy2);
                            }
                        }
                    }
                }
            }
        }
        public static void HandleCollision(IPlayer mario,IEnemy enemy1, IEnemy enemy2)
        {
            enemy2.CollidedWithShell(enemy1);
            mario.ScoreObjects.Add(new Score.ScoreObject((Util.Instance.EnemyScore)*enemy1.Coefficient, enemy1.Location, true));
            mario.Scores += 100*enemy1.Coefficient;
            enemy1.Coefficient++;
            SoundFactory.Instance.PlayKickEnemySound();

        }
    }
}
