using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;

class MovingEntity : Entity
{
    #region values
    private float lspeed;
    public float speed
    {
        get{ return lspeed; }
        set{ lspeed = speed; }
    }

    private bool lIsRunning;
    public bool IsRunning
    {
        get{ return lIsRunning;}
        set{ lIsRunning = IsRunning;}
    }

    private bool lIsWalking;
    public bool IsWalking
    {
        get{ return lIsWalking;}
        set{ lIsRunning = IsWalking;}
    }

    #endregion values
    public MovingEntity(){}

    public virtual void Update(string parameter)
    {
        
    }

    public virtual void Move(string direction)
    {
        Vector2 newPosition = new();
        float diagonalBuffer = (float)(1/Math.Sqrt(2));
        if (direction == "W")
        {
            newPosition.Y -= speed;
            //IsWalking = true;
        }

        if (direction == "S")
        {
            newPosition.Y += speed;
            //IsWalking = true;
        }

        if (direction == "A")
        {
            newPosition.X -= speed;
            //IsWalking = true;
        }

        if (direction == "D")
        {
            newPosition.X += speed;
            //IsWalking = true;
        }

        if(newPosition.LengthSquared() > speed * speed) // _speed*_speed = 1 with a _speed = 1
        {
            newPosition *= diagonalBuffer; // adjust for 2 directions pressed at same time.
        }
        this.position += newPosition;
    }
}