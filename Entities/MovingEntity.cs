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
            this.ModifyAttribute(Globals.AttributeTypes.Speed,Globals.EntityDataHandler.GetSpecificEntityAttributeValue(this.Name,Globals.AttributeTypes.Speed));
            this.ModifyAttribute(Globals.AttributeTypes.RunningSpeed,Globals.EntityDataHandler.GetSpecificEntityAttributeValue(this.Name,Globals.AttributeTypes.RunningSpeed));
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
        //base.AssignAttributes();
    }

    public bool Move(Globals.Directions direction, bool isRunning)
    {
        this.newPosition = new();
        this.currentPosition = Position;

        switch(direction)
        {
            case Globals.Directions.Up:
                if(isRunning)
                {                   
                    newPosition.Y -= this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                }
                else    
                    newPosition.Y -= this.GetAttribute(Globals.AttributeTypes.Speed);
                break;
            case Globals.Directions.UpLeft:
                if(isRunning)
                {                   
                    newPosition.Y -= this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition.X -= this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else                
                    newPosition.Y -= this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition.X -= this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);                    
                break;
            case Globals.Directions.UpRight:
                if(isRunning)
                {          
                    newPosition.Y -= this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition.X += this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else     
                    newPosition.Y -= this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition.X += this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                break;
            case Globals.Directions.Down:
                if(isRunning)
                {   
                    newPosition.Y += this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                }
                else
                    
                    newPosition.Y += this.GetAttribute(Globals.AttributeTypes.Speed);
                break;
            case Globals.Directions.DownLeft:
                if(isRunning)
                {    
                    newPosition.Y += this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition.X -= this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else  
                    newPosition.Y += this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition.X -= this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                break;
            case Globals.Directions.DownRight:
                if(isRunning)
                {     
                    newPosition.Y += this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition.X += this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                }
                else    
                    newPosition.Y += this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition.X += this.GetAttribute(Globals.AttributeTypes.Speed);
                    newPosition = AdjustDiagonalPosition(newPosition);
                break;
            case Globals.Directions.Left:
                if(isRunning)
                {    
                    newPosition.X -= this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                }
                else
                    newPosition.X -= this.GetAttribute(Globals.AttributeTypes.Speed);
                break;
            case Globals.Directions.Right:
                if(isRunning)
                {    
                    newPosition.X += this.GetAttribute(Globals.AttributeTypes.RunningSpeed);
                }
                else    
                    newPosition.X += this.GetAttribute(Globals.AttributeTypes.Speed);
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
        if(newPosition.LengthSquared() > this.GetAttribute(Globals.AttributeTypes.Speed) * this.GetAttribute(Globals.AttributeTypes.Speed) || newPosition.LengthSquared() > this.GetAttribute(Globals.AttributeTypes.RunningSpeed) * this.GetAttribute(Globals.AttributeTypes.RunningSpeed)) // _speed*_speed = 1 with a _speed = 1
        {
            newPosition *= diagonalBuffer; // adjust for 2 directions pressed at same time.
        }
        return newPosition;
    }

    #endregion Functions
}