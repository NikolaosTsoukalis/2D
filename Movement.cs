using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

internal class Movement
{
    private Vector2 currentPosition;
    private Vector2 newPosition;
    private float speed;
    private KeyboardState _ks;

    public Movement(Vector2 currentPosition, float speed)
    {
        this.currentPosition = currentPosition;
        this.speed = speed;

    }

    public Vector2 Update(GameTime gameTime)
    {
        float diagonalBuffer = (float)(1/Math.Sqrt(2));
        _ks = Keyboard.GetState();
        if (_ks.IsKeyDown(Keys.W))
        {
            newPosition.Y -= speed;
        }

        if (_ks.IsKeyDown(Keys.S))
        {
            newPosition.Y += speed;
        }

        if (_ks.IsKeyDown(Keys.A))
        {
            newPosition.X -= speed;
        }

        if (_ks.IsKeyDown(Keys.D))
        {
            newPosition.X += speed;
        }

        if(newPosition.LengthSquared() > speed * speed) // _speed*_speed = 1 with a _speed = 1
        {
        newPosition *= diagonalBuffer; // adjust for 2 directions pressed at same time.
        }
        
       return currentPosition += newPosition; // update position with an approximate, due to float limitations, length of speed vector
    }
    
}