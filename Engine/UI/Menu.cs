using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public enum MenuType
{
    MainMenu,
    SettingsMainMenu,
    WorldListMainMenu
}

public class Menu
{
    private List<Component> Components;

    public MenuType MenuType;

    private LayoutBase Layout;

    private Rectangle boundingTexturePosition;

    private Color baseColor;

    //public Vector2 

    public Menu(MenuType menuType)
    {
        this.baseColor = Color.White;
        this.MenuType = menuType;
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

        Globals.SpriteBatch.Draw(Layout.GetBaseTexture(), Layout.GetBaseTextureRectangle(), baseColor);

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

    public void SetLayout(LayoutBase layout)
    {
        this.Layout = layout;
    }

    public List<Component> getComponentList()
    {
        return Components;
    }

}