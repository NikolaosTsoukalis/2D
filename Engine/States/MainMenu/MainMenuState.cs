using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

///<Summary>
/// main menu state to access the settings, the game and everything else
///</Summary>
public class MainMenuState : State
{
    private List<Component> components;

    ///<Summary>
    /// Constructor of main menu state with buttons for settings play game etc
    ///</Summary>
    public MainMenuState(Main main) : base(main)
    {
        //Menu menu = new Menu();
        var startGameButton = new Button(Globals.ContentManager.Load<Texture2D>("Top_Button_Unpressed"), new Vector2(300, 100)){ Text = "Start Game"};
        startGameButton.Click += StartGameButton_Click;

        var settingsButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Settings"),new Vector2(300, 250));

        settingsButton.Click += SettingsButton_Click;

        var quitGameButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Exit"), new Vector2(300, 300));

        quitGameButton.Click += QuitGameButton_Click;

        components = new List<Component>()
        {
            startGameButton,
            settingsButton,
            quitGameButton,
        };
    }

    ///<Summary>
    /// draw buttons of settings
    ///</Summary>
    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Begin();

        foreach (var component in components)
            component.Draw(gameTime);

        Globals.SpriteBatch.End();
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
        main.ChangeState(new SettingsMainMenuState(main));
    }

    
    private void StartGameButton_Click(object sender, EventArgs e)
    {
        main.ChangeState(new WorldListMainMenuState(main));
    }
    
    ///<Summary>
    /// post updates
    ///</Summary>
    public override void PostUpdate(GameTime gameTime)
    {
        // remove sprites if they're not needed
    }

    ///<Summary>
    /// Update
    ///</Summary>
    public override void Update(GameTime gameTime)
    {
        foreach (var component in components)
        {
            component.Update(gameTime);
        }
    }

    private void QuitGameButton_Click(object sender, EventArgs e)
    {
        main.Exit();
    }
}
