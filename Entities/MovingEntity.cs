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
         Speed = 3;
         RunningSpeed = 4;
    }

    #endregion Constructors

    #region Functions

    public void Move(string direction, bool isRunning)
    {
        Vector2 newPosition = new();
        switch(direction)
        {
            case "W":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.Y -= runningSpeed;
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.Y -= Speed;
                break;
            case "WA":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.Y -= runningSpeed;
                    newPosition.X -= runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.Y -= Speed;
                    newPosition.X -= Speed;
                    newPosition = AdjustDPosition(newPosition);                    
                break;
            case "WD":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.Y -= runningSpeed;
                    newPosition.X += runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.Y -= Speed;
                    newPosition.X += Speed;
                    newPosition = AdjustDPosition(newPosition);
                break;
            case "S":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.Y += runningSpeed;
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.Y += Speed;
                break;
            case "SA":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.Y += runningSpeed;
                    newPosition.X -= runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.Y += Speed;
                    newPosition.X -= Speed;
                    newPosition = AdjustDPosition(newPosition);
                break;
            case "SD":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.Y += runningSpeed;
                    newPosition.X += runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.Y += Speed;
                    newPosition.X += Speed;
                    newPosition = AdjustDPosition(newPosition);
                break;
            case "A":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.X -= runningSpeed;
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.X -= Speed;
                break;
            case "D":
                if(isRunning)
                {
                    ActionIdentifier = "Run";
                    newPosition.X += runningSpeed;
                }
                else
                    ActionIdentifier = "Walk";
                    newPosition.X += Speed;
                break;
        }
        Position += newPosition;
    }
 
    public Vector2 AdjustDPosition(Vector2 newPosition)
    {
        float diagonalBuffer = (float)(1/Math.Sqrt(2));
        if(newPosition.LengthSquared() > Speed * Speed || newPosition.LengthSquared() > runningSpeed * runningSpeed) // _speed*_speed = 1 with a _speed = 1
        {
            newPosition *= diagonalBuffer; // adjust for 2 directions pressed at same time.
        }
        return newPosition;
    }
    public virtual void Update() 
    {
        
    }

    #endregion Functions
}