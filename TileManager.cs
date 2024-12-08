using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Linq.Expressions;
using System.Reflection.Metadata;

public class TileManager
{
    private List<Tile> tiles;
    private int mapWidth, mapHeight;
    private int tileSize;

    public int MapWidth => mapWidth;  // Public property to access map width
    public int MapHeight => mapHeight;  // Public property to access map height
    public int TileSize => tileSize;  // Public property for tile size

    public TileManager(int width, int height, int tileSize)
    {
        tiles = new List<Tile>();
        mapWidth = width;
        mapHeight = height;
        this.tileSize = tileSize;
    }

    // Method to add a tile to the TileMap
    public void AddTile(Tile tile)
    {
        tiles.Add(tile);
    }

    // Method to load terrain
    public void LoadTerrain(int terrainId, ContentManager content)
    {
        TileGeneration tileGeneration = new TileGeneration(this);  // Create an instance of TileGeneration

        switch (terrainId)
        {
            case 0:  // Grassplain
                tileGeneration.LoadGrassPlain(content);
                break;
            case 1:  // Rockplain
                tileGeneration.LoadRockPlain(content);
                break;
            case 2: // Waterplain
                tileGeneration.LoadWaterPlain(content);
                break;
            case 20: // River with plains
                tileGeneration.LoadRiverPlain(content);
                break;
            case 21: // River with plains
                tileGeneration.LoadRiverSharp(content);
                break;
            case 22: // River with plains
                tileGeneration.LoadRiverSmooth(content);
                break;
            default:
                throw new ArgumentException($"Terrain ID {terrainId} not recognized.");
        }
    }

    // Method to draw the map
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var tile in tiles)
        {
            tile.Draw(spriteBatch, TileGeneration.tileTextures);
        }
    }
}

