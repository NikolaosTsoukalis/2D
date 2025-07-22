using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

///<Summary>
/// main menu state to access the settings, the game and everything else
///</Summary>
public class MainMenuState : State
{

    ///<Summary>
    /// Constructor of main menu state with buttons for settings play game etc
    ///</Summary>
    public MainMenuState(Main main) : base(main)
    {
        ManageTextureLibrary();
        InitializeHandlers(main);
        //initillize with landing menu
        Globals.MenuHandler.AddMenuToStackTop(MenuBuilder.BuildMainMenuLandingMenu());
    }

    ///<Summary>
    /// draw buttons of settings
    ///</Summary>
    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Begin();

        CallDrawFuctions(gameTime);

        Globals.SpriteBatch.End();
    }

    ///<Summary>
    /// Update
    ///</Summary>
    public override void Update(GameTime gameTime)
    {
        Globals.MenuHandler.Update(gameTime);
    }

    ///<Summary>
    /// post updates
    ///</Summary>
    public override void PostUpdate(GameTime gameTime)
    {
        // remove sprites if they're not needed
    }

    public override bool InitializeHandlers(Main main)
    {
        try
        {
            Globals.MenuHandler = new MenuHandler(main);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR ON INITIALLIZING HANDLERS: " + e);
            return false;
        }
    }

    public override bool ManageTextureLibrary()
    {
        try
        {
            if (Globals.TextureLibrary.LoadUITextures() && Globals.TextureLibrary.LoadTextBoxPaddingMap())
            {
                return true;
            }
            else
            {
                Console.WriteLine("Texture Library Load failed");
            }
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR ON Loading TextureLibrary: " + e);
            return false;
        }
    }

    public override bool CallDrawFuctions(GameTime gameTime)
    {
        try
        {
            if (Globals.enableDebugs)
            {
                //Globals.MenuHandler.Draw(gameTime);
                Debugger.DrawMainMenuState(gameTime);
            }
            else
            {
                Globals.MenuHandler.Draw(gameTime);
            }

            if (Globals.drawInteraction)
            {
                Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), "FUCK OFF!", new Vector2(200, 300), Color.White);
            }
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }
}
