using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Menu
{
    private List<Button> Buttons;

    private LayoutBase Layout;

    private Color baseColor;

    //public Vector2 

    public Menu(LayoutBase layout)
    {
        this.baseColor = Color.White;
        SetLayout(layout);
    }

    public void Update(GameTime gameTime)
    {
        foreach (var component in Buttons)
        {
            component.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Begin();

        Globals.SpriteBatch.Draw(Layout.GetBaseTexture(), Layout.GetBaseTextureRectangle(), baseColor);

        foreach (var component in Buttons)
        {
            component.Draw(gameTime);
        }
        Globals.SpriteBatch.End();
    }

    public void AddButton(Button component)
    {
        Buttons.Add(component);
    }

    public void AddButtons(List<Button> buttons)
    {
        foreach (Button button in buttons)
        {
            Buttons.Add(button);    
        }
    }
    public void RemoveButton(Button component)
    {
        Buttons.Remove(component);
    }

    public void SetLayout(LayoutBase layout)
    {
        this.Layout = layout;
    }

    public List<Button> getButtonList()
    {
        return Buttons;
    }

}