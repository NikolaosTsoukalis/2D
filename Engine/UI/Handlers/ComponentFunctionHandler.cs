using System;
using System.Collections.Generic;

namespace _2D_RPG;



public class ComponentFunctionHandler
{
    #region Fields

    public Action FunctionCall { get; private set; }

    public ComponentBase ParentComponent { get; private set; }

    private static readonly Dictionary<GlobalEnumarations.MenuNavigationPaths, Func<ComponentFunctionHandler, Action>> NavigationActionFactory = new()
    {
        { GlobalEnumarations.MenuNavigationPaths.MainMenuToStartGame, handler => handler.NavigateMainMenuToStartGameMenu },
        { GlobalEnumarations.MenuNavigationPaths.MainMenuToSettings, handler => handler.NavigateMainMenuToSettingsMenu },

        { GlobalEnumarations.MenuNavigationPaths.StartGameToCreateWorld, handler => handler.NavigateStartGameToCreateWorldMenu },
        { GlobalEnumarations.MenuNavigationPaths.StartGameToLoadWorld, handler => handler.NavigateStartGameToLoadWorldMenu },
                
    };


    private static readonly Dictionary<GlobalEnumarations.ComponentType, Func<ComponentFunctionHandler, Action>> ActionFactory = new()
    {
        //FUNCTION
        { GlobalEnumarations.ComponentType.DebugButton,                     handler => handler.EnableDebug },

        { GlobalEnumarations.ComponentType.BackButton,                      handler => handler.GoBack },
        { GlobalEnumarations.ComponentType.QuitButton,                      handler => handler.Quit },
        { GlobalEnumarations.ComponentType.LoadWorldButton,                 handler => handler.LoadWorld },
        { GlobalEnumarations.ComponentType.CreateAndLoadWorldButton,        handler => handler.CreateAndLoadWorld },
        { GlobalEnumarations.ComponentType.SaveWorldAndQuitButton,          handler => handler.SaveWorldAndQuit },

        { GlobalEnumarations.ComponentType.TextBox,                         handler => handler.EnableTypingTextBox },
        { GlobalEnumarations.ComponentType.SliderVertical,                  handler => handler.ChangeValueSlider },
        { GlobalEnumarations.ComponentType.SliderHorizontal,                handler => handler.ChangeValueSlider },



        { GlobalEnumarations.ComponentType.SaveWorldButton,                 handler => handler.SaveWorld },
    };

    #endregion

    #region Constructor

    public ComponentFunctionHandler(GlobalEnumarations.ComponentType componentType, ComponentBase parentComponent)
    {
        this.ParentComponent = parentComponent;
        if (!AssignFunction(componentType))
        {
            Console.WriteLine("The Function of the component: '" + parentComponent.ToString() + "' was not assigned properly.");
        }
    }

    #endregion

    #region General Functions

    public bool AssignFunction(GlobalEnumarations.ComponentType componentType)
    {

        if (ActionFactory.TryGetValue(componentType, out var action))
        {
            FunctionCall = action(this);
            return true;
        }
        if (NavigationActionFactory.TryGetValue((GlobalEnumarations.MenuNavigationPaths)ParentComponent.SpecialAttribute, out var navigationAction))
        {
            FunctionCall = navigationAction(this);
            return true;
        }

        FunctionCall = null;

        return false;
    }

    public bool CallFunction()
    {
        try
        {
            FunctionCall();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR in '" + FunctionCall.ToString() + "' : " + e);
            return false;
        }
    }

    #endregion

    #region Button Functions

    private void EnableDebug()
    {
        Globals.enableDebugs = !Globals.enableDebugs;
    }

    private void GoBack()
    {
        Globals.MenuHandler.RemoveFromStackTop();
    }

    private void Quit()
    {
        Globals.MenuHandler.Main.Exit();
    }

    private void LoadWorld()
    {
        var component = (Button)ParentComponent;
        int[,] tileMapMatrix = Utillity.GetWorldBinaryFile(component.TextBox.Text, true);
        TileMap tileMap = new TileMap(tileMapMatrix);

        Globals.MenuHandler.Main.ChangeState(new GameState(Globals.MenuHandler.Main, tileMap));
    }

    private void CreateAndLoadWorld()
    {
        //HERE WE NEED TO IMPORT THE SETTINGS FROM THE "CREATE WORLD SETTINGS MENU"
        //IF THEY HAVE NOT BEEN OPENED THERE HAS TO BE DEFAULT VALUES
        TileMap tileMap = new TileMap();
        Globals.MenuHandler.Main.ChangeState(new GameState(Globals.MenuHandler.Main, tileMap));
    }

    private void SaveWorld()
    {
        //save
    }

    private void SaveWorldAndQuit()
    {
        //save
        NavigateCreateWorldToMainMenu();
    }

    #endregion

    #region TextBox Functions

    private void EnableTypingTextBox()
    {
        if (/*ParentComponent.IsWritable &&*/ ParentComponent.State == GlobalEnumarations.ComponentState.Disabled)
        {
            ParentComponent.Enable();
        }
        else
        {
            ParentComponent.Disable();
        }

    }
    #endregion

    #region Slider Functions

    public void ChangeValueSlider()
    {
        var component = (Slider)ParentComponent;
        switch (component.ValueType)
        {
            case GlobalEnumarations.SliderComponentValues.Volume:
                Globals.Volume = component.CurrentValue;
                break;
            case GlobalEnumarations.SliderComponentValues.Sensitivity:
                Globals.Sensitivity = component.CurrentValue;
                break;
        }
    }

    #endregion

    #region Navigation Functions

    private void NavigateMainMenuToStartGameMenu()
    {
        Menu newMenu = MenuBuilder.BuildStartGameMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) StartGame Menu was not built!");
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);
    }

    private void NavigateMainMenuToSettingsMenu()
    {
        /*Menu newMenu = MenuBuilder.BuildSettingsMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) Settings Menu was not built!");
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);*/
    }

    private void NavigateStartGameToCreateWorldMenu()
    {
        Menu newMenu = MenuBuilder.BuildCreateWorldMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) CreateWorldSettings Menu was not built!");
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);
    }

    private void NavigateStartGameToLoadWorldMenu()
    {
        Menu newMenu = MenuBuilder.BuildLoadWorldMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) WorldList Menu was not built!");
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);
    }
    
    private void NavigateCreateWorldToMainMenu()
    {
        Globals.MenuHandler.ResetStackToRoot();
    }

    #endregion
}