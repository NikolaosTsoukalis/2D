using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class MainMenuState : State
{
    private List<Component> components;

    public MainMenuState(Main main) : base(main)
    {

        var startGameButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_StartGame"))
        {
            Position = new Vector2(300, 200),
        };

        startGameButton.Click += StartGameButton_Click;

        var settingsButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Settings"))
        {
            Position = new Vector2(300, 250),
        };

        settingsButton.Click += SettingsButton_Click;

        var quitGameButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Exit"))
        {
            Position = new Vector2(300, 300),
        };

        quitGameButton.Click += QuitGameButton_Click;

        components = new List<Component>()
        {
            startGameButton,
            settingsButton,
            quitGameButton,
        };
    }

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
        main.ChangeState(new GameState(main));
    }

    public override void PostUpdate(GameTime gameTime)
    {
        // remove sprites if they're not needed
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var component in components)
            component.Update(gameTime);
    }

    private void QuitGameButton_Click(object sender, EventArgs e)
    {
        main.Exit();
    }
}
