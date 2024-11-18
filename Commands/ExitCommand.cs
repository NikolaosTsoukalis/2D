using System;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;

class ExitCommand : Command 
{

    public ExitCommand(){}
    public override void Execute(Game game)
    {
        game.Exit();
    }    
}