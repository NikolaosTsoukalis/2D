using System;

namespace _2D_RPG;


public class ComponentFunctionHandler
{
    #region Fields

    public Action functionCall { get; private set; }

    public static ComponentBase ParentComponent { get; private set; }

    #endregion

    #region Constructor
    public ComponentFunctionHandler(GlobalEnumarations.ComponentType componentType, ComponentBase parentComponent)
    {
        ParentComponent = parentComponent;
        if (!AssignFunction(componentType))
        {
            Console.WriteLine("This Button Type does not support a function");
        }

    }

    #endregion

    #region General Functions
    public bool AssignFunction(GlobalEnumarations.ComponentType componentType)
    {
        functionCall = CreateFunction(componentType);
        if (functionCall.Equals(null))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static Action CreateFunction(GlobalEnumarations.ComponentType componentType)
    {
        try
        {
            switch (componentType)
            {
                //Buttons
                case GlobalEnumarations.ComponentType.BackButton:
                    return new Action(GoBackFunction);
                case GlobalEnumarations.ComponentType.StartGameButton:
                    return new Action(StartGameFunction);
                case GlobalEnumarations.ComponentType.QuitButton:
                    return new Action(QuitFunction);
                case GlobalEnumarations.ComponentType.SettingsButton:
                    return new Action(OpenSettingsFunction);
                case GlobalEnumarations.ComponentType.CreateWorldSettingsButton:
                    return new Action(OpenWorldSettingsFunction);
                case GlobalEnumarations.ComponentType.LoadWorldListButton:
                    return new Action(LoadWorldListFunction);


                //TextBox
                case GlobalEnumarations.ComponentType.TextBox:
                    return new Action(EnableTypingTextBoxFunction);

                //Slider
                case GlobalEnumarations.ComponentType.SliderVertical:
                case GlobalEnumarations.ComponentType.SliderHorizontal:
                    return new Action(ChangeValueSliderFunction);

                //Default
                default:
                    return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return null;
        }
    }


    public bool CallFunction()
    {
        try
        {
            functionCall();
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

    private static void GoBackFunction()
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

    private static void QuitFunction()
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

    private static void StartGameFunction()
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

    private static void OpenSettingsFunction()
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

    public static void OpenWorldSettingsFunction()
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

    public static void LoadWorldListFunction()
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

    public static void LoadWorldFunction()
    {
        var component = (Button)ParentComponent;
        try
        {
            int[,] tileMapMatrix = Utillity.GetWorldBinaryFile(component.TextBox.Text, true);
            TileMap tileMap = new TileMap(tileMapMatrix);
            ParentComponent.main.ChangeState(new GameState(main, tileMap));

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }
    }

    #endregion

    #region TextBox Functions

    private static void EnableTypingTextBoxFunction()
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

    public static void ChangeValueSliderFunction()
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