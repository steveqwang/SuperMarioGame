using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Interfaces
{
    public interface IGameObject : IObjects
    {
        Vector2 Speed { get; set; }
        bool IsRemove { get; set; }
    }
}
