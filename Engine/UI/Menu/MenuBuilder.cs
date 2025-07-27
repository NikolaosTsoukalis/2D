using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class MenuBuilder
{
    public MenuBuilder() { }


    #region Main Menu

    public static Menu BuildMainMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        NavigationButton StartGameButton = new NavigationButton(GlobalEnumarations.MenuNavigationPaths.MainMenuToStartGame, "Start Game");
        StartGameButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", true);
        Buttons.Add(StartGameButton);
        NavigationButton SettingsButton = new NavigationButton(GlobalEnumarations.MenuNavigationPaths.MainMenuToSettings, "Settings");
        SettingsButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton, "Quit");
        QuitButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(QuitButton);

        //DEBUG BUTTON REMOVE!!
        Button DebugButton = new Button(GlobalEnumarations.ComponentType.DebugButton, "Debug");
        Buttons.Add(DebugButton);

        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));
        return menu;
    }

    #endregion

    #region Start Game Menu

    public static Menu BuildStartGameMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        NavigationButton CreateWorldButton = new NavigationButton(GlobalEnumarations.MenuNavigationPaths.StartGameToCreateWorld, "Create World");
        CreateWorldButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", true);
        Buttons.Add(CreateWorldButton);

        NavigationButton LoadWorldButton = new NavigationButton(GlobalEnumarations.MenuNavigationPaths.StartGameToLoadWorld, "Load World");
        LoadWorldButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
        Buttons.Add(LoadWorldButton);

        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
        BackButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        Buttons.Add(BackButton);

        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));
        return menu;
    }

    #endregion

    #region Load World Menu

    public static Menu BuildLoadWorldMenu()
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

    #endregion

    #region Create World Menu

    public static Menu BuildCreateWorldMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        Button CreateWorldButton = new Button(GlobalEnumarations.ComponentType.CreateAndLoadWorldButton, "Create");
        CreateWorldButton.TextureHandler.SetPositionBasedComponentTextures("CreateWorldSettingsLayout", null);
        Buttons.Add(CreateWorldButton);

        Button SaveWorldAndQuitButton = new Button(GlobalEnumarations.ComponentType.SaveWorldAndQuitButton, "Save & Quit");
        SaveWorldAndQuitButton.TextureHandler.SetPositionBasedComponentTextures("CreateWorldSettingsLayout", null);
        Buttons.Add(SaveWorldAndQuitButton);

        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
        BackButton.TextureHandler.SetPositionBasedComponentTextures("CreateWorldSettingsLayout", null);
        Buttons.Add(BackButton);

        menu = new Menu(Buttons);
        menu.SetMenuLayout(new CreateWorldSettingsLayout(menu, null));

        return menu;
    }

    #endregion

    #region Settings Menu

    public static Menu BuildSettingsMenu()
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
                    var WorldButton = new Button(GlobalEnumarations.ComponentType.LoadWorldButton, worldList[i]);
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