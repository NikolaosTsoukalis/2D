using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        
        var newWorldButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_NewWorld"))
        {
            Position = firstButtonPosition,
        };
        components.Add(newWorldButton);
        newWorldButton.Click += newWorldButton_Click;

        createWorldButtons();
        newWorldButton.Click += newWorldButton_Click;

        var backButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Back"))
        {
            Position = new Vector2(300, 300),
        };
        components.Add(backButton);
        backButton.Click += BackButton_Click;
    }

    #region General Functions

    public void createWorldButtons()
    {
        try
        {
            if(worldList.Length > 0)
            {
                for(int i = 0; i < worldList.Length; i++)
                {
                    components.Add(new Button(Globals.ContentManager.Load<Texture2D>("Button_Empty")){ Position = lastButtonPosition, Text = worldList[i].ToString()});   
                    components[i].Click += 
                    lastButtonPosition.Y += 50;
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }

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

    private void loadWorldButton_Click(object sender, EventArgs e)
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