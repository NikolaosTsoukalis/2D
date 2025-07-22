using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public abstract class State
{
    #region Values


    protected Main main;

    #endregion Values

    #region Constructors

    public State(Main game)
    {
        main = game;
    }

    #endregion Constructors

    #region Functions

    public abstract void Update(GameTime gameTime);

    public abstract void PostUpdate(GameTime gameTime);

    public abstract void Draw(GameTime gameTime);

    public abstract bool InitializeHandlers(Main main);

    public abstract bool ManageTextureLibrary();

    public abstract bool CallDrawFuctions(GameTime gameTime);

    #endregion Functions
}
