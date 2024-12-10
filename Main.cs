using System;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Main : Game
{
    private InputHandler inputhandler;
    private Command command;

    private AnimationHandler animationHandler;

    readonly MovingEntity player = new MovingEntity("Player",null,Vector2.Zero);
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
        Globals.LoadAnimationDictionary();
        animationHandler = new AnimationHandler();
        inputhandler = new InputHandler();
        Globals.AddEntityToList(player);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        Globals.Update(gameTime);
        animationHandler.Update(Globals.EntityList);
        animationHandler.handleAnimation(false);
        command = inputhandler.HandleInput();
        if(command != null)
        {
            if(command.ToString() == "ExitCommand" || command.ToString() == "FullScreenCommand")
            {
                command.Execute(this);
            } 
            command.Execute(player);
        }
        else
            player.ActionIdentifier = "Idle";
            
        //inputhandler.Update();
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
