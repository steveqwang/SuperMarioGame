using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;

namespace Game1.Library
{
    public class BlockArray
    {
        public IList<IBlock> SingleLevel { get; private set; }

        public BlockArray(int Height)
        {
            SingleLevel= new List<IBlock>(Height);
            for (int i = 0; i < Height; i++)
            {
                SingleLevel.Add(null);
            }
        }
    }
}
