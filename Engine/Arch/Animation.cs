using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Animation
{
    #region Values

    private readonly List<Rectangle> sourceRectangles = new();
    private int totalFrames;
    public int TotalFrames
    {
        get{return totalFrames;}
    }
    private int currentFrame;
    private float frameTime;
    private float frameTimeLeft;
    private Entity entity;

    public Entity Entity 
    {
        get{return entity;}
        set{entity = value;}
    }

    private AnimationDataHandler.AnimationIdentifier animationIdentifier;

    public AnimationDataHandler.AnimationIdentifier AnimationIdentifier 
    {
        get{return animationIdentifier;}
        set{animationIdentifier = value;}
    }

    #endregion Values

    #region Constructors
    public Animation(Entity entity, AnimationDataHandler.AnimationIdentifier identifier)
    {
        if(Globals.AnimationDataHandler.GetAnimationDictionary(entity.Name.ToString()).TryGetValue(identifier, out var tuple))
        {
            entity.Texture = tuple.Item1;
            frameTime = (float) Convert.ToDouble(tuple.Item2[1]);
            totalFrames = Convert.ToInt32(tuple.Item2[0]);
            frameTimeLeft = 0;
            var frameWidth = entity.Texture.Width / totalFrames;
            var frameHeight = entity.Texture.Height;
            AnimationIdentifier = entity.AnimationIdentifier;
            Entity = entity;

            for(int i = 0; i < totalFrames; i++)
            {
                sourceRectangles.Add(new(i * frameWidth, 0, frameWidth,frameHeight));
            }
        }
    }

    #endregion Constructors

    #region Functions

    public void Reset()
    {
        currentFrame = 0;
        frameTimeLeft = frameTime;
    }

    public void Update()
    {
        try
        {
            frameTimeLeft -= Globals.TotalSeconds;

            if(string.IsNullOrEmpty(entity.Direction.ToString()))
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
                        case Globals.Directions.Down:
                            currentStartingFrame = 0;
                            break;
                        case Globals.Directions.DownRight:
                            currentStartingFrame = totalDirectionalFrames;
                            break;
                        case Globals.Directions.Right:
                            currentStartingFrame = totalDirectionalFrames*2;
                            break;
                        case Globals.Directions.UpRight:
                            currentStartingFrame = totalDirectionalFrames*3;
                            break;
                        case Globals.Directions.Up:
                            currentStartingFrame = totalDirectionalFrames*4;
                            break;
                        case Globals.Directions.UpLeft:
                            currentStartingFrame = totalDirectionalFrames*5;
                            break;
                        case Globals.Directions.Left:
                            currentStartingFrame = totalDirectionalFrames*6;
                            break;
                        case Globals.Directions.DownLeft:
                            currentStartingFrame = totalDirectionalFrames*7;
                            break;
                    }
                    if(currentFrame == totalFrames - 1 || currentFrame < currentStartingFrame || currentFrame >= currentStartingFrame + totalDirectionalFrames - 1)
                    {
                        currentFrame = currentStartingFrame;
                    }
                    else
                    {
                        currentFrame = (currentFrame + 1) % totalFrames;
                    }
                }
            }
        }
        catch(Exception e)
        {
            MessageBox.Show("Error",e.ToString(),new List<string> {"OK"});
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(entity.Texture, entity.Position, sourceRectangles[currentFrame], Color.White, 0,Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
    }

    #endregion Functions
}