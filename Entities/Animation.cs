using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;
internal class Animation
{
    private readonly List<Rectangle> sourceRectangles = new();
    private int totalFrames;
    private int currentFrame;
    private float frameTime;
    private float frameTimeLeft;
    private Entity entity;

    public Entity Entity 
    {
        get{return entity;}
        set{entity = value;}
    }

    private string actionIdentifier;

    public string ActionIdentifier 
    {
        get{return actionIdentifier;}
        set{actionIdentifier = value;}
    }
    public Animation(Entity entity, string identifier)
    {
        if(Globals.PlayerAnimationData.TryGetValue(identifier, out var tuple))
        {
            entity.Texture = tuple.Item1;
            frameTime = (float) Convert.ToDouble(tuple.Item2[1]);
            totalFrames = Convert.ToInt32(tuple.Item2[0]);
            frameTimeLeft = frameTime;
            var frameWidth = entity.Texture.Width / totalFrames;
            var frameHeight = entity.Texture.Height;
            ActionIdentifier = entity.ActionIdentifier;
            Entity = entity;

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

        if(string.IsNullOrEmpty(entity.Direction))
        {
            if(frameTimeLeft <= 0)
            {
                frameTimeLeft += frameTime;
                currentFrame = (currentFrame + 1) % totalFrames;
            }
        }
        else
        {
            if(frameTimeLeft <= 0)
            {
                frameTimeLeft += frameTime;
                int currentStartingFrame = 0;
                int totalDirectionalFrames = totalFrames / 8;
                switch(entity.Direction)
                {
                    case "S":
                        currentStartingFrame = 0;
                        break;
                    case "SD":
                        currentStartingFrame = totalDirectionalFrames;
                        break;
                    case "D":
                        currentStartingFrame = totalDirectionalFrames*2;
                        break;
                    case "WD":
                        currentStartingFrame = totalDirectionalFrames*3;
                        break;
                    case "W":
                        currentStartingFrame = totalDirectionalFrames*4;
                        break;
                    case "WA":
                        currentStartingFrame = totalDirectionalFrames*5;
                        break;
                    case "A":
                        currentStartingFrame = totalDirectionalFrames*6;
                        break;
                    case "SA":
                        currentStartingFrame = totalDirectionalFrames*7;
                        break;
                }
                if(currentFrame == totalFrames-1 || currentFrame < currentStartingFrame || currentFrame >= currentStartingFrame + totalDirectionalFrames - 1)
                {
                    currentFrame = currentStartingFrame;
                }
                else
                    currentFrame = (currentFrame + 1) % totalFrames;
                //currentFrame = (currentFrame + 1) % totalFrames + currentStartingFrame;
            }
        }
    }

    public void Draw()
    {
        Globals.spriteBatch.Draw(entity.Texture, entity.Position, sourceRectangles[currentFrame], Color.White, 0,Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
    }
}