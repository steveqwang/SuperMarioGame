using System;
using Game1.Collisions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.PhysicalProperty;

namespace Game1.Interfaces
{
    public interface IItem:IObjects
    {
        ItemPhysicalProperty ItemPhysics { get; set; }
        bool HaveCollision { get; set; }
        void CollidedWithMario(IPlayer mario); 
    }
}
