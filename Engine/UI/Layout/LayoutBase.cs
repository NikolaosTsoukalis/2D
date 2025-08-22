using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace _2D_RPG;

public abstract class LayoutBase
{
    public Int2 ScreenDimensions { get; private set; }
    public Rectangle BaseBounds { get; private set; }
    public Vector2 BaseBoundCenter { get; private set; }
    public Texture2D Texture { get; protected set; }
    public Vector2 Position { get; protected set; }

    public Menu Menu { get; private set; }

    public LayoutBase(Menu menu, Texture2D texture)
    {
        this.Menu = menu;
        this.Texture = texture;
        this.ScreenDimensions = Globals.ScreenResolution;
        SanitizeComponents(this.Menu.Components);
        SetBaseBoundsToScreen();
        this.Position = AlignComponentWithBoundCenter(texture, BaseBounds.Width, BaseBounds.Height);
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
            Console.WriteLine("ERROR in SetComponentBounds: " + e);
            return true;
        }
    }

    public Vector2 AlignComponentWithBoundCenter(Texture2D componentTexture, int boundingWidth, int boundingHeight)
    {
        if (componentTexture != null)
        {
            int TextureHeight = componentTexture.Height;
            int TextureWidth = componentTexture.Width;
            Vector2 centerOfBounds = new Vector2(boundingWidth / 2, boundingHeight / 2);
            Vector2 centerOfTexture = new Vector2(TextureWidth / 2, TextureHeight / 2);

            return centerOfBounds - centerOfTexture;
        }
        else
        {
            Vector2 centerOfBounds = new Vector2(boundingWidth / 2, boundingHeight / 2);

            return centerOfBounds;
        }
    }

    public bool ManageTextBoxPosition(ComponentBase component)
    {
        if (component.GetType().Equals(typeof(TextBox)))
        {
            TextBox componentN = (TextBox)component;
            componentN.SetTextPositionAsParent();
        }
        else
        {
            Type type = component.GetType();
            PropertyInfo field = type.GetProperty("TextBox", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field != null)
            {
                object TextBox = field.GetValue(component);
                if (TextBox != null)
                {
                    MethodInfo SetPositionAsChild = TextBox.GetType().GetMethod("SetPositionAsChild");

                    if (SetPositionAsChild != null)
                    {
                        SetPositionAsChild.Invoke(TextBox, null);
                        return true;
                    }
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
            Console.WriteLine("ERROR in SetDebugButtonPosition: " + e);
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