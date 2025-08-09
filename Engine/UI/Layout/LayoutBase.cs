using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;

public abstract class LayoutBase
{
    public Int2 ScreenDimensions { get; private set; }
    public Rectangle BaseBounds { get; private set; }
    public Vector2 BaseBoundCenter { get; private set; }
    public Texture2D Texture { get; protected set; }
    public Int2 Position { get; protected set; }

    public Menu Menu { get; private set; }

    public LayoutBase(Menu menu, Texture2D texture)
    {
        this.Menu = menu;
        Texture = texture;
        this.ScreenDimensions = Globals.ScreenResolution;
        SanitizeComponents(this.Menu.Components);
        SetBaseBoundsToScreen();
        this.Position = AlignComponentWithBoundCenter(texture, BaseBounds.X, BaseBounds.Y);
    }

    public virtual void AssignComponentPositions() { }
    public virtual void SetComponentPaddingMap() { }

    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(GameTime gameTime) { }
    public virtual void DebugDraw(GameTime gameTime) { }

    public void UpdateScreenDimensions()
    {
        this.ScreenDimensions = Globals.ScreenResolution;
    }
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

    public Int2 AlignComponentWithBoundCenter(Texture2D componentTexture, int boundingWidth, int boundingHeight)
    {
        if (componentTexture != null)
        {
            int TextureHeight = componentTexture.Height;
            int TextureWidth = componentTexture.Width;
            Int2 centerOfBounds = new Int2(boundingWidth / 2, boundingHeight / 2);
            Int2 centerOfTexture = new Int2(TextureWidth / 2, TextureHeight / 2);

            return centerOfBounds - centerOfTexture;
        }
        else
        {
            Int2 centerOfBounds = new Int2(boundingWidth / 2, boundingHeight / 2);

            return centerOfBounds;
        }
    }

    public bool SetChildTextBoxPosition(ComponentBase component)
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