using _2D_RPG;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

class MovingEntity : Entity
{
    #region Values
    private float speed;
    public float Speed 
    {
        get{ return speed;}
        set{speed = value;}
    }
    private float runningSpeed;
    public float RunningSpeed 
    {
        get{ return runningSpeed;}
        set{runningSpeed = value;}
    }

    #endregion Values
    
    #region Constructors
    public MovingEntity(){}

    public MovingEntity(string entityName, Texture2D texture,Vector2 position) : base(entityName,texture,position)
    {
         
    }

    #endregion Constructors

    #region Functions

    public override void Move(string direction, bool isRunning)
    {
        Vector2 newPosition = new();
        float diagonalBuffer = (float)(1/Math.Sqrt(2));
        if (direction == "W")
        {
            if(isRunning)
            {
                newPosition.Y -= runningSpeed;
            }
            else
                newPosition.Y -= Speed;
            
        }

        if (direction == "S")
        {
            if(isRunning)
            {
                newPosition.Y += runningSpeed;
            }
            else
                newPosition.Y += Speed;
        }

        if (direction == "A")
        {
            if(isRunning)
            {
                newPosition.X -= runningSpeed;
            }
            else
                newPosition.X -= Speed;

        }

        if (direction == "D")
        {
            if(isRunning)
            {
                newPosition.X += runningSpeed;
            }
            else
                newPosition.X += Speed;
            //IsWalking = true;
        }

        if(newPosition.LengthSquared() > Speed * Speed) // _speed*_speed = 1 with a _speed = 1
        {
            newPosition *= diagonalBuffer; // adjust for 2 directions pressed at same time.
        }
        Position += newPosition;
    }
 
    public virtual void Update() 
    {

    }

    #endregion Functions
}