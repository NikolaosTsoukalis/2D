using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class WorldListMainMenuState : State
{
    
    private List<Component> components;

    private Vector2 firstButtonPosition;
    private Vector2 lastButtonPosition;

    private string[] worldList;

    public WorldListMainMenuState(Main main) : base(main)
    {

        firstButtonPosition = new Vector2(300,200);
        lastButtonPosition = firstButtonPosition;
        worldList = Utillity.GetWorldFiles();
        components = new List<Component>();
        /*
        var startGameButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_StartGame"))
        {
            Position = new Vector2(300, 200),
        };

        startGameButton.Click += StartGameButton_Click;
        */
        var newWorldButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_NewWorld"))
        {
            Position = firstButtonPosition,
        };
        components.Add(newWorldButton);
        newWorldButton.Click += newWorldButton_Click;

        /*
        var settingsButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Settings"))
        {
            Position = new Vector2(300, 250),
        };

        settingsButton.Click += SettingsButton_Click;
        */
        var backButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Back"))
        {
            Position = new Vector2(300, 300),
        };
        components.Add(backButton);
        backButton.Click += BackButton_Click;
    }

    #region General Functions

    public List<Component> manageWorldButtons()
    {

        for(int i = 0; i < worldList.Length; i++)
        {
            components.Add(new Button(Globals.ContentManager.Load<Texture2D>("Button_Empty")){ Position = lastButtonPosition});   
        }
        return null;
    }

    #endregion General Functions

    #region Component Functions

    private void BackButton_Click(object sender, EventArgs e)
    {
        if(main.currentGameState == new WorldListMainMenuState(main))
            main.ChangeState(new MainMenuState(main));
        else
            main.ChangeState(new MainMenuState(main));
    }

    private void newWorldButton_Click(object sender, EventArgs e)
    {
        if(worldList.Length > 10){}
    }

    #endregion Component Functions 

    #region GameLoop Functions

    public override void Update(GameTime gameTime)
    {
        foreach (var component in components)
        {
            component.Update(gameTime);    
        }   
    }

    public override void PostUpdate(GameTime gameTime)
    {
        // remove sprites if they're not needed
    }

    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Begin();

        foreach (var component in components)
        {
            component.Draw(gameTime);
        }
        Globals.SpriteBatch.End();
    }

    #endregion GameLoop Functions
}