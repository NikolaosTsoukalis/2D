using Microsoft.Xna.Framework;

class ExitCommand : Command 
{

    public ExitCommand(){}
    public override void Execute(Game game)
    {
        game.Exit();
    }    
}