using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;

public abstract class LayoutBase
{

    protected Rectangle BaseBounds { get; set; }
    protected Texture2D boundingTexture{ get; set; }

    public LayoutBase(List<ComponentBase> components, Texture2D boundingTexture)
    {
        AssignBoundingTextureVariables(boundingTexture);
    }

    public void AssignBoundingTextureVariables(Texture2D boundingTexture)
    {
        if (boundingTexture != null)
        {
            this.boundingTexture = boundingTexture;

            float screenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
            float screenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

            int textureWidth = boundingTexture.Bounds.Y;
            int textureHeight = boundingTexture.Bounds.X;

            Vector2 boundsStartingPoint = new Vector2(screenWidth / 2 + (screenWidth / 4), screenHeight / 2 - (screenHeight / 4));
            //Set position of bounding texture and the bounds themselves.
            //this is for the middle of the screen.
            this.BaseBounds = new Rectangle((int)boundsStartingPoint.X, (int)boundsStartingPoint.Y, textureWidth, textureHeight);
        }
        else
        {
            this.BaseBounds = Rectangle.Empty;
            return;
        }
    }

    protected bool SetComponentBounds(ComponentBase component)
    {
        try
        {
            Texture2D currentTexture = component.TextureHandler.CurrentTexture;
            Vector2 currentPosition = component.Position;
            component.Bounds = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, currentTexture.Width, currentTexture.Height);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return true;
        }
    }

    public virtual void AssignComponentPositions(List<ComponentBase> components, Rectangle bounds) { }

    public virtual void AssignComponentTextures( List<ComponentBase> components) {}

}