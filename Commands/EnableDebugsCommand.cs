namespace _2D_RPG;

class EnableDebugsCommand : Command 
{
    public EnableDebugsCommand() : base(CommandTypes.EnableDebugsCommand){}
    public override void Execute(Main main)
    {
        if(main.currentGameState.GetType() == typeof(GameState))
        {
            Globals.enableDebugs = !Globals.enableDebugs;
        }
    }
}    