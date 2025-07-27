using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;

public abstract class LayoutBase
{

    public Rectangle BaseBounds { get; private set; }
    public Texture2D BoundingTexture { get; private set; }

    public Vector2 BoundCenter { get; private set; }

    public Menu Menu { get; private set; }

    public LayoutBase(Menu menu, Texture2D boundingTexture)
    {
        this.Menu = menu;
        SanitizeComponents(this.Menu.Components);
        SetBaseBounds(boundingTexture);
    }

    public virtual void AssignComponentPositions(bool resetFlag) { }

    public void SetBaseBounds(Texture2D boundingTexture)
    {
        //The Base Bounds will be based on if there is a texture or not. If not the Bounds are the Screen Bounds.
        if (boundingTexture != null)
        {
            this.BoundingTexture = boundingTexture;

            Vector2 baseBoundsPosition = AlignComponentWithBoundCenter(boundingTexture, Menu.ScreenDimensions.X, Menu.ScreenDimensions.Y);
            this.BaseBounds = new Rectangle((int)baseBoundsPosition.X, (int)baseBoundsPosition.Y, boundingTexture.Width, boundingTexture.Height);
            this.BoundCenter = new Vector2(this.BaseBounds.Width / 2f, this.BaseBounds.Height / 2f);
        }
        else
        {
            this.BaseBounds = new Rectangle(0, 0, (int)Menu.ScreenDimensions.X, (int)Menu.ScreenDimensions.Y);
            this.BoundCenter = new Vector2((int)Menu.ScreenDimensions.X / 2f, (int)Menu.ScreenDimensions.Y / 2f);
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

    public bool SetTextBoxPosition(ComponentBase component)
    {
        Type type = component.GetType();
        PropertyInfo field = type.GetProperty("TextBox", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (field != null)
        {
            object TextBox = field.GetValue(component);
            if (TextBox != null)
            {
                MethodInfo SetPosition = TextBox.GetType().GetMethod("SetPosition");

                if (SetPosition != null)
                {
                    SetPosition.Invoke(TextBox, new object[] { Vector2.Zero });
                    return true;
                }
            }
        }
        return false;
    }

    public bool SetDebugButtonPosition(ComponentBase component)
    {
        try
        {
            int xPoint = this.BaseBounds.Width - component.TextureHandler.CurrentTexture.Width;
            int yPoint = this.BaseBounds.Height - component.TextureHandler.CurrentTexture.Height;
            component.Position = new Vector2(xPoint, yPoint);
            SetComponentBounds(component);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return false;
        }
    }
    
    private void SanitizeComponents(List<ComponentBase> components)
    {
        foreach(ComponentBase component in  components)
        {
            component.SanitizeHandlers();    
        }
    }
}