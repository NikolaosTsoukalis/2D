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

        Button StartGameButton = new Button(GlobalEnumarations.ComponentType.StartGameButton, "Start Game");
        StartGameButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", true);
        Buttons.Add(StartGameButton);
        Button SettingsButton = new Button(GlobalEnumarations.ComponentType.SettingsButton, "Settings");
        SettingsButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
        Buttons.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton, "Quit");
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

        Button CreateWorldSettingsButton = new Button(GlobalEnumarations.ComponentType.CreateWorldSettingsButton, "Create World");
        Buttons.Add(CreateWorldSettingsButton);
        Button LoadWorldListButton = new Button(GlobalEnumarations.ComponentType.LoadWorldListButton, "Load World");
        Buttons.Add(LoadWorldListButton);
        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
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
        Buttons = HandleWorldButtons(worldList);
        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
        menu = new Menu(Buttons);
        menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));

        return null;
    }

    public static Menu BuildMainMenuCreateWorldSettingsMenu()
    {
        return null;
    }

    public static Menu BuildMainMenuSettingsMenu()
    {
        return null;
    }

    #endregion











    #region Helper Functions
    
    public static List<ComponentBase> HandleWorldButtons(string[] worldList)
    {
        List<ComponentBase> componentList = new List<ComponentBase>();
        try
        {
            if (worldList.Length > 0)
            {
                for (int i = 0; i < worldList.Length; i++)
                {
                    var WorldButton = new Button(GlobalEnumarations.ComponentType.LoadWorldButton, worldList[i]);
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