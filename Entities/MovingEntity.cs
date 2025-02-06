using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _2D_RPG;

public class MovingEntity : Entity
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

    public MovingEntity(string entityName, Texture2D texture,Vector2 position) : base(entityName,texture,position){}

    #endregion Constructors

    #region Functions

    public bool Move(Globals.Directions direction, bool isRunning)
    {
        Vector2 newPosition = new();
        switch(direction)
        {
            case Globals.Directions.Up:
                if(isRunning)
                {                   
                    newPosition.Y -= runningSpeed;
                }
                else
                    
                    newPosition.Y -= Speed;
                break;
            case Globals.Directions.UpLeft:
                if(isRunning)
                {                   
                    newPosition.Y -= runningSpeed;
                    newPosition.X -= runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else                
                    newPosition.Y -= Speed;
                    newPosition.X -= Speed;
                    newPosition = AdjustDPosition(newPosition);                    
                break;
            case Globals.Directions.UpRight:
                if(isRunning)
                {          
                    newPosition.Y -= runningSpeed;
                    newPosition.X += runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else     
                    newPosition.Y -= Speed;
                    newPosition.X += Speed;
                    newPosition = AdjustDPosition(newPosition);
                break;
            case Globals.Directions.Down:
                if(isRunning)
                {   
                    newPosition.Y += runningSpeed;
                }
                else
                    
                    newPosition.Y += Speed;
                break;
            case Globals.Directions.DownLeft:
                if(isRunning)
                {    
                    newPosition.Y += runningSpeed;
                    newPosition.X -= runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else  
                    newPosition.Y += Speed;
                    newPosition.X -= Speed;
                    newPosition = AdjustDPosition(newPosition);
                break;
            case Globals.Directions.DownRight:
                if(isRunning)
                {     
                    newPosition.Y += runningSpeed;
                    newPosition.X += runningSpeed;
                    newPosition = AdjustDPosition(newPosition);
                }
                else    
                    newPosition.Y += Speed;
                    newPosition.X += Speed;
                    newPosition = AdjustDPosition(newPosition);
                break;
            case Globals.Directions.Left:
                if(isRunning)
                {    
                    newPosition.X -= runningSpeed;
                }
                else
                    
                    newPosition.X -= Speed;
                break;
            case Globals.Directions.Right:
                if(isRunning)
                {    
                    newPosition.X += runningSpeed;
                }
                else    
                    newPosition.X += Speed;
                break;
        }

        if(!CollisionHandler.IsCollidingWithEntity(this) && !CollisionHandler.IsCollidingWithStructure(this))
        {
            Position += newPosition;
            return true;
        }
        else
        {
            //play Collision case. handleCollidingBehaviour
            //Position -= newPosition;
            return false;
        }
            
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

    #endregion Functions
}