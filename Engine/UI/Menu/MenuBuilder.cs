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
        List<ComponentBase> Components = new List<ComponentBase>();
        Texture2D MenuLayoutTexture = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.MainMenu);
        Menu menu = null;

        TextBox TitleBox = new TextBox(GlobalEnumarations.TextureLibraryUI.TextBox_Free_Type_B, Globals.Font, "Main Menu", 0.75f, false);
        Components.Add(TitleBox);

        Button StartGameButton = new Button(GlobalEnumarations.ComponentType.NavigationButton, GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L, "Start Game", GlobalEnumarations.MenuNavigationPaths.MainMenuToStartGame);
        Components.Add(StartGameButton);
        Button SettingsButton = new Button(GlobalEnumarations.ComponentType.NavigationButton, GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L, "Settings", GlobalEnumarations.MenuNavigationPaths.MainMenuToSettings);
        Components.Add(SettingsButton);
        Button QuitButton = new Button(GlobalEnumarations.ComponentType.QuitButton,GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L, "Quit");
        Components.Add(QuitButton);

        //DEBUG BUTTON REMOVE!!
        Button DebugButton = new Button(GlobalEnumarations.ComponentType.DebugButton,GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L, "Debug");
        Components.Add(DebugButton);

        menu = new Menu(Components);
        menu.SetMenuLayout(new MainMenuLayout(menu, MenuLayoutTexture));
        return menu;
    }

    #endregion

    #region Start Game Menu

    public static Menu BuildStartGameMenu()
    {
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Texture2D MenuLayoutTexture = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.MainMenu);
        Menu menu = null;

        Button CreateWorldButton = new Button(GlobalEnumarations.ComponentType.NavigationButton, GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L, "Create World", GlobalEnumarations.MenuNavigationPaths.StartGameToCreateWorld);
        Buttons.Add(CreateWorldButton);

        Button LoadWorldButton = new Button(GlobalEnumarations.ComponentType.NavigationButton, GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L, "Load World", GlobalEnumarations.MenuNavigationPaths.StartGameToLoadWorld);
        Buttons.Add(LoadWorldButton);

        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L, "Back");
        Buttons.Add(BackButton);

        menu = new Menu(Buttons);
       //menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, MenuLayoutTexture));
        return menu;
    }

    #endregion

    #region Load World Menu

    public static Menu BuildLoadWorldMenu()
    {
        //REFACTOR
        List<ComponentBase> Buttons = new List<ComponentBase>();
        Menu menu = null;

        string[] worldList = Utillity.GetWorldFileNames(true);
        Buttons = CreateWorldButtons(worldList);
        //Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
        //BackButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", false);
        //Buttons.Add(BackButton);

        menu = new Menu(Buttons);
       // menu.SetMenuLayout(new VerticalMainMenuLayoutBase(menu, null));

        return menu;
    }

    #endregion

    #region Create World Menu

    public static Menu BuildCreateWorldMenu()
    {
        List<ComponentBase> Components = new List<ComponentBase>();

        Menu menu = null;

        /*
        TextBox SeedTextBox = new TextBox(Globals.Font, "Seed", 0.75f, false, null);
        SeedTextBox.TextureHandler.SetPositionBasedComponentTextures("CreateWorldSettingsLayout", null);
        Components.Add(SeedTextBox);

        Button CreateWorldButton = new Button(GlobalEnumarations.ComponentType.CreateAndLoadWorldButton, "Create");
        CreateWorldButton.TextureHandler.SetPositionBasedComponentTextures("CreateWorldSettingsLayout", null);
        Components.Add(CreateWorldButton);

        Button SaveWorldAndQuitButton = new Button(GlobalEnumarations.ComponentType.SaveWorldAndQuitButton, "Save & Quit");
        SaveWorldAndQuitButton.TextureHandler.SetPositionBasedComponentTextures("CreateWorldSettingsLayout", null);
        Components.Add(SaveWorldAndQuitButton);

        Button BackButton = new Button(GlobalEnumarations.ComponentType.BackButton, "Back");
        BackButton.TextureHandler.SetPositionBasedComponentTextures("CreateWorldSettingsLayout", null);
        Components.Add(BackButton);

        menu = new Menu(Components);
        menu.SetMenuLayout(new CreateWorldSettingsLayout(menu, null));
    */
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
                    //var WorldButton = new Button(GlobalEnumarations.ComponentType.LoadWorldButton, worldList[i]);
                    //WorldButton.TextureHandler.SetPositionBasedComponentTextures("VerticalMainMenuLayoutBase", null);
                    //componentList.Add(WorldButton);
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