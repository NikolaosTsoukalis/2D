using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;

public abstract class LayoutBase
{

    public Rectangle BaseBounds { get; private set; }
    public Texture2D BoundingTexture { get; private set; }

    public Menu Menu { get; private set; }

    public LayoutBase(Menu menu, Texture2D boundingTexture)
    {
        this.Menu = menu;
        SetBounds(boundingTexture);
    }

    public virtual void AssignComponentPositions(bool resetFlag) { }

    public void SetBounds(Texture2D boundingTexture)
    {
        //The Base Bounds will be based on if there is a texture or not. If not the Bounds are the Screen Bounds.
        if (boundingTexture != null)
        {
            this.BoundingTexture = boundingTexture;


            Vector2 baseBoundsPosition = AlignComponentWithBoundCenter(boundingTexture, Menu.ScreenDimensions.X, Menu.ScreenDimensions.Y);
            this.BaseBounds = new Rectangle((int)baseBoundsPosition.X, (int)baseBoundsPosition.Y, boundingTexture.Width, boundingTexture.Height);
        }
        else
        {
            this.BaseBounds = new Rectangle(0, 0, (int)Menu.ScreenDimensions.X, (int)Menu.ScreenDimensions.Y);
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

    public Vector2 AlignComponentWithBoundCenter(Texture2D componentTexture, float boundingWidth, float boundingHeight)
    {
        if (componentTexture != null)
        {
            int TextureHeight = componentTexture.Height;
            int TextureWidth = componentTexture.Width;
            Vector2 centerOfBounds = new Vector2(boundingWidth / 2f, boundingHeight / 2f);
            Vector2 centerOfTexture = new Vector2(TextureWidth / 2f, TextureHeight / 2f);

            return centerOfBounds - centerOfTexture;
        }
        else
        {
            Vector2 centerOfBounds = new Vector2(boundingWidth / 2f, boundingHeight / 2f);

            return centerOfBounds;
        }
    }
}