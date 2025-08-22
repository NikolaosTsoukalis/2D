using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;


namespace _2D_RPG;

public class MenuHandler
{
    public Menu currentMenu;
    public State currentGameState;

    public Stack menuStack;

    public Main Main;

    public MenuHandler(Main main)
    {
        this.Main = main;
        currentGameState = Main.currentGameState;
        menuStack = new Stack();
    }

    public void AddMenuToStackTop(Menu menu)
    {
        menuStack.Push(menu);
    }

    public void RemoveFromStackTop()
    {
        menuStack.Pop();
    }

    public void EmptyStack(Menu menu)
    {
        menuStack.Clear();
    }

    public void RemoveFromStackTopUntil(Menu menu)
    {
        if (menuStack.Contains(menu))
        {
            while (menuStack.Peek() != menu)
            {
                menuStack.Pop();
            }
        }
    }

    public void ResetStackToRoot()
    {
        while (menuStack.Count > 1 )
        {
            menuStack.Pop();
        }
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

    public void DebugDraw(GameTime gameTime)
    {
        currentMenu = (Menu)menuStack.Peek();
        currentMenu.DebugDraw(gameTime);
    }
}