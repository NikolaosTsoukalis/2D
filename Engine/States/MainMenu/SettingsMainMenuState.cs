/* using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
///<Summary>
/// settings state for volume etc
///</Summary>
public class SettingsMainMenuState : State 
{
    private List<ComponentBase> components;
    Button windowFormatButton;
    Button backButton;
    
    ///<Summary>
    /// constructor for all the buttons in settings
    ///</Summary>
    public SettingsMainMenuState(Main main) : base (main)
    {
        
        var controlsButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Controls"), new Vector2(300, 200));

        controlsButton.Click += ControlsButton_Click;

        windowFormatButton = new Button(null, new Vector2(300, 250));

        GetWindowFormatButton();

        windowFormatButton.Click += WindowFormatButton_Click;

        backButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Back"), new Vector2(300, 300));

        backButton.Click += BackButton_Click;
    
        components = new List<Component>()
        {
            controlsButton,
            windowFormatButton,
            backButton,
        };
        
    }

    ///<Summary>
    /// Update
    ///</Summary>
    public override void Update(GameTime gameTime)
    {
        foreach (var component in components)
            component.Update(gameTime);
    }

    ///<Summary>
    /// Post Update
    ///</Summary>
    public override void PostUpdate(GameTime gameTime){}

    ///<Summary>
    /// Draw
    ///</Summary>
    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Begin();

        foreach (var component in components)
            component.Draw(gameTime);

        Globals.SpriteBatch.End();
    }

    private void ControlsButton_Click(object sender, EventArgs e)
    {
        components = new List<ComponentBase>()
        {
            backButton,
        };
    }

    private void WindowFormatButton_Click(object sender, EventArgs e)
    {
        if(Globals.GraphicsDeviceManager.IsFullScreen)
        {
            Globals.GraphicsDeviceManager.IsFullScreen = false;
            Globals.GraphicsDeviceManager.PreferredBackBufferHeight = 640;
            Globals.GraphicsDeviceManager.PreferredBackBufferWidth = 800;
            Globals.GraphicsDeviceManager.ApplyChanges();
            windowFormatButton.Texture = GetWindowFormatButton();
        }
        else if(main.Window.IsBorderless)
        {
            main.Window.IsBorderless = false;
            Globals.GraphicsDeviceManager.IsFullScreen = true;
            Globals.GraphicsDeviceManager.ApplyChanges();
            windowFormatButton.Texture = GetWindowFormatButton();
        }
        else
        {
            main.Window.IsBorderless = true;
            Globals.GraphicsDeviceManager.PreferredBackBufferHeight = 1080;
            Globals.GraphicsDeviceManager.PreferredBackBufferWidth = 1920;
            Globals.GraphicsDeviceManager.ApplyChanges();
            windowFormatButton.Texture = GetWindowFormatButton();

        }
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        if(main.currentGameState == new SettingsMainMenuState(main))
            main.ChangeState(new SettingsMainMenuState(main));
        else
            main.ChangeState(new MainMenuState(main));
    }

    ///<Summary>
    /// window setting
    ///</Summary>
    public Texture2D GetWindowFormatButton()
    {
        if(Globals.GraphicsDeviceManager.IsFullScreen)
        {
            return windowFormatButton.Texture = Globals.ContentManager.Load<Texture2D>("Button_WindowFormat_Fullscreen");
        }
        else if(main.Window.IsBorderless)
        {
            return windowFormatButton.Texture = Globals.ContentManager.Load<Texture2D>("Button_WindowFormat_Borderless");
        }
        else
        {
            return windowFormatButton.Texture = Globals.ContentManager.Load<Texture2D>("Button_WindowFormat_Windowed");
        }
    }
} */