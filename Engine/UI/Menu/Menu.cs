using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Menu
{
    public List<ComponentBase> Components { get; private set; }

    public LayoutBase Layout { get; private set; }

    private Color baseColor;

    public Vector2 ScreenDimensions { get; private set; }

    //public Vector2 

    public Menu(List<ComponentBase> components)
    {
        float screenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        float screenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;
        this.ScreenDimensions = new Vector2(screenWidth, screenHeight);

        this.baseColor = Color.White;
        this.Components = components;
    }

    public void Update(GameTime gameTime)
    {
        foreach (var component in Components)
        {
            component.Update(gameTime);
        }
        float screenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        float screenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;
        
        if (ScreenDimensions.X != screenWidth || ScreenDimensions.Y != screenHeight)
        {
            this.ScreenDimensions = new Vector2(screenWidth, screenHeight);
            this.Layout.AssignComponentPositions(true); 
        }
    }

    public void Draw(GameTime gameTime)
    {
        if (Layout.BoundingTexture != null)
        {
            Globals.SpriteBatch.Draw(Layout.BoundingTexture, Layout.BaseBounds, baseColor);
        }

        foreach (var component in Components)
        {
            component.Draw(gameTime);
        }
    }

    public void DebugDraw(GameTime gameTime) // for testing purposes
    {
        if (Layout.BoundingTexture != null)
        {
            Globals.SpriteBatch.Draw(Layout.BoundingTexture, Layout.BaseBounds, baseColor);
        }

        foreach (var component in Components)
        {
            component.DebugDraw(gameTime);
        }
    }

    public void AddButton(Button component)
    {
        Components.Add(component);
    }

    public void AddButtons(List<Button> buttons)
    {
        foreach (Button button in buttons)
        {
            Components.Add(button);
        }
    }

    public void RemoveButton(Button component)
    {
        Components.Remove(component);
    }

    public void SetMenuLayout(LayoutBase layout)
    {
        this.Layout = layout;
    }
}