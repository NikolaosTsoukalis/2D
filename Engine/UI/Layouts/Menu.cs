using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Menu
{

    public List<Component> Components;

    public Component baseFieldComponent;

    //public Vector2 

    public Menu()
    {

    }

    public void Update(GameTime gameTime)
    {
        foreach (var component in Components)
        {
            component.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Begin();

        foreach (var component in Components)
        {
            component.Draw(gameTime);
        }
        Globals.SpriteBatch.End();
    }

    public void AddComponent(Component component)
    {
        Components.Add(component);
    }

    public void RemoveComponent(Component component)
    {
        Components.Remove(component);
    } 

    //public void SetLayout()
    
}