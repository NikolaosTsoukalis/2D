using Microsoft.Xna.Framework;

namespace _2D_RPG;

class EnableDebugsCommand : Command 
{

    public EnableDebugsCommand(){}
    public override void Execute(Game game)
    {
        Globals.enableDebugsCommand = !Globals.enableDebugsCommand;
    }
}    