using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;


namespace _2D_RPG;

public class MenuHandler
{
    private Menu currentMenu;
    private State currentGameState;

    private Stack menuStack;

    public MenuHandler(Main main)
    {
        currentGameState = main.currentGameState;
        menuStack = new Stack();
    }

    public void AddMenuToStackTop(Menu menu)
    {
        menuStack.Push(menu);
    }

    public void RemoveFromStackTop(Menu menu)
    {
        menuStack.Pop();
    }

    public void Update(GameTime gameTime)
    {
        currentMenu = (Menu)menuStack.Peek();
        currentMenu.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        currentMenu = (Menu)menuStack.Peek();
        currentMenu.Draw(gameTime);
    }

    public Menu AddLandingMenu()
    {

        Menu menu = new Menu(MenuType.MainMenu);
        menu.AddComponent();
        menu.SetLayout(new VerticalMainMenuLayoutBase(currentMenu.getComponentList(), null)); // add logic for base texture
                 
        AddMenuToStackTop(menu);

        return;
    }

    public void HandleComponentFunctions(Menu menu)
    {
        switch (menu.MenuType)
        {
            case MenuType.MainMenu:
                CreateComponentList
                break;
        }
    }
}