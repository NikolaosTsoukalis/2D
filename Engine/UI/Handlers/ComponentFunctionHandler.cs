using System;
using System.Collections.Generic;

namespace _2D_RPG;



public class ComponentFunctionHandler
{
    #region Fields

    public Action FunctionCall { get; private set; }

    public ComponentBase ParentComponent { get; private set; }

    private static readonly Dictionary<GlobalEnumarations.ComponentType, Func<ComponentFunctionHandler, Action>> FunctionMap = new()
    {
        //FUNCTION
        { GlobalEnumarations.ComponentType.Debug, handler => handler.EnableDebugFunction},
        { GlobalEnumarations.ComponentType.BackButton, handler => handler.GoBackFunction },
        { GlobalEnumarations.ComponentType.QuitButton, handler => handler.QuitFunction },
        { GlobalEnumarations.ComponentType.TextBox, handler => handler.EnableTypingTextBoxFunction },
        { GlobalEnumarations.ComponentType.CreateWorldButton, handler => handler.CreateWorldFunction },
        { GlobalEnumarations.ComponentType.SliderVertical, handler => handler.ChangeValueSliderFunction },
        { GlobalEnumarations.ComponentType.SliderHorizontal, handler => handler.ChangeValueSliderFunction },
        { GlobalEnumarations.ComponentType.LoadWorldFromWorldListButton, handler => handler.LoadWorldFromWorldListFunction },

        //NAVIGATION
        { GlobalEnumarations.ComponentType.NavigateMainMenuSettingsMenuButton, handler => handler.NavigateMainMenuSettingsMenuFunction },
        { GlobalEnumarations.ComponentType.NavigateStartGameMenuButton, handler => handler.NavigateStartGameMenuFunction },
        { GlobalEnumarations.ComponentType.NavigateNewWorldSettingsMenuButton, handler => handler.NavigateCreateWorldSettingsMenuFunction },
        { GlobalEnumarations.ComponentType.NavigateWorldListMenuButton, handler => handler.NavigateWorldListMenuFunction },
    };

    #endregion

    #region Constructor

    public ComponentFunctionHandler(GlobalEnumarations.ComponentType componentType, ComponentBase parentComponent)
    {
        this.ParentComponent = parentComponent;
        if (!AssignFunction(componentType))
        {
            Console.WriteLine("This Button Type does not support a function");
        }
    }

    #endregion

    #region General Functions
    private bool AssignFunction(GlobalEnumarations.ComponentType componentType)
    {
        if (FunctionMap.TryGetValue(componentType, out var actionFactory))
        {
            FunctionCall = actionFactory(this);
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

    private void EnableDebugFunction()
    {
        Globals.enableDebugs = !Globals.enableDebugs;
    }
    
    private void GoBackFunction()
    {
        Globals.MenuHandler.RemoveFromStackTop(Globals.MenuHandler.currentMenu);
    }

    private void QuitFunction()
    {
        Globals.MenuHandler.Main.Exit();
    }

    private void NavigateStartGameMenuFunction()
    {
        Menu newMenu = MenuBuilder.BuildMainMenuStartGameMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) StartGame Menu was not built!");    
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);
    }

    private void NavigateMainMenuSettingsMenuFunction()
    {
        Menu newMenu = MenuBuilder.BuildMainMenuSettingsMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) Settings Menu was not built!");    
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);
    }

    private void NavigateCreateWorldSettingsMenuFunction()
    {
        Menu newMenu = MenuBuilder.BuildMainMenuCreateWorldSettingsMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) CreateWorldSettings Menu was not built!");    
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);
    }

    private void NavigateWorldListMenuFunction()
    {
        Menu newMenu = MenuBuilder.BuildMainMenuWorldListMenu();
        if (newMenu == null)
        {
            throw new Exception("ERROR : (MainMenu) WorldList Menu was not built!");    
        }
        Globals.MenuHandler.AddMenuToStackTop(newMenu);
    }

    private void LoadWorldFromWorldListFunction()
    {
        var component = (Button)ParentComponent;
        int[,] tileMapMatrix = Utillity.GetWorldBinaryFile(component.TextBox.Text, true);
        TileMap tileMap = new TileMap(tileMapMatrix);

        Globals.MenuHandler.Main.ChangeState(new GameState(Globals.MenuHandler.Main, tileMap));
    }

    private void CreateWorldFunction()
    {
        //HERE WE NEED TO IMPORT THE SETTINGS FROM THE "CREATE WORLD SETTINGS MENU"
        //IF THEY HAVE NOT BEEN OPENED THERE HAS TO BE DEFAULT VALUES
        TileMap tileMap = new TileMap();
        Globals.MenuHandler.Main.ChangeState(new GameState(Globals.MenuHandler.Main, tileMap));
    }

    #endregion

    #region TextBox Functions

    private void EnableTypingTextBoxFunction()
    {
        if (ParentComponent.IsWritable && ParentComponent.State == GlobalEnumarations.ComponentState.Disabled)
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

    public void ChangeValueSliderFunction()
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

}