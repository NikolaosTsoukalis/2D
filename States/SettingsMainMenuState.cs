using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.VisualBasic;

namespace _2D_RPG;
public class SettingsMainMenuState : State 
{


    private List<Component> components;
    Button windowFormatButton;
    
    public SettingsMainMenuState(Main main) : base (main)
    {
        var controlsButton = new Button(content.Load<Texture2D>("Button_Controls"))
        {
            Position = new Vector2(300, 200),
        };

        controlsButton.Click += ControlsButton_Click;

        windowFormatButton = new Button(null)
        {
            Position = new Vector2(300,250)
        };
        GetWindowFormatButton();

        windowFormatButton.Click += WindowFormatButton_Click;
    
        var backButton = new Button(content.Load<Texture2D>("Button_Back"))
        {
            Position = new Vector2(300, 300),
        };

        backButton.Click += BackButton_Click;
    
        components = new List<Component>()
        {
            controlsButton,
            windowFormatButton,
            backButton,
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
        if(Globals._graphics.IsFullScreen)
        {
            Globals._graphics.IsFullScreen = false;
            windowFormatButton.Texture = GetWindowFormatButton();
        }
        else if(main.Window.IsBorderless)
        {
            main.Window.IsBorderless = false;
            Globals._graphics.IsFullScreen = true;
            windowFormatButton.Texture = GetWindowFormatButton();
        }
        else
        {
            main.Window.IsBorderless = true;
            windowFormatButton.Texture = GetWindowFormatButton();

        }
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        main.ChangeState(new MainMenuState(main));
    }

    public Texture2D GetWindowFormatButton()
    {
        if(Globals._graphics.IsFullScreen)
        {
            return windowFormatButton.Texture = content.Load<Texture2D>("Button_WindowFormat_Fullscreen");
        }
        else if(main.Window.IsBorderless)
        {
            return windowFormatButton.Texture = content.Load<Texture2D>("Button_WindowFormat_Borderless");
        }
        else
        {
            return windowFormatButton.Texture = content.Load<Texture2D>("Button_WindowFormat_Windowed");
        }
    }
}