using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class TileHandler
{
    #region Fields
    private List<Tile> CurrentTiles { get; set; }
    private int MapWidth, MapHeight;
    private Dictionary<TileDataHandler.TileType, Tuple<int, int>> x;

    #endregion

    #region Constructors
    public TileHandler()
    {
        CurrentTiles = new List<Tile>();
        
        MapWidth = Globals.GraphicsDeviceManager.PreferredBackBufferWidth / Globals.TILE_SIZE;
        MapHeight = Globals.GraphicsDeviceManager.PreferredBackBufferHeight / Globals.TILE_SIZE;
        // fucntion for tilling map
    }
    #endregion

    #region Functions
    public void UpdateTiles()
    {
        try
        {
            // If any tile needs updating (e.g., animations or interactions), implement that logic here
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }

    public void DrawTiles()
    {

    foreach (Tile tile in CurrentTiles)
    {
        tile.Draw();
    }

    }

    public void AddTile(Tile tile)
    {
        if (!CurrentTiles.Contains(tile))
        {
            CurrentTiles.Add(tile);
        }
    }

    public void RemoveTile(Tile tile)
    {
        if (CurrentTiles.Contains(tile))
        {
            CurrentTiles.Remove(tile);
        }
    }
    #endregion
}
