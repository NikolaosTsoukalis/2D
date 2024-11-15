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
    public virtual void execute(Entity entity)
    {
        Move(entity);
    }

    public void Move(Entity entity)
    {
        private Vector2 newPosition = new Vector2();
        private Vector2 currentPosition = entity.location;
        float diagonalBuffer = (float)(1/Math.Sqrt(2));
    }
    
          //return currentPosition += newPosition;
    
}

