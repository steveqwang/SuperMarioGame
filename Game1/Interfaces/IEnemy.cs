using Game1.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.PhysicalProperty;

namespace Game1.Interfaces
{
    public interface IEnemy:IObjects
    {
        IEnemyActionState State { get; set; }
        EnemyPhysicalProperty EnemyPhysics { get; set; }
        int Coefficient { get; set; }
        void CollidedWithMario(IPlayer mario,Direction direction);
        void CollidedWithShell(IEnemy shell);
        void CollideWithFireball(Fireball fireball);
        void CollidedWithBlock(IBlock block);
        void BeFlipped();
    }
}
