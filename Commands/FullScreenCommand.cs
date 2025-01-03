using Microsoft.Xna.Framework;

namespace _2D_RPG;

class FullScreenCommand : Command 
{

    public FullScreenCommand(){}
    public override void Execute(Game game)
    {
        Globals._graphics.ToggleFullScreen();
    }    
}