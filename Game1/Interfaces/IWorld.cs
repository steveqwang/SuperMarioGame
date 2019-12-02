using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Library;
using Game1.GameTool;
using Game1.Score;
using Game1.Items;

namespace Game1.Interfaces
{
    public interface IWorld
    {
        int Width { get; }
        int Height { get; }
        IPlayer Mario { get; set; }
        
        IList<BlockArray> Blocks { get; }
        IList<IEnemy> Enemies { get; }
        IList<IBoss> Bosses { get; }
        IList<IItem> Items { get; }
        IList<Fireball> Fireballs { get; }
        IList<FireShot> FireShots { get; set; }
        IList<IScenery> Sceneries { get; }
        IList<Castle> Castles { get; }
        IList<FlagStuff> FlagStuffs { get; }
        IList<ScoreObject> Scores { get; }
        IList<EnemyPortal> EnemyPortals { get; }
        IList<FireHell> FireHells { get; }

        void Update(GameTime gametime);

        void UpdatePortal(GameTime gametime, IWorld Level);
        void Draw(SpriteBatch spriteBatch);

    }
}
