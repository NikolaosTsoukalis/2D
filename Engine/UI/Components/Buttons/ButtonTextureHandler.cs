using System;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;


public class ButtonTextureHandler
{

    private static Texture2D textureUnPressed;

    private static Texture2D texturePressed;

    private static Texture2D textureDisabled;

    public ButtonTextureHandler(ButtonType buttonType)
    {
        if (!AssignTexture(buttonType))
        {
            Console.WriteLine("This Button Type does not support a texture");
        }

    }

    #region Functions

    public Texture2D GetPressedTexture()
    {
        return texturePressed;
    }

    public Texture2D GetUnPressedTexture()
    {
        return textureUnPressed;
    }

    public Texture2D GetDisabledTexture()
    {
        return textureDisabled;
    }
    public static bool AssignTexture(ButtonType buttonType)
    {
        try
        {
            switch (buttonType)
            {
                case ButtonType.BackButton:
                    textureUnPressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    texturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    textureDisabled = null;
                    return true;
                case ButtonType.QuitButton:
                    textureUnPressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    texturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    textureDisabled = null;
                    return true;
                case ButtonType.SettingsButton:
                    textureUnPressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    texturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    textureDisabled = null;
                    return true;
                default:
                    return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

    #endregion Functions

}