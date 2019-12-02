using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Collisions;
using Game1.Utility;

namespace Game1.Camera
{
    public class Camera
    {
        private Game game;
        private Viewport viewport;
        public IWorld world;
        public Vector2 ScreenPosition { get; set; }
        public Vector2 CameraPosition = new Vector2(Util.Instance.Vector_initial_i, Util.Instance.Vector_initial_j);
        public Matrix viewMatrix;
        
        public Camera(Viewport viewport, Game game, IWorld world)
        {
            this.game = game;
            this.viewport = viewport;
            this.world = world;
        }
        

        public Matrix GetMatrixView()
        {

            if(world.Mario.Location.X <= viewport.Width / 2)
            {
                viewMatrix = Matrix.CreateTranslation(new Vector3(-viewport.Width / 2, viewport.Height / 2 - Util.Instance.ViewMatrix_j_shift, Util.Instance.ViewMatrix_k))*
                    Matrix.CreateTranslation(new Vector3(-viewport.Width * Util.Instance.Transition_width_change, viewport.Height * Util.Instance.Transition_width_change, Util.Instance.ViewMatrix_k));
            }else
            {
                viewMatrix = Matrix.CreateTranslation(new Vector3(world.Mario.Location.X, viewport.Height / 2 - Util.Instance.ViewMatrix_j_shift, Util.Instance.ViewMatrix_k)) *
                    Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, Util.Instance.ViewMatrix_k));
            }

            return viewMatrix;
        }

    }
}
