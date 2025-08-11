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

    public int TextureWidth { get; private set; }
    public int TextureHeight { get; private set; }

    public ComponentBase ParentComponent { get; private set; }
    public GlobalEnumarations.TextureLibraryUI TextureType { get; private set; }

    public ComponentTextureHandler(GlobalEnumarations.TextureLibraryUI textureType, ComponentBase parentComponent)
    {
        ParentComponent = parentComponent;
        TextureType = textureType;
        if (!SetTextures(textureType) || !SetCurrentTexture(GlobalEnumarations.ComponentState.Free))
        {
            Console.WriteLine("The component '" + textureType.ToString() + "' was not initiallized correctly.");
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
        TextureWidth = CurrentTexture.Width;
        TextureHeight = CurrentTexture.Height;

        if (CurrentTexture == null || TextureWidth == 0 || TextureHeight == 0)
        {
            Console.WriteLine("The texture for the state: '" + componentState.ToString() + "' does not exist.");
            return false;
        }
        return true;
    }

    private bool SetTextures(GlobalEnumarations.TextureLibraryUI textureType)
    {
        try
        {
            Texture2D texture = Globals.TextureLibrary.GetUITexture(textureType);
            if (textureType.ToString().Contains("Free"))
            {
                TextureFree = texture;
                SetCurrentTexture(GlobalEnumarations.ComponentState.Free);
                return true;
            }
            else if (textureType.ToString().Contains("Pressed"))
            {
                TexturePressed = texture;
                SetCurrentTexture(GlobalEnumarations.ComponentState.Pressed);
                return true;
            }
            else if (textureType.ToString().Contains("Disabled"))
            {
                TextureDisabled = texture;
                SetCurrentTexture(GlobalEnumarations.ComponentState.Disabled);
                return true;
            }
            TextureFree = null;
            TexturePressed = null;
            TextureDisabled = null;
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR while setting texture for '" + this.ParentComponent.GetType().ToString() +  "' : " + e);
            return false;
        }
    }
    #endregion Functions

}