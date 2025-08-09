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
    public Int2 ScreenDimensions { get; private set; }

    //public Vector2 

    public Menu(List<ComponentBase> components)
    {
        this.ScreenDimensions = Globals.ScreenResolution;

        this.Components = components;
    }

    public void Update(GameTime gameTime)
    {
        Layout.Update(gameTime);
        
        foreach (var component in Components)
        {
            component.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        Layout.Draw(gameTime);

        foreach (var component in Components)
        {
            component.Draw(gameTime);
        }
    }

    public void DebugDraw(GameTime gameTime) // for testing purposes
    {
        Layout.DebugDraw(gameTime);

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