using Microsoft.Xna.Framework;

namespace _2D_RPG;

class EnableDebugsCommand : Command 
{
    public EnableDebugsCommand() : base(CommandTypes.EnableDebugsCommand){}
    public override void Execute(Game game)
    {
        Globals.enableDebugs = !Globals.enableDebugs;
    }
}    