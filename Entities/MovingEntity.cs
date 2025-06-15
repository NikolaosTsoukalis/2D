using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2D_RPG;

public class MovingEntity : Entity
{
    #region Values
    protected int Speed;
    protected int RunningSpeed;

    private Vector2 newPosition;
    private Vector2 currentPosition;

    #endregion Values
    
    #region Constructors
    public MovingEntity(){}

    public MovingEntity(string entityName, Texture2D texture,Vector2 position) : base(entityName,texture,position)
    {
        //this.AssignAttributes();
    }

    #endregion Constructors

    #region Functions

    public override void AssignAttributes()
    { 
        try
        {
            this.ModifyAttribute(GlobalEnumarations.AttributeTypes.Speed,Globals.EntityDataHandler.GetSpecificEntityAttributeValue(this.Name,GlobalEnumarations.AttributeTypes.Speed));
            this.ModifyAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed,Globals.EntityDataHandler.GetSpecificEntityAttributeValue(this.Name,GlobalEnumarations.AttributeTypes.RunningSpeed));
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
        //base.AssignAttributes();
    }

    public bool Move(GlobalEnumarations.Directions direction, bool isRunning)
    {
        this.newPosition = new();
        this.currentPosition = Position;

        switch(direction)
        {
            case GlobalEnumarations.Directions.Up:
                if(isRunning)
                {                   
                    newPosition.Y -= this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                }
                else    
                    newPosition.Y -= this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                break;
            case GlobalEnumarations.Directions.UpLeft:
                if(isRunning)
                {                   
                    newPosition.Y -= this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition.X -= this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else                
                    newPosition.Y -= this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition.X -= this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);                    
                break;
            case GlobalEnumarations.Directions.UpRight:
                if(isRunning)
                {          
                    newPosition.Y -= this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition.X += this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else     
                    newPosition.Y -= this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition.X += this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                break;
            case GlobalEnumarations.Directions.Down:
                if(isRunning)
                {   
                    newPosition.Y += this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                }
                else
                    
                    newPosition.Y += this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                break;
            case GlobalEnumarations.Directions.DownLeft:
                if(isRunning)
                {    
                    newPosition.Y += this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition.X -= this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else  
                    newPosition.Y += this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition.X -= this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                break;
            case GlobalEnumarations.Directions.DownRight:
                if(isRunning)
                {     
                    newPosition.Y += this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition.X += this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else    
                    newPosition.Y += this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition.X += this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                break;
            case GlobalEnumarations.Directions.Left:
                if(isRunning)
                {    
                    newPosition.X -= this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                }
                else
                    newPosition.X -= this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                break;
            case GlobalEnumarations.Directions.Right:
                if(isRunning)
                {    
                    newPosition.X += this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed);
                }
                else    
                    newPosition.X += this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed);
                break;
        }
        //this.pastPosition = Position;
        this.Position += newPosition;
        if(Globals.CollisionHandler.IsCollidingWithEntity(this) || Globals.CollisionHandler.IsCollidingWithTile(this))
        {
            this.Position = currentPosition;
            return false;
        }
        return true;        
    }
 
    public Vector2 AdjustDiagonalPosition(Vector2 newPosition)
    {
        float diagonalBuffer = (float)(1/Math.Sqrt(2));
        if(newPosition.LengthSquared() > this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed) * this.GetAttribute(GlobalEnumarations.AttributeTypes.Speed) || newPosition.LengthSquared() > this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed) * this.GetAttribute(GlobalEnumarations.AttributeTypes.RunningSpeed)) // _speed*_speed = 1 with a _speed = 1
        {
            newPosition *= diagonalBuffer; // adjust for 2 directions pressed at same time.
        }
        return newPosition;
    }

    #endregion Functions
}