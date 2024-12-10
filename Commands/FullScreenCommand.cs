using _2D_RPG;
using Microsoft.Xna.Framework;

class FullScreenCommand : Command 
{

    public FullScreenCommand(){}
    public override void Execute(Game game)
    {
        Globals._graphics.ToggleFullScreen();
    }    
}