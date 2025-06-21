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

    //ButtonFunctions x = new ButtonFunctions(Action x);
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

                //TextBox
                case GlobalEnumarations.ComponentType.TextBox:
                    return new Action(EnableTypingTextBoxFunction);
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
        Globals.MenuHandler.RemoveFromStackTop(Globals.MenuHandler.currentMenu);
    }

    private static void QuitFunction()
    {
        Globals.MenuHandler.Main.Exit();
    }

    private static void StartGameFunction()
    {
        MenuBuilder.BuildMainMenuStartGameMenu();
    }

    private static void OpenSettingsFunction()
    {
        MenuBuilder.BuildMainMenuSettingsMenu();
    }
    #endregion Functions

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

}