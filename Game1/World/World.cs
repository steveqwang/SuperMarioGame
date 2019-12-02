using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Game1.Library;
using Game1.Player;
using Game1.GameTool;
using Game1.Score;
using Game1.Items;

namespace Game1.World
{
    public class World : IWorld
    {
        public IList<BlockArray> Blocks { get; set; }
        public int Width { get; private set; }

        public int Height { get; private set; }

        public IPlayer Mario { get; set; }

        public IList<IEnemy> Enemies { get; set; }
        public IList<IBoss> Bosses { get; set; }

        public IList<EnemyPortal> EnemyPortals { get; set; }

        public IList<IItem> Items { get; set; }
        public IList<Fireball> Fireballs { get; set; }
        public IList<FireShot> FireShots { get; set; }

        public IList<IScenery> Sceneries { get; set; }
        public IList<Castle> Castles { get; set; }
        public IList<FlagStuff> FlagStuffs { get; set; }
        private IList<Fireball> RemoveFireballList { get; set; }
        public IList<FireHell> FireHells { get; set; }

        public IList<ScoreObject> Scores { get; }

        private IList<ScoreObject> scoresRemoveList;


        public World(int width, int height)
        {
            Width = width;
            Height = height;
            Mario = new MarioPlayer();
            Blocks = new List<BlockArray>(Width);
            for (int i = 0; i < Width; i++)
            {
                Blocks.Add(new BlockArray(Height));
            }
            Enemies = new List<IEnemy>();
            Bosses = new List<IBoss>();
            FireHells = new List<FireHell>();

            Items = new List<IItem>();
            Sceneries = new List<IScenery>();
            Fireballs = new List<Fireball>();
            EnemyPortals = new List<EnemyPortal>();

            RemoveFireballList = new List<Fireball>();
            FireShots = new List<FireShot>();
            Castles = new List<Castle>();
            FlagStuffs = new List<FlagStuff>();
            Scores = Mario.ScoreObjects;
            scoresRemoveList = new List<ScoreObject>();
        }


        public void UpdatePortal(GameTime gametime, IWorld Level)
        {
            foreach (EnemyPortal enemyPortal in EnemyPortals)
            {
                enemyPortal.UpdateWithLevel(gametime, Level);
            }

        }

        public void Update(GameTime gametime)
        {
            // update scenery with time
            foreach (IScenery scenery in Sceneries)
            {
                scenery.Update(gametime);
            }
            // update background blocks
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {

                    IBlock block = Blocks[i].SingleLevel[j];
                    if (block != null)
                    {
                        block.Update(gametime);
                    }
                }
            }
            foreach (IItem item in Items)
            {
                item.Update(gametime);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Update(gametime);
            }
            foreach (FireHell fireHell in FireHells)
            {
                fireHell.Update(gametime);
            }
            foreach (IBoss boss in Bosses)
            {
                boss.Update(gametime);
            }
            foreach (Fireball fireball in Fireballs)
            {
                Fireballs.Remove(fireball);
                fireball.Update(gametime);
                if (fireball.IsRemove)
                {
                    RemoveFireballList.Add(fireball);
                }

            }
            foreach(FireShot fireShot in FireShots)
            {
                fireShot.Update(gametime);
            }
            
            foreach (ScoreObject score in Scores)
            {
                score.Update(gametime);
                if (score.IsRemoved)
                {
                    scoresRemoveList.Add(score);
                }
            }
            foreach (FlagStuff flagStuff in FlagStuffs)
            {
                flagStuff.Update(gametime);
            }
            RemoveFireballs();
            RemoveScoreObject();
            Mario.Update(gametime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // draw sceneries, blocks, items, and enemies
            foreach (IScenery scenery in Sceneries)
            {
                scenery.Draw(spriteBatch);
            }
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    IBlock block = Blocks[i].SingleLevel[j];
                    if (block != null)
                    {
                        block.Draw(spriteBatch);
                    }
                }
            }
            foreach (FireHell fireHell in FireHells)
            {
                fireHell.Draw(spriteBatch);
            }
            foreach (EnemyPortal enemyPortal in EnemyPortals)
            {
                enemyPortal.Draw(spriteBatch);
            }
            foreach (IItem item in Items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IBoss boss in Bosses)
            {
                boss.Draw(spriteBatch);
            }
            foreach (Fireball fireball in Fireballs)
            {
                fireball.Draw(spriteBatch);
            }
            foreach (FireShot fireShot in FireShots)
            {
                fireShot.Draw(spriteBatch);
            }
            foreach (ScoreObject score in Scores)
            {
                score.Draw(spriteBatch);
            }
            
            foreach (Castle castle in Castles)
            {
                castle.Draw(spriteBatch);
            }
            foreach (FlagStuff flagStuff in FlagStuffs)
            {
                flagStuff.Draw(spriteBatch);
            }
            Mario.Draw(spriteBatch);
        }

        public void RemoveFireballs()
        {
            foreach (Fireball fireball in RemoveFireballList)
            {
                Fireballs.Remove(fireball);
            }
            RemoveFireballList.Clear();
        }

        public void RemoveScoreObject()
        {
            foreach(ScoreObject score in scoresRemoveList)
            {
                Scores.Remove(score);
            }
            scoresRemoveList.Clear();
        }
    }
}
