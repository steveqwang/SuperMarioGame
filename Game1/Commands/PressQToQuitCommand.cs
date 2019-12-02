using Game1.Commands;

namespace Game1.Commands
{
    class PressQToQuitCommand : Interfaces.ICommand
    {
        private OurMarioGame GameClass;


        public void Execute()
        {
            GameClass.Exit();
        }
        public PressQToQuitCommand(OurMarioGame CurrentGameClass)
        {
            this.GameClass = CurrentGameClass;
        }

    }
}

