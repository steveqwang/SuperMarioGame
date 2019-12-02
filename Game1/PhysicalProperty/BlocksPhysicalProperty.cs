using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.Utility;

namespace Game1.PhysicalProperty
{
    public class BlocksPhysicalProperty
    {
        public Vector2 Velocity { get; set; }
        public Vector2 Accerlation { get; set; }
        public bool Locked { get; set; }
        private IBlock Block;
        private Vector2 OriginalLocation { get; }


        public BlocksPhysicalProperty(IBlock block)
        {
            Velocity = new Vector2();
            Accerlation = new Vector2();
            Block = block;
             Locked = false;
            OriginalLocation = block.Location;
        }

        public void BlockJump()
        {
            Locked = false;
            Velocity = new Vector2(0f, -40);
            Accerlation = new Vector2(0, 256);
        }

        private void MakeIdle() {
            Locked = true;
            Velocity = new Vector2();
            Accerlation = new Vector2();
            Block.Location = OriginalLocation;
        }

        public void Update(GameTime gameTime) {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!Locked)
            {
                Velocity += Accerlation * deltaTime;
                Block.Location += Velocity * deltaTime;
            }
            if (Block.Location.Y >= OriginalLocation.Y) {
                MakeIdle();
            }
        }
    }
}
