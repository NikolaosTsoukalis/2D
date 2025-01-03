using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
public class SettingsMainMenuState : State 
{

    private List<Component> components;
    
    public SettingsMainMenuState(Main main) : base (main)
    {
        var controlsButton = new Button(content.Load<Texture2D>("Button_StartGame"))
        {
            Position = new Vector2(300, 200),
        };

        controlsButton.Click += ControlsButton_Click;

        var windowFormatButton = new Button(content.Load<Texture2D>("Button_Settings"))
        {
            Position = new Vector2(300, 250),
        };

        windowFormatButton.Click += WindowFormatButton_Click;
    /*
        var quitGameButton = new Button(content.Load<Texture2D>("Button_Exit"))
        {
            Position = new Vector2(300, 300),
        };

        quitGameButton.Click += QuitGameButton_Click;
    */
        components = new List<Component>()
        {
            controlsButton,
            windowFormatButton,
            //quitGameButton,
        };
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var component in components)
            component.Update(gameTime);
    }

    public override void PostUpdate(GameTime gameTime){}

    public override void Draw(GameTime gameTime)
    {
        Globals.spriteBatch.Begin();

        foreach (var component in components)
            component.Draw(gameTime);

        Globals.spriteBatch.End();
    }

    private void ControlsButton_Click(object sender, EventArgs e)
    {
        //main.ChangeState(new GameState(main));
    }

    private void WindowFormatButton_Click(object sender, EventArgs e)
    {
        //main.ChangeState(new GameState(main));
    }
}