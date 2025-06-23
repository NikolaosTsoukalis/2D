using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class MenuBuilder
{
    public MenuBuilder(){}


    #region Main Menu Constructors
    public static Menu BuildMainMenuLandingMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button StartGameButton = new Button(GlobalEnumarations.ComponentType.StartGameButton, "Start Game");
        StartGameButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", true);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(GlobalEnumarations.ComponentType.SettingsButton,"Settings");
        SettingsButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton,"Quit");
        QuitButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(QuitButton);
        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));
        return menu;
    }

    public static Menu BuildMainMenuStartGameMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button CreateWorldSettingsButton = new Button(GlobalEnumarations.ComponentType.CreateWorldSettingsButton);
        Buttons.Add(CreateWorldSettingsButton);
        Button LoadWorldListButton = new Button(GlobalEnumarations.ComponentType.LoadWorldListButton);
        Buttons.Add(LoadWorldListButton);
        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton);
        Buttons.Add(BackButton);
        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu,null));
        return menu;
    }

    public static Menu BuildMainMenuWorldListMenu()
    {
        return null;
    }

    public static Menu BuildMainMenuCreateWorldSettingsMenu()
    {
        return null;
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
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));
        return menu;
    }
}