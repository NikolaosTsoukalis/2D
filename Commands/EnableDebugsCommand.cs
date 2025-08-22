namespace _2D_RPG;

class EnableDebugsCommand : Command 
{
    public EnableDebugsCommand() : base(CommandTypes.EnableDebugsCommand){}
    public override void Execute()
    {
        if(Main.currentGameState.GetType() == typeof(GameState))
        {
            Globals.enableDebugs = !Globals.enableDebugs;
        }
    }
}    