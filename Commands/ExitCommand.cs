using Microsoft.Xna.Framework;

namespace _2D_RPG;

class ExitCommand : Command 
{

    public ExitCommand(){}
    public override void Execute(Game game)
    {
        game.Exit();
    }    
}