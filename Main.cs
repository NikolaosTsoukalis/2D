﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

/// <summary>
/// Main class
/// </summary>
/// <remarks>
/// This class handles all game loop logic.
/// </remarks>
public class Main : Game
{

    #region Values

    private State currentGameState;
    private State nextGameState;

    #endregion Values

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    /// <remarks>
    /// This is the Main constructor.
    /// </remarks>
    public Main()
    {

        Globals._graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";

        IsMouseVisible = true;
    }

    #endregion Constructors

    #region Functions

    /// <summary>
    /// Initiallizes non graphical resources on startup runtime once, before LoadContent call.
    /// </summary>
    /// <remarks>
    /// This method initiallizes non graphical resources once before the LoadContent call and the game loop, and calls the base class'
    /// <see cref="Game.Initialize()"/> method.
    /// </remarks>
    protected override void Initialize()
    {
        
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    /// <summary>
    /// Loads graphical resources on startup runtime once, before Update call.
    /// </summary>
    /// <remarks>
    /// This method loads graphical resources once before the game loop, and calls the base class'
    /// <see cref="Game.LoadContent()"/> method.
    /// </remarks>
    protected override void LoadContent()
    {
        Globals.content = this.Content;
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.LoadPlayerAnimationDictionary();
        currentGameState =  new MainMenuState(this);
        // TODO: use this.Content to load your game content here
    }

    /// <summary>
    /// Updates the game loop.
    /// </summary>
    /// <param name="gameTime">
    /// Provides a snapshot of timing values, such as the time elapsed since the last update.
    /// </param>
    /// <remarks>
    /// This method handles the runtime logic of the game loop, and call the base class'
    /// <see cref="Game.Update(GameTime)"/> method.
    /// </remarks>
    protected override void Update(GameTime gameTime)
    {
        if(nextGameState != null)
        {
            currentGameState = nextGameState;
            nextGameState = null;
        }

        currentGameState.Update(gameTime);
        currentGameState.PostUpdate(gameTime);

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
    /// and handles animations before ending the sprite batch. Finally, it invokes the base class' 
    /// <see cref="Game.Draw(GameTime)"/> method.
    /// </remarks>
    protected override void Draw(GameTime gameTime)
    {
        
        Color colour = gameTime.IsRunningSlowly? Color.Red : Color.CornflowerBlue;
        GraphicsDevice.Clear(colour);

        currentGameState.Draw(gameTime);

        base.Draw(gameTime);
    }

    public void ChangeState(State state)
    {
        nextGameState = state;
    }

    #endregion Functions
}
