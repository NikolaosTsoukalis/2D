using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class Main : Game
{
    private InputHandler inputhandler;
    private Command command;
    private Entity player;

    public Main()
    {
        Globals._graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.content = this.Content;
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        player = new MovingEntity(Globals.content.Load<Texture2D>("testSpriteWalk_strip32"),Vector2.Zero);
        inputhandler = new InputHandler();
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        //var state = Keyboard.GetState(); 
        //InputManager.Update();
        Globals.Update(gameTime);
        command = inputhandler.HandleInput();
        if(command != null)
        {
            if(command.ToString() == "ExitCommand")
            {
                command.Execute(this);
            } 
            command.Execute(player);
        }

       // movement = new Movement(player.position, 3f);
        //player.position = movement.Update(gameTime);
        //player.Update();
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        player.Draw();


        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}
