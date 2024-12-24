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
    #region Values
    private InputHandler inputhandler;
    private Command command;

    private AnimationHandler animationHandler;

    readonly MovingEntity player = new MovingEntity("Player",null,Vector2.Zero);

    #endregion Values

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    /// <remarks>
    /// This is the Main constructor
    /// </remarks>
    public Main()
    {
        
        Globals._graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";

        IsMouseVisible = true;
    }

    #endregion Constructors

    #region Functions

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
        Globals.Update(gameTime, this);
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

        animationHandler.Update(Globals.EntityList);
        animationHandler.AnimationsUpdate();

        base.Update(gameTime);
    }

    /// <summary>
    /// Handles the drawing of the game loop each frame.
    /// </summary>
    /// <param name="gameTime">
    /// Provides a snapshot of timing values, such as the time elapsed since the last update.
    /// </param>
    /// <remarks>
    /// This method clears the screen, begins the sprite batch for rendering, 
    /// and handles animations before ending the sprite batch. Finally, it invokes the base class's 
    /// <see cref="Game.Draw(GameTime)"/> method.
    /// </remarks>
    protected override void Draw(GameTime gameTime)
    {
        // Clears the screen to blue, if the game is running at normal pase, or blue if it is slowly.
        Color colour = gameTime.IsRunningSlowly?Color.Red:Color.CornflowerBlue;
        GraphicsDevice.Clear(colour);

        // Start the sprite batch for rendering, applying a point clamp sampler state.
        Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draws the animations
        animationHandler.AnimationsDraw();

        // End the sprite batch to flush all draw calls.
        Globals.spriteBatch.End();

        // Call the base class's Draw method to handle additional rendering logic.
        base.Draw(gameTime);
    }

    #endregion Functions
}
