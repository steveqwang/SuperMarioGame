using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.Controllers;

namespace Game1.Controllers
{ 

    class MouseController : IController
{
   OurMarioGame Game;

    public MouseController(OurMarioGame game){
        Game = game;
    }
    public void Update(GameTime gametime) {
            MouseState state = Mouse.GetState();
            Game.World.Mario.Location = new Vector2(state.X, state.Y);

    }
    }
}