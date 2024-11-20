using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

internal class AnimationHandler
{
    private readonly List<Rectangle> sourceRectangles = new();
    private readonly int totalFrames;
    private int currentFrame;
    private readonly float frameTime = 0.1f;
    private float frameTimeLeft;
    private bool active = true;

    private Texture2D Texture;

    private Entity entity;

    public AnimationHandler(Entity entity, int totalFrames)
    {
        this.entity = entity;
        Texture = entity.Texture;
        frameTimeLeft = this.frameTime;
        this.totalFrames = totalFrames;
        var frameWidth = Texture.Width / totalFrames;
        var frameHeight = Texture.Height;

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

    public void Draw()
    {
        Globals.spriteBatch.Draw(Texture, entity.Position, sourceRectangles[currentFrame], Color.White, 0,Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
    }
 
}