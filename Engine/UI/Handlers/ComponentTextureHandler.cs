using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;


public class ComponentTextureHandler
{
    public Texture2D TextureFree { get; private set; }
    public Texture2D TexturePressed { get; private set; }
    public Texture2D TextureDisabled { get; private set; }
    public Texture2D CurrentTexture { get; private set; }
    public static ComponentBase ParentComponent { get; private set; }

    public GlobalEnumarations.TextureLibraryUI TextureType { get; private set; }

    public ComponentTextureHandler(GlobalEnumarations.ComponentType componentType, ComponentBase parentComponent)
    {
        ParentComponent = parentComponent;
        if (!SetTextures(componentType) || !SetCurrentTexture(GlobalEnumarations.ComponentState.Free))
        {
            Console.WriteLine("The component '" + componentType.ToString() + "' was not initiallized correctly.");
        }
    }

    #region Functions

    public bool SetCurrentTexture(GlobalEnumarations.ComponentState componentState)
    {
        CurrentTexture = null;
        switch (componentState)
        {
            case GlobalEnumarations.ComponentState.Free:
                CurrentTexture = TextureFree;
                break;
            case GlobalEnumarations.ComponentState.Pressed:
                CurrentTexture = TexturePressed;
                break;
            case GlobalEnumarations.ComponentState.Disabled:
                CurrentTexture = TextureDisabled;
                break;
        }
        if (CurrentTexture == null)
        {
            Console.WriteLine("The texture for the state: '" + componentState.ToString() + "' does not exist.");
            return false;
        }
        return true;
    }

    private bool SetTextures(GlobalEnumarations.ComponentType componentType)
    {
        try
        {
            if (false) // this.LayoutType == String.Empty
            {
                switch (componentType)
                {
                    case GlobalEnumarations.ComponentType.BackButton:
                        TextureFree = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Free");
                        TexturePressed = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed");
                        TextureDisabled = null;
                        return true;
                    case GlobalEnumarations.ComponentType.NavigateStartGameMenuButton:
                        TextureFree = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Free");
                        TexturePressed = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed");
                        TextureDisabled = null;
                        return true;
                    case GlobalEnumarations.ComponentType.QuitButton:
                        TextureFree = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Free");
                        TexturePressed = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed");
                        TextureDisabled = null;
                        return true;
                    case GlobalEnumarations.ComponentType.NavigateMainMenuSettingsMenuButton:
                        TextureFree = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Free");
                        TexturePressed = Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed");
                        TextureDisabled = null;
                        return true;
                    default:
                        TextureFree = null;
                        TexturePressed = null;
                        TextureDisabled = null;
                        Console.WriteLine("The component type '" + componentType.ToString() + "' does not have any textures assigned.");
                        return false;
                }

            }
            else
            {
                if (ParentComponent.Type == GlobalEnumarations.ComponentType.Debug)
                {
                    TextureFree = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Middle_Button_Free);
                    TexturePressed = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Middle_Button_Pressed);
                    TextureDisabled = null;
                    SetCurrentTexture(GlobalEnumarations.ComponentState.Free);
                    return true;
                }
                TextureFree = null;
                TexturePressed = null;
                TextureDisabled = null;
                return true;
            }
        }

        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

    public bool SetPositionBasedComponentTextures(string layoutType, bool? firstOrLast)
    {
        try
        {
            switch (layoutType)
            {
                case "VerticalMainMenuLayoutBase":
                    if (firstOrLast == true)
                    {
                        TextureFree = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Top_Button_Free);
                        TexturePressed = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Top_Button_Pressed);
                        TextureDisabled = null;
                    }
                    else if (firstOrLast == false)
                    {
                        TextureFree = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Bottom_Button_Free);
                        TexturePressed = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Bottom_Button_Pressed);
                        TextureDisabled = null;
                    }
                    else
                    {
                        TextureFree = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Middle_Button_Free);
                        TexturePressed = Globals.TextureLibrary.GetUITexture(GlobalEnumarations.TextureLibraryUI.Middle_Button_Pressed);
                        TextureDisabled = null;
                    }
                    SetCurrentTexture(GlobalEnumarations.ComponentState.Free);
                    return true;
                case "test":
                    TextureFree = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TexturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TextureDisabled = null;
                    return true;

                default:
                    TextureFree = null;
                    TexturePressed = null;
                    TextureDisabled = null;
                    Console.WriteLine("The layout type '" + layoutType.ToString() + "' does not support a texture bundle.");
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