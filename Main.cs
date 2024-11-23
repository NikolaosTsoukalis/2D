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

    private AnimationHandler animationHandler;

    public Main()
    {
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
        Globals._graphics = new GraphicsDeviceManager(this);
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        animationHandler = new AnimationHandler();
        inputhandler = new InputHandler();
        player = new MovingEntity("Player",Globals.content.Load<Texture2D>("testSpriteWalk_strip32"),Vector2.Zero);
        Globals.UpdateEntityList(true,player);
        animationHandler.addNewAnimation(new Animation(player));

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        Globals.Update(gameTime);
        animationHandler.handleAnimation(false);
        command = inputhandler.HandleInput();
        if(command != null)
        {
            if(command.ToString() == "ExitCommand")
            {
                command.Execute(this);
            } 
            command.Execute(player);
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        animationHandler.handleAnimation(true);

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}
