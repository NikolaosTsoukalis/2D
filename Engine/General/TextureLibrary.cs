using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;


// TRIPLET OF LOAD/UNLOAD/GETTEXTURE
public class TextureLibrary
{
    private Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D> TextureLibraryButton { get; set; }
    private Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D> TextureLibraryTextBox { get; set; }

    public Dictionary<GlobalEnumarations.TextureLibraryUI, Int4> UITextBoxPaddingMap { get; private set; }

    public TextureLibrary()
    {
        LoadButtonTextures();
        LoadTextBoxTextures();
    }

    #region UI TEXTURES

    public Texture2D GetUITexture(GlobalEnumarations.TextureLibraryUI textureType)
    {
        if (TextureLibraryButton.TryGetValue(textureType, out Texture2D buttonTexture))
        {
            return buttonTexture;
        }

        if (TextureLibraryTextBox.TryGetValue(textureType, out Texture2D textBoxTexture))
        {
            return textBoxTexture;
        }

        return null;

    }

    public bool LoadButtonTextures()
    {
        try
        {
            TextureLibraryButton = new Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D>()
            {
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Bottom_Button_Free") },
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Pressed, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Bottom_Button_Pressed") },
            //TextureLibrary.Add(GlobalEnumarations.TextureLibraryUI.Bottom_Button_Pressed, ContentManager.Load<Texture2D>("ComponentTextures/Button/Bottom_Button_Pressed"));
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Free") },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Pressed, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed") },
            //TextureLibrary.Add(GlobalEnumarations.TextureLibraryUI.Middle_Button_Free, ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed"));
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Top_Button_Free") },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Pressed, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Top_Button_Pressed") }
                //TextureLibrary.Add(GlobalEnumarations.TextureLibraryUI.Top_Button_Free, ContentManager.Load<Texture2D>("ComponentTextures/Button/Top_Button_Pressed"));
            };
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

    public bool LoadTextBoxTextures()
    {
        try
        {
            TextureLibraryButton = new Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D>()
            {
                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Big_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Middle_TextBox_Big_Free") },
                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Big_Disabled, Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Middle_TextBox_Big_Disabled") },

                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Small_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Middle_TextBox_Small_Free") },
                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Small_Disabled, Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Middle_TextBox_Small_Disabled") }
            };
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

    public bool UnloadUITextures()
    {
        try
        {
            foreach (Texture2D texture in TextureLibraryButton.Values)
            {
                Globals.ContentManager.UnloadAsset(texture.Name);
                TextureLibraryButton = null;
            }
            foreach (Texture2D texture in TextureLibraryTextBox.Values)
            {
                Globals.ContentManager.UnloadAsset(texture.Name);
                TextureLibraryButton = null;
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return false;
        }
    }

    public Int4 GetTextBoxPadding(GlobalEnumarations.TextureLibraryUI textureType)
    {

        if (UITextBoxPaddingMap.TryGetValue(textureType, out Int4 padding))
        {
            return padding;
        }
        return new Int4(0, 0, 0, 0);

    }

    public Int4 GetTextBoxPadding(Texture2D texture)
    {
        Int4 padding;
        if (UITextBoxPaddingMap.TryGetValue(TextureLibraryButton.FirstOrDefault(x => x.Value == texture).Key, out padding))
        {
            return padding;
        }
        
        if (UITextBoxPaddingMap.TryGetValue(TextureLibraryTextBox.FirstOrDefault(x => x.Value == texture).Key, out padding))
        {
            return padding;
        }
        return new Int4(0, 0, 0, 0);

    }

    public bool LoadTextBoxPaddingMap()
    {
        try
        {
            //
            UITextBoxPaddingMap = new Dictionary<GlobalEnumarations.TextureLibraryUI, Int4>()
            {
                //Button Textures
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Free,       new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Pressed,    new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Disabled,   new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Free,       new Int4(20, 18, 20, 17) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Pressed,    new Int4(20, 18, 20, 17) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Disabled,   new Int4(20, 18, 20, 17) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Free,          new Int4(20, 34, 20, 19) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Pressed,       new Int4(20, 34, 20, 19) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Disabled,      new Int4(20, 34, 20, 19) },

                //TextBox Textures
                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Big_Free,          new Int4(10, 10, 10, 10) },
                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Big_Disabled,      new Int4(10, 10, 10, 10) },
                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Small_Free,        new Int4(10, 10, 10, 10) },
                { GlobalEnumarations.TextureLibraryUI.Middle_TextBox_Small_Disabled,    new Int4(10, 10, 10, 10) },
            };

            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }
    
    public bool UnloadTextBoxPositionMap()
    {
        try
        {
            UITextBoxPaddingMap = null;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return false;
        }
    }

    #endregion

    #region PLAYER TEXTURES

    public bool LoadPlayerTextures() // TO DO
    {
        try
        {
            /*    UITextureLibrary.Add(GlobalEnumarations.TextureLibrary.Bottom_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Bottom_Button_Free"));
               UITextureLibrary.Add(GlobalEnumarations.TextureLibrary.Bottom_Button_Pressed, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Bottom_Button_Pressed"));
               //TextureLibrary.Add(GlobalEnumarations.TextureLibrary.Bottom_Button_Pressed, ContentManager.Load<Texture2D>("ComponentTextures/Button/Bottom_Button_Pressed"));
               UITextureLibrary.Add(GlobalEnumarations.TextureLibrary.Middle_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Free"));
               UITextureLibrary.Add(GlobalEnumarations.TextureLibrary.Middle_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed"));
               //TextureLibrary.Add(GlobalEnumarations.TextureLibrary.Middle_Button_Free, ContentManager.Load<Texture2D>("ComponentTextures/Button/Middle_Button_Pressed"));
               UITextureLibrary.Add(GlobalEnumarations.TextureLibrary.Top_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Top_Button_Free"));
               UITextureLibrary.Add(GlobalEnumarations.TextureLibrary.Top_Button_Free, Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Top_Button_Pressed"));
             */   //TextureLibrary.Add(GlobalEnumarations.TextureLibrary.Top_Button_Free, ContentManager.Load<Texture2D>("ComponentTextures/Button/Top_Button_Pressed"));

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

    #endregion
}