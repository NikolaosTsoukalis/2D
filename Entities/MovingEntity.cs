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

    #endregion Values
    
    #region Constructors
    public MovingEntity(){}

    public MovingEntity(string entityName, Texture2D texture,Vector2 position) : base(entityName,texture,position)
    {
         
    }

    #endregion Constructors

    #region Functions

    public override void Move(string direction)
    {
        Vector2 newPosition = new();
        float diagonalBuffer = (float)(1/Math.Sqrt(2));
        if (direction == "W")
        {
            newPosition.Y -= Speed;
            //IsWalking = true;
        }

        if (direction == "S")
        {
            newPosition.Y += Speed;
            //IsWalking = true;
        }

        if (direction == "A")
        {
            newPosition.X -= Speed;
            //IsWalking = true;
        }

        if (direction == "D")
        {
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