using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public abstract class State
{
    #region Values

    protected ContentManager content;

    protected GraphicsDevice graphicsDevice;

    protected Main main;

    #endregion Values

    #region Constructors

    public State(Main game)
    {
        main = game;

        graphicsDevice = game.GraphicsDevice;

        content = Globals.content;
    }

    #endregion Constructors

    #region Functions

    public abstract void Update(GameTime gameTime);

    public abstract void PostUpdate(GameTime gameTime);

    public abstract void Draw(GameTime gameTime);

    #endregion Functions
}
