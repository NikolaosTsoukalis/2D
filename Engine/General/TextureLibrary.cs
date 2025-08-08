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
    private Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D> TextureLibraryMenu { get; set; }

    public Dictionary<GlobalEnumarations.TextureLibraryUI, List<Int2>> UITextBoxPaddingMap { get; private set; }

    public TextureLibrary()
    {
        LoadButtonTextures();
        LoadTextBoxTextures();
        LoadMenuTextures();
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
                //Type Long
                {GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Self/Button_Free_Type_L")},
                {GlobalEnumarations.TextureLibraryUI.Button_Pressed_Type_L,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Self/Button_Pressed_Type_L")},
                {GlobalEnumarations.TextureLibraryUI.Button_Disabled_Type_L,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Self/Button_Disabled_Type_L")},

                //Type Short
                {GlobalEnumarations.TextureLibraryUI.Button_Free_Type_S,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Self/Button_Free_Type_S")},
                {GlobalEnumarations.TextureLibraryUI.Button_Pressed_Type_S,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Self/Button_Pressed_Type_S")},
                {GlobalEnumarations.TextureLibraryUI.Button_Disabled_Type_S,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Button/Self/Button_Disabled_Type_S")},

            };
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR on TextureLibraryButton load: " + e);
            return false;
        }
    }

    public bool LoadTextBoxTextures()
    {
        try
        {
            TextureLibraryTextBox = new Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D>()
            {
                //Type Long
                { GlobalEnumarations.TextureLibraryUI.TextBox_Free_Type_L,Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Self/TextBox_Free_Type_L")},
                { GlobalEnumarations.TextureLibraryUI.TextBox_Pressed_Type_L,Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Self/TextBox_Pressed_Type_L")},

                //Type Short
                { GlobalEnumarations.TextureLibraryUI.TextBox_Free_Type_S,Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Self/TextBox_Free_Type_S")},
                { GlobalEnumarations.TextureLibraryUI.TextBox_Pressed_Type_S,Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Self/TextBox_Pressed_Type_S")},

                //Type Big
                { GlobalEnumarations.TextureLibraryUI.TextBox_Free_Type_B,Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Self/TextBox_Free_Type_B")},
                { GlobalEnumarations.TextureLibraryUI.TextBox_Pressed_Type_B,Globals.ContentManager.Load<Texture2D>("ComponentTextures/TextBox/Self/TextBox_Pressed_Type_B")},

            };
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR on TextureLibraryTextBox load : " + e);
            return false;
        }
    }

    public bool LoadMenuTextures()
    {
        try
        {
            TextureLibraryMenu = new Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D>()
            {
                //Type Long
                { GlobalEnumarations.TextureLibraryUI.MainMenu,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Menu/MainMenu")},
                { GlobalEnumarations.TextureLibraryUI.CreateWorldMenu,Globals.ContentManager.Load<Texture2D>("ComponentTextures/Menu/CreateWorldMenu")},
            };
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR on TextureLibraryTextBox load : " + e);
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
                TextureLibraryTextBox = null;
            }
            foreach (Texture2D texture in TextureLibraryMenu.Values)
            {
                Globals.ContentManager.UnloadAsset(texture.Name);
                  
            }
            TextureLibraryTextBox = null;
            TextureLibraryButton = null;
            TextureLibraryMenu = null;  
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR on TextureLibraryUI unload: " + e);
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
            UITextBoxPaddingMap = new Dictionary<GlobalEnumarations.TextureLibraryUI, List<Int2>>()
            {
                {GlobalEnumarations.TextureLibraryUI.MainMenu, new List<Int2>({ new Int2(10, 10) }) },
                { GlobalEnumarations.TextureLibraryUI.Button_Disabled_Type_L,   new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Button_Free_Type_L,       new Int4(20, 18, 20, 28) },

                { GlobalEnumarations.TextureLibraryUI.Button_Free_Type_S,       new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Button_Disabled_Type_S,   new Int4(20, 18, 20, 17) },
            };

            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR on UITextBoxPaddingMap load: " + e);
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
            Console.WriteLine("ERROR on UITextBoxPaddingMap unload: " + e);
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