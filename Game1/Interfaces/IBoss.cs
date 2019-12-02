using Game1.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.PhysicalProperty;
using System.Collections;
using Game1.GameTool;

namespace Game1.Interfaces
{
    public interface IBoss : IObjects
    {
        IEnemyActionState State { get; set; }
        BossPhysicalProperty BossPhysics { get; set; }
        bool IsControlled { get; set; }
        bool IsActivate { get; set; }
        int Life { get; set; }
        void CollidedWithMario(IPlayer mario, Direction direction);
        void CollidedWithShell(IEnemy shell);
        void CollideWithFireball(Fireball fireball);
        void TakeDamage();
        void BeDead();
        void Jump();
        IList<FireShot> fireShots { get; }

    }
}
