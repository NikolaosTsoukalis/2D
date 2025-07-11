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

    public Dictionary<GlobalEnumarations.TextureLibraryUI,Vector2> UITextBoxPositionMap { get; private set;}

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

    public Vector2 GetTextBoxPosition(GlobalEnumarations.TextureLibraryUI textureType)
    {

        if (UITextBoxPositionMap.TryGetValue(textureType, out Vector2 position))
        {
            return position;
        }
        return Vector2.Zero;

    }

    public Vector2 GetTextBoxPosition(Texture2D texture)
    {
        if (UITextBoxPositionMap.TryGetValue(TextureLibraryUI.FirstOrDefault(x => x.Value == texture).Key, out Vector2 position))
        {
            return position;    
        }
        return Vector2.Zero;

    }

    public bool LoadTextBoxPositionMap()
    {
        try
        {
            UITextBoxPositionMap = new Dictionary<GlobalEnumarations.TextureLibraryUI, Vector2>()
            {
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Free, new Vector2(116, 40) },
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Pressed, new Vector2(116, 40) },
                { GlobalEnumarations.TextureLibraryUI.Bottom_Button_Disabled, new Vector2(116, 40) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Free, new Vector2(116, 40) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Pressed, new Vector2(116, 40) },
                { GlobalEnumarations.TextureLibraryUI.Middle_Button_Disabled, new Vector2(116, 40) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Free, new Vector2(108, 40) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Pressed, new Vector2(108, 40) },
                { GlobalEnumarations.TextureLibraryUI.Top_Button_Disabled, new Vector2(108, 40) }
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
            UITextBoxPositionMap = null;
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