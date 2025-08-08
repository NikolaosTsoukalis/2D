using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;

public abstract class LayoutBase
{

    public Rectangle BaseBounds { get; private set; }
    public Vector2 BaseBoundCenter { get; private set; }
    public Texture2D LayoutTexture { get; protected set; }
    public Vector2 LayoutPosition { get; protected set; }

    public Menu Menu { get; private set; }

    public LayoutBase(Menu menu, Texture2D menuBoundsTexture)
    {
        this.Menu = menu;
        SanitizeComponents(this.Menu.Components);
        SetBaseBoundsToScreen();
    }

    public virtual void AssignComponentPositions(bool resetFlag) { }
    public virtual void SetComponentPaddingMap() { }

    public void SetBaseBoundsToScreen()
    {
        this.BaseBounds = new Rectangle(0, 0, (int)Menu.ScreenDimensions.X, (int)Menu.ScreenDimensions.Y);
        this.BaseBoundCenter = new Vector2((int)Menu.ScreenDimensions.X / 2f, (int)Menu.ScreenDimensions.Y / 2f);
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