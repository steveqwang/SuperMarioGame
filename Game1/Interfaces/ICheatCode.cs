using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.Interfaces
{
    public interface ICheatCode
    {  Queue<String> inputString { get; set; }
        void Update(GameTime gameTime);
    }
}
