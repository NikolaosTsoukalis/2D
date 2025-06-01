using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class WorldListMainMenuState : State
{
    
    private List<Component> components;

    private Vector2 firstButtonPosition;
    private Vector2 nextButtonPosition;
    private Vector2 lastButtonPosition;
    private Button newWorldButton;
    private Button backButton;
    private string WorldClicked;

    private string[] worldList;

    public WorldListMainMenuState(Main main) : base(main)
    {
        
        firstButtonPosition = new Vector2(300,200);
        nextButtonPosition = new Vector2(firstButtonPosition.X,firstButtonPosition.Y+50);
        lastButtonPosition = nextButtonPosition;
        worldList = Utillity.GetWorldFileNames(true);
        components = new List<Component>();
        
        newWorldButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_NewWorld"), firstButtonPosition);
        components.Add(newWorldButton);
        if (worldList.Length > 10)
        {
            newWorldButton.Disable();
        }
        else
        {
            newWorldButton.Enable();
        }
        newWorldButton.Click += newWorldButton_Click;

        HandleWorldButtons();

        backButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Back"), lastButtonPosition);
        components.Add(backButton);
        backButton.Click += BackButton_Click;
    }

    #region General Functions

    public void HandleWorldButtons()
    {
        try
        {
            if (worldList.Length > 0)
            {
                for (int i = 0; i < worldList.Length; i++)
                {
                    var WorldButton = new Button(Globals.ContentManager.Load<Texture2D>("Button_Empty"), nextButtonPosition) { Text = worldList[i].ToString() };
                    components.Add(WorldButton);
                    WorldClicked = WorldButton.Text;
                    WorldButton.Click += loadWorldButton_Click;

                    nextButtonPosition.Y += 50;
                    //backButton.Position.Y += 50;
                }
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
        }

    }

    #endregion General Functions

    #region Component Functions

    private void BackButton_Click(object sender, EventArgs e)
    {
        main.ChangeState(new MainMenuState(main));
    }

    private void newWorldButton_Click(object sender, EventArgs e)
    {
        if (newWorldButton.isEnabled())
        {
            string name = "test";
            if (!worldList.Contains(name))
            {
                Utillity.createTileMapFiles("test");
                HandleWorldButtons();
            }
        }
        else
        {
            return;
        }
    }

    private void loadWorldButton_Click(object sender, EventArgs e)
    {  
        int [,]tileMapMatrix = Utillity.GetWorldBinaryFile(WorldClicked, true);
        TileMap tileMap = new TileMap(tileMapMatrix);
        main.ChangeState(new GameState(main,tileMap));
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