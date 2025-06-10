using System;

namespace _2D_RPG;


public class ButtonFunctionHandler
{

    public Action functionCall;

    public ButtonFunctionHandler(ButtonType buttonType)
    {
        if (!AssignFunction(buttonType))
        {
            Console.WriteLine("This Button Type does not support a function");
        }
        
    }

    public bool AssignFunction(ButtonType buttonType)
    {
        functionCall = CreateFunction(buttonType);
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
    public static Action CreateFunction(ButtonType buttonType)
    {
        try
        {
            switch (buttonType)
            {
                case ButtonType.BackButton:
                    return new Action(GoBackFunction);
                case ButtonType.QuitButton:
                    return new Action(QuitFunction);
                case ButtonType.SettingsButton:
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


    public bool Call()
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


    #region Functions

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
    #endregion Functions

}