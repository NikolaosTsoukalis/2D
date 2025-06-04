using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;

public abstract class LayoutBase
{

    protected Rectangle Bounds;
    protected Texture2D boundingTexture;

    public LayoutBase(List<Component> components, Texture2D boundingTexture)
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
            this.Bounds = new Rectangle((int)boundsStartingPoint.X, (int)boundsStartingPoint.Y, textureWidth, textureHeight);
        }
        else
        {
            this.Bounds = Rectangle.Empty;
            return;
        }
    }

    public Rectangle GetBaseTextureRectangle()
    {
        return Bounds;
    }

    public Texture2D GetBaseTexture()
    {
        return boundingTexture;
    }
    
    public virtual void AssignComponentPositions(List<Component> components, Rectangle bounds) { }


}