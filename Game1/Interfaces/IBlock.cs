using Microsoft.Xna.Framework;
using Game1.Collisions;

namespace Game1.Interfaces
{
    public interface IBlock : IObjects
    {
        
        void CollisionWithMario (IWorld level,IPlayer mario,Direction direction);
        void CollisionWithEnemy(IEnemy enemy, Direction direction);
        void CollisionWithBoss(IBoss boss, Direction direction);
        void CollisionWithItem(IItem item, Direction direction);
        void CollisionWithGameObject(Fireball fireball, Direction direction);
    }
}
