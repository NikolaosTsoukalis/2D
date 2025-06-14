using System;

namespace _2D_RPG;


public class ComponentFunctionHandler
{
    #region Fields

    public Action functionCall;

    #endregion

    #region Constructor
    public ComponentFunctionHandler(ComponentType componentType)
    {
        if (!AssignFunction(componentType))
        {
            Console.WriteLine("This Button Type does not support a function");
        }

    }

    #endregion

    #region General Functions
    public bool AssignFunction(ComponentType componentType)
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
    public static Action CreateFunction(ComponentType componentType)
    {
        try
        {
            switch (componentType)
            {
                case ComponentType.BackButton:
                    return new Action(GoBackFunction);
                case ComponentType.StartGameButton:
                    return new Action(StartGameFunction);
                case ComponentType.QuitButton:
                    return new Action(QuitFunction);
                case ComponentType.SettingsButton:
                    return new Action(OpenSettingsFunction);
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

    public static void GoBackFunction()
    {
        Globals.MenuHandler.RemoveFromStackTop(Globals.MenuHandler.currentMenu);
    }

    public static void QuitFunction()
    {
        Globals.MenuHandler.Main.Exit();
    }

    public static void OpenSettingsFunction()
    {
        MenuBuilder.BuildMainMenuStartGameMenu();
    }

    public static void StartGameFunction()
    {

    }
    #endregion Functions

}