using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _2D_RPG;
internal class Animation : Sprite
{
    private readonly List<Rectangle> sourceRectangles = new();
    private readonly int totalFrames;
    private int currentFrame;
    private readonly float frameTime;
    private float frameTimeLeft;
    private bool active = true;

    public Animation(Sprite sprite, int framesX, float frameTime)
    {
        this.texture = sprite.texture;
        this.frameTime = frameTime;
        frameTimeLeft = this.frameTime;
        totalFrames = framesX;
        var frameWidth = texture.Width / framesX;
        var frameHeight = texture.Height;

        for(int i = 0; i < totalFrames; i++)
        {
            sourceRectangles.Add(new(i * frameWidth, 0, frameWidth,frameHeight));
        }
    }

    public void Animate(bool animate)
    {
        active = animate;
    }

    public void Reset()
    {
        currentFrame = 0;
        frameTimeLeft = frameTime;
    }

    public void Update()
    {
        if(!active)
        {
            return;
        }

        frameTimeLeft -= Globals.TotalSeconds;

        if(frameTimeLeft <= 0)
        {
            frameTimeLeft += frameTime;
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }

    public void Draw(Vector2 position)
    {
        Globals.spriteBatch.Draw(texture, position, sourceRectangles[currentFrame], Color.White, 0,Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
    }
}