using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;


// TRIPLET OF LOAD/UNLOAD/GETTEXTURE
public class TextureLibrary
{
    private Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D> TextureLibraryUI { get; set; }

    public Dictionary<GlobalEnumarations.TextureLibraryUI,Int4> UITextBoxPaddingMap { get; private set;}

    public TextureLibrary()
    {
        LoadUITextures();
    }

    #region UI TEXTURES

    public Texture2D GetUITexture(GlobalEnumarations.TextureLibraryUI textureType)
    {
        if (TextureLibraryUI.TryGetValue(textureType, out Texture2D texture))
        {
            return texture;
        }
        return null;

    }

    public bool LoadUITextures()
    {
        try
        {
            TextureLibraryUI = new Dictionary<GlobalEnumarations.TextureLibraryUI, Texture2D>()
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

    public bool UnloadUITextures()
    {
        try
        {
            foreach (Texture2D texture in TextureLibraryUI.Values)
            {
                Globals.ContentManager.UnloadAsset(texture.Name);
                TextureLibraryUI = null;
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
        if (UITextBoxPaddingMap.TryGetValue(TextureLibraryUI.FirstOrDefault(x => x.Value == texture).Key, out Int4 padding))
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
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Free,       new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Pressed,    new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Disabled,   new Int4(20, 18, 20, 28) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Free,       new Int4(20, 18, 20, 17) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Pressed,    new Int4(20, 18, 20, 17) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Disabled,   new Int4(20, 18, 20, 17) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Free,          new Int4(20, 34, 20, 19) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Pressed,       new Int4(20, 34, 20, 19) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Disabled,      new Int4(20, 34, 20, 19) }
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