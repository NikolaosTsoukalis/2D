using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class MenuBuilder
{
    public MenuBuilder()
    {
    }

    public void BuildMainMenu()
    {

    }

    public static Menu BuildMainMenuLandingMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();

        Button StartGameButton = new Button(ComponentType.StartGameButton);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(ComponentType.SettingsButton);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(ComponentType.QuitButton);
        Buttons.Add(QuitButton);
        Menu menu = new Menu(new VerticalMainMenuLayoutBase(Buttons, null));
        return menu;
    }

    public static Menu BuildMainMenuStartGameMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();

        Button StartGameButton = new Button(ComponentType.StartGameButton);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(ComponentType.SettingsButton);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(ComponentType.QuitButton);
        Buttons.Add(QuitButton);
        Menu menu = new Menu(new VerticalMainMenuLayoutBase(Buttons, null));
        return menu;  
    }
}