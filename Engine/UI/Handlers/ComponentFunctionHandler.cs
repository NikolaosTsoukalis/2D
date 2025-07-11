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
        { GlobalEnumarations.ComponentType.BackButton, handler => handler.GoBackFunction },
        { GlobalEnumarations.ComponentType.StartGameButton, handler => handler.StartGameFunction },
        { GlobalEnumarations.ComponentType.QuitButton, handler => handler.QuitFunction },
        { GlobalEnumarations.ComponentType.SettingsButton, handler => handler.OpenSettingsFunction },
        { GlobalEnumarations.ComponentType.CreateWorldSettingsButton, handler => handler.OpenWorldSettingsFunction },
        { GlobalEnumarations.ComponentType.LoadWorldListButton, handler => handler.LoadWorldListFunction },
        { GlobalEnumarations.ComponentType.TextBox, handler => handler.EnableTypingTextBoxFunction },
        { GlobalEnumarations.ComponentType.SliderVertical, handler => handler.ChangeValueSliderFunction },
        { GlobalEnumarations.ComponentType.SliderHorizontal, handler => handler.ChangeValueSliderFunction }
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
            Console.WriteLine("ERROR: " + e);
            return false;
        }
    }

    #endregion

    #region Button Functions

    private void GoBackFunction()
    {
        try
        {
            Globals.MenuHandler.RemoveFromStackTop(Globals.MenuHandler.currentMenu);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
    }

    private void QuitFunction()
    {
        try
        {
            Globals.MenuHandler.Main.Exit();
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
    }

    private void StartGameFunction()
    {
        try
        {
            MenuBuilder.BuildMainMenuStartGameMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
    }

    private void OpenSettingsFunction()
    {
        try
        {
            MenuBuilder.BuildMainMenuSettingsMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }

    }

    public void OpenWorldSettingsFunction()
    {
        try
        {
            MenuBuilder.BuildMainMenuCreateWorldSettingsMenu();
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
    }

    public void LoadWorldListFunction()
    {
        try
        {
            MenuBuilder.BuildMainMenuWorldListMenu();

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
    }

    public void LoadWorldFunction()
    {
        var component = (Button)ParentComponent;
        try
        {
            int[,] tileMapMatrix = Utillity.GetWorldBinaryFile(component.TextBox.Text, true);
            TileMap tileMap = new TileMap(tileMapMatrix);
            Globals.MenuHandler.Main.ChangeState(new GameState(Globals.MenuHandler.Main, tileMap));
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
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