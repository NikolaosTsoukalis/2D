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
        Globals.MenuHandler.AddMenuToStackTop(MenuBuilder.BuildMainMenuLandingMenu());
    }

    ///<Summary>
    /// draw buttons of settings
    ///</Summary>
    public override void Draw(GameTime gameTime)
    {
        Globals.MenuHandler.Draw(gameTime);
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

    public void ManageView()
    {

    }
}
