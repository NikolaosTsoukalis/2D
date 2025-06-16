using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class MenuBuilder
{
    public MenuBuilder(){}

    public static Menu BuildMainMenuLandingMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button StartGameButton = new Button(GlobalEnumarations.ComponentType.StartGameButton);
        StartGameButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", true);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(GlobalEnumarations.ComponentType.SettingsButton);
        SettingsButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton);
        QuitButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(QuitButton);
        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu,null));
        return menu;
    }

    public static Menu BuildMainMenuStartGameMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button StartGameButton = new Button(GlobalEnumarations.ComponentType.StartGameButton);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(GlobalEnumarations.ComponentType.SettingsButton);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton);
        Buttons.Add(QuitButton);
        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu,null));
        return menu;
    }
    
    public static Menu BuildMainMenuSettingsMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button StartGameButton = new Button(GlobalEnumarations.ComponentType.StartGameButton);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(GlobalEnumarations.ComponentType.SettingsButton);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton);
        Buttons.Add(QuitButton);
        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu,null));
        return menu;  
    }
}