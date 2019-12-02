using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;

namespace Game1.Commands
{
    class MouseCommand :ICommand
    {
        private OurMarioGame game;

        public MouseCommand(OurMarioGame game) {
            this.game = game;
        }

        public void Execute() {
            game.UseMouseController = !game.UseMouseController;
               }
    }
}
