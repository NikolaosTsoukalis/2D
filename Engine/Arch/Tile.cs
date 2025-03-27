using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Tile
{
    #region Properties

    public Texture2D Texture { get; private set; }
    public Vector2 Position { get; private set; }
    public bool IsWalkable { get; private set; } // Determines if entities can walk on this tile
    public int TileID { get; private set; } // Identifier for different tile types

    #endregion Properties

    #region Constructors

    public Tile(Texture2D texture, Vector2 position, bool isWalkable, int tileID)
    {
        Texture = texture;
        Position = position;
        IsWalkable = isWalkable;
        TileID = tileID;
    }

    #endregion Constructors

    #region Methods

    /// <summary>
    /// Draws the tile onto the screen.
    /// </summary>
    /// <param name="spriteBatch">The SpriteBatch used for rendering.</param>
    public void Draw() // >:^)
    {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    #endregion Methods
}
