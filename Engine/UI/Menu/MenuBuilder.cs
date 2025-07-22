using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class MenuBuilder
{
    public MenuBuilder() { }


    #region Main Menu Constructors
    public static Menu BuildMainMenuLandingMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button StartGameButton = new Button(GlobalEnumarations.ComponentType.NavigateStartGameMenuButton, "Start Game");
        StartGameButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", true);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(GlobalEnumarations.ComponentType.NavigateMainMenuSettingsMenuButton, "Settings");
        SettingsButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton, "Quit");
        QuitButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(QuitButton);

        //DEBUG BUTTON REMOVE!!
        Button DebugButton = new Button(GlobalEnumarations.ComponentType.Debug, "Debug");
        Buttons.Add(DebugButton);

        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));
        return menu;
    }

    public static Menu BuildMainMenuStartGameMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button NewWorldButton = new Button(GlobalEnumarations.ComponentType.NavigateNewWorldSettingsMenuButton, "New World");
        NewWorldButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", true);
        Buttons.Add(NewWorldButton);

        Button LoadWorldListButton = new Button(GlobalEnumarations.ComponentType.NavigateWorldListMenuButton, "Load World");
        LoadWorldListButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
        Buttons.Add(LoadWorldListButton);

        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
        BackButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(BackButton);

        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));
        return menu;
    }

    public static Menu BuildMainMenuWorldListMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        string[] worldList = Utillity.GetWorldFileNames(true);
        Buttons = CreateWorldButtons(worldList);
        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
        BackButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(BackButton);

        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));

        return menu;
    }

    public static Menu BuildMainMenuCreateWorldSettingsMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button CreateWorldButton = new Button(GlobalEnumarations.ComponentType.CreateWorldButton, "Create World");
        CreateWorldButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(CreateWorldButton);

        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));

        return menu;
    }

    public static Menu BuildMainMenuSettingsMenu()
    {
        return null;
    }

    #endregion











    #region Helper Functions
    
    public static List<ComponentBase> CreateWorldButtons(string[] worldList)
    {
        List<ComponentBase> componentList = new List<ComponentBase>();
        try
        {
            if (worldList.Length > 0)
            {
                for (int i = 0; i < worldList.Length; i++)
                {
                    var WorldButton = new Button(GlobalEnumarations.ComponentType.LoadWorldFromWorldListButton, worldList[i]);
                    WorldButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
                    componentList.Add(WorldButton);
                }
                return componentList;
            }
            return null;

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return null;
        }
        
    }

    #endregion
}