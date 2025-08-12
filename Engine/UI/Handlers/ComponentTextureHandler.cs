using System;
using System.Collections.Generic;
using System.Linq;
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
            char typeIdentifier = textureType.ToString().Last();
            TextureBundle? textureBundle = Globals.TextureLibrary.GetUITextureBundle(textureType);
            if (textureBundle.Equals(null))
            {
                TextureFree = null;
                TexturePressed = null;
                TextureDisabled = null;
                throw new Exception("ERROR while setting texture for '" + this.ParentComponent.GetType().ToString() + "' : TextureBundle did not initiallize.");
            }
            else
            {
                TextureFree = textureBundle.Value.TextureFree;
                TexturePressed = textureBundle.Value.TexturePressed;
                TextureDisabled = textureBundle.Value.TextureDisabled;
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR while setting texture for '" + this.ParentComponent.GetType().ToString() + "' : " + e);
            return false;
        }
    }
    #endregion Functions

}