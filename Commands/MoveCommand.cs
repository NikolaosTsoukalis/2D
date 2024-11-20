using System;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;

class MoveCommand : Command 
{
    private string direction;

    public MoveCommand(string direction)
    {
        this.direction = direction;
    }
    public override void Execute(Entity entity)
    {
        entity.Move(direction);
    }

    
}

