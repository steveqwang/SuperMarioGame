using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1.Interfaces
{
     public interface IMarioActionState: IActionState
    {
        void Up();
        void Down();
        void Right();
        void Left();
        void Idle();

    }
}