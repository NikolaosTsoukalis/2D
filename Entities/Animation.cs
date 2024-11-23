using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _2D_RPG;
internal class Animation
{
    private readonly List<Rectangle> sourceRectangles = new();
    private int totalFrames;
    private int currentFrame;
    private float frameTime;
    private float frameTimeLeft;
    private Entity entity;

    public Animation(Entity entity)
    {
        if(Globals.AnimationData.TryGetValue(entity.Name, out var tuple))
        {
            entity.Texture = tuple.Item1;
            frameTime = (float) Convert.ToDouble(tuple.Item2[1]);
            totalFrames = Convert.ToInt32(tuple.Item2[0]);
            this.entity = entity;
            frameTimeLeft = frameTime;
            var frameWidth = entity.Texture.Width / totalFrames;
            var frameHeight = entity.Texture.Height;

            for(int i = 0; i < totalFrames; i++)
            {
                sourceRectangles.Add(new(i * frameWidth, 0, frameWidth,frameHeight));
            }
        }
    }

    public void Reset()
    {
        currentFrame = 0;
        frameTimeLeft = frameTime;
    }

    public void Update()
    {
        frameTimeLeft -= Globals.TotalSeconds;

        if(frameTimeLeft <= 0)
        {
            frameTimeLeft += frameTime;
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }

    public void Draw()
    {
        Globals.spriteBatch.Draw(entity.Texture, entity.Position, sourceRectangles[currentFrame], Color.White, 0,Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
    }
}