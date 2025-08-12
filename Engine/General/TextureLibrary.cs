using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;


// TRIPLET OF LOAD/UNLOAD/GETTEXTURE
public class TextureLibrary
{
    private Dictionary<GlobalEnumarations.TextureLibraryUI, TextureBundle> TextureLibraryButton { get; set; }
    private Dictionary<GlobalEnumarations.TextureLibraryUI, TextureBundle> TextureLibraryTextBox { get; set; }
    private Dictionary<GlobalEnumarations.TextureLibraryUI, TextureBundle> TextureLibraryMenu { get; set; }

    public Dictionary<GlobalEnumarations.TextureLibraryUI, Int4> UITextBoxPaddingMap { get; private set; }

    public TextureLibrary()
    {
        LoadButtonTextures();
        LoadTextBoxTextures();
        LoadMenuTextures();
        LoadUITextBoxPaddingMap();
    }

    #region UI TEXTURES

    public TextureBundle? GetUITextureBundle(GlobalEnumarations.TextureLibraryUI textureType)
    {
        if (TextureLibraryButton.TryGetValue(textureType, out TextureBundle buttonTexture))
        {
            return buttonTexture;
        }

        if (TextureLibraryTextBox.TryGetValue(textureType, out TextureBundle textBoxTexture))
        {
            return textBoxTexture;
        }
        if (TextureLibraryMenu.TryGetValue(textureType, out TextureBundle menuTexture))
        {
            return menuTexture;
        }

        return null;

    }

    public bool LoadButtonTextures()
    {
        try
        {
            TextureLibraryButton = new Dictionary<GlobalEnumarations.TextureLibraryUI, TextureBundle>()
            {
                //Type Long
                {GlobalEnumarations.TextureLibraryUI.Button_Type_L, LoadBundle("ComponentTextures/Button/Self/Button","Type_L")},
                //Type Short
                {GlobalEnumarations.TextureLibraryUI.Button_Type_S, LoadBundle("ComponentTextures/Button/Self/Button","Type_S")}
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
            TextureLibraryTextBox = new Dictionary<GlobalEnumarations.TextureLibraryUI, TextureBundle>()
            {
                //Type Long
                { GlobalEnumarations.TextureLibraryUI.TextBox_Type_L, LoadBundle("ComponentTextures/TextBox/Self/TextBox","Type_L")},

                //Type Short
                { GlobalEnumarations.TextureLibraryUI.TextBox_Type_S,LoadBundle("ComponentTextures/TextBox/Self/TextBox","Type_S")},

                //Type Big
                { GlobalEnumarations.TextureLibraryUI.TextBox_Type_B, LoadBundle("ComponentTextures/TextBox/Self/TextBox","Type_B")}
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
            TextureLibraryMenu = new Dictionary<GlobalEnumarations.TextureLibraryUI, TextureBundle>()
            {
                //Type Long
                { GlobalEnumarations.TextureLibraryUI.MainMenu, 
                    new TextureBundle
                    (
                        Globals.ContentManager.Load<Texture2D>("ComponentTextures/Menu/MainMenu"),null,null
                    )
                },
                { GlobalEnumarations.TextureLibraryUI.CreateWorldMenu,
                    new TextureBundle
                    (
                        Globals.ContentManager.Load<Texture2D>("ComponentTextures/Menu/CreateWorldMenu"),null,null
                    )

                },
            };

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR on TextureLibraryTextBox load : " + e);
            return false;
        }
    }

/*
            public bool UnloadUITextureLibraries()
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
            */

    public void LoadUITextBoxPaddingMap()
    {
        try
        {
            UITextBoxPaddingMap = new Dictionary<GlobalEnumarations.TextureLibraryUI, Int4>
            {
                {GlobalEnumarations.TextureLibraryUI.Button_Type_L,    new Int4(8,8,8,8)},
                {GlobalEnumarations.TextureLibraryUI.Button_Type_S,    new Int4(8,8,8,8)},
            };
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR loading UITextBoxPaddingMap : " + e);
        }
    }

    public Int4 GetTextBoxPadding(GlobalEnumarations.TextureLibraryUI parentTexture)
    {
        try
        {
            UITextBoxPaddingMap.TryGetValue(parentTexture, out var padding);

            return padding;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR getting TextBoxPadding: " + e);
            return new Int4(0, 0, 0, 0);    
        }
    }
    
    private TextureBundle LoadBundle(string basePath, string type)
    {
        return new TextureBundle
        (
            Globals.ContentManager.Load<Texture2D>($"{basePath}_Free_{type}"),
            Globals.ContentManager.Load<Texture2D>($"{basePath}_Pressed_{type}"),
            Globals.ContentManager.Load<Texture2D>($"{basePath}_Disabled_{type}")
        );
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