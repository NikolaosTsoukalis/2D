using System;
using System.Diagnostics.Contracts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;


public class ComponentTextureHandler
{   
    public Texture2D TextureFree { get; private set; }
    public Texture2D TexturePressed { get; private set; }
    public Texture2D TextureDisabled { get; private set; }
    public Texture2D CurrentTexture { get; private set; }

    public ComponentTextureHandler(ComponentType componentType)
    {
        if (!CreateTextures(componentType) || !SetCurrentTexture(ComponentState.Free))
        {
            Console.WriteLine("The component '" + componentType.ToString() +  "' was not initiallized correctly.");
        }
    }

    #region Functions

    protected bool SetCurrentTexture(ComponentState componentState)
    {
        CurrentTexture = null;
        switch (componentState)
        {
            case ComponentState.Free:
                CurrentTexture = TextureFree;
                break;
            case ComponentState.Clicked:
                CurrentTexture = TexturePressed;
                break;
            case ComponentState.Disabled:
                CurrentTexture = TextureDisabled;
                break;
        }
        if (CurrentTexture.Equals(null))
        {
            Console.WriteLine("The texture for the state: '" + componentState.ToString() + "' does not exist.");
            return false;
        }
        return true;
    }

    private bool CreateTextures(ComponentType componentType)
    {
        try
        {
            switch (componentType)
            {
                case ComponentType.BackButton:
                    TextureFree = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TexturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TextureDisabled = null;
                    return true;
                case ComponentType.StartGameButton:
                    TextureFree = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TexturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TextureDisabled = null;
                    return true;
                case ComponentType.QuitButton:
                    TextureFree = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TexturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TextureDisabled = null;
                    return true;
                case ComponentType.SettingsButton:
                    TextureFree = Globals.ContentManager.Load<Texture2D>("Button_Controls");
                    TexturePressed = Globals.ContentManager.Load<Texture2D>("Button_Controls");
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
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

    #endregion Functions

}