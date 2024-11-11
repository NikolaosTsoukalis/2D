using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


internal class MovingSprite : Sprite
{
    private float speed;
    private int imageIndex;
    private string direction;
    public MovingSprite(Texture2D texture, Vector2 position, float speed, string direction) : base(texture, position)
    { 
        this.texture = texture;
        this.position = position;
        this.speed = speed;
        this.direction = direction;
    }

    public override void Update(string direction)
    {
        float cos45 = (float)Math.Cos(45);
        float sin45 = (float)Math.Sin(45);
        float cos135 = (float)Math.Cos(135);
        float sin135 = (float)Math.Sin(135);
        float cos225 = (float)Math.Cos(225);
        float sin225 = (float)Math.Sin(225);
        float cos315 = (float)Math.Cos(315);
        float sin315 = (float)Math.Sin(315);

        switch(direction)
        {
            case "UP":
                position.Y -= speed;
                break;
            case "UPRIGHT":
                position.X += speed * cos45;
                position.Y -= speed * sin45;
                break;
            case "RIGHT":
                position.X += speed;
                break;
            case "RIGHTDOWN":
                position.X += speed * cos315;
                position.Y += speed * sin315;
                break;
            case "DOWN":
                position.Y += speed;
                break;
            case "DOWNLEFT":
                position.Y += speed * sin225;
                position.X += speed * cos225;
                break;
            case "LEFT":
                position.X -= speed;
                break;
            case "LEFTUP":
                position.Y -= speed * sin135;
                position.X += speed * cos135;
                break;
        };
        
        base.Update(direction);
    }
}