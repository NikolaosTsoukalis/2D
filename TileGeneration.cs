using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


// all the tile creation is happening here
public class TileGeneration
{
    private List<Tile> tiles;

    private TileManager tileMap; // Reference to the TileMap


    public static Dictionary<int, Texture2D> tileTextures; // Είναι κακό αυτό το public ? ???????????????????
    private int mapWidth;
    private int mapHeight;
    private int tileSize;

    public TileGeneration(TileManager map)
    {
        tileMap = map;  // Store the TileMap reference
    }

    // load textures
    public static void LoadTextures(ContentManager content) // ola ta dictionaries sto globals
    {
        tileTextures = new Dictionary<int, Texture2D>
        {
            { 0, content.Load<Texture2D>("Tiles/grass_tile") },
            { 1, content.Load<Texture2D>("Tiles/rock_tile") },
            { 2, content.Load<Texture2D>("Tiles/water_tile") }
        };
    }

    public static Tile CreateTile(int tileId, Vector2 position, Vector2 size)
    {
        if (!tileTextures.TryGetValue(tileId, out Texture2D value))
            throw new ArgumentException($"Texture for tile ID {tileId} not found.");

        return new Tile(tileId, value, position, size);
    }

    // 1.0 grass plain = 0
    public void LoadGrassPlain(ContentManager content)
    {
        int[,] mapstore = new int[tileMap.MapWidth, tileMap.MapHeight];

        var tileId = 0; // Grass tile ID
        for (int y = 0; y < tileMap.MapHeight; y++)
        {
            for (int x = 0; x < tileMap.MapWidth; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);

                // Create a new tile and add it to the TileMap's tiles list
                Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                mapstore[x, y] = tileId;
            }
        }
    }
    // 1.1 rocky plain = 1
    public void LoadRockPlain(ContentManager content)
    {
        var tileId = 1; // Rock tile ID
        int[,] mapstore = new int[tileMap.MapWidth, tileMap.MapHeight];

        for (int y = 0; y < tileMap.MapHeight; y++)
        {
            for (int x = 0; x < tileMap.MapWidth; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);

                // Create a new tile and add it to the TileMap's tiles list
                Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                mapstore[x, y] = tileId;
            }
        }
    }
    // 1.2 water plain = 2
    public void LoadWaterPlain(ContentManager content)
    {
        int[,] mapstore = new int[tileMap.MapWidth, tileMap.MapHeight];

        var tileId = 0; // Grass tile ID
        for (int y = 0; y < tileMap.MapHeight; y++)
        {
            for (int x = 0; x < tileMap.MapWidth; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);

                // Create a new tile and add it to the TileMap's tiles list
                Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                mapstore[x, y] = tileId;
            }
        }
    }
    // 2.0 water river = 20
    public void LoadRiverPlain(ContentManager content)
    {
        int[,] mapstore = new int[tileMap.MapWidth, tileMap.MapHeight];

        var tileId = 0; // Grass tile ID
        Random random = new Random();
        // Iterate over the entire map and assign grass tiles initially (tileId = 0)
        for (int y = 0; y < tileMap.MapHeight; y++)
        {
            for (int x = 0; x < tileMap.MapWidth; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);
                // Example: Create a river path (for simplicity, we make it horizontal or vertical)
                if (y == tileMap.MapHeight / 2) // Horizontal river at the middle
                {
                    tileId = 2; // Water tile
                }
                // Create river banks (rock tiles) next to water
                else if (y == tileMap.MapHeight / 2 - 1 || y == tileMap.MapHeight / 2 + 1)
                {
                    tileId = 1; // Rock tile next to the water (riverbank)
                }
                else if (y == tileMap.MapHeight / 2 - 2 || y == tileMap.MapHeight / 2 + 2)
                {
                    tileId = random.Next(0, 10) >= 6 ? 0 : 1; // Rock tile next to rock tile next to the water (riverbank)
                }
                else
                {
                    tileId = 0;
                }
                // Create a new tile and add it to the TileMap's tiles list
                Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                // Store the tile id in the mapstore
                mapstore[x, y] = tileId;
            }
        }
    }
    // 2.1 water river with sharper 3sides = 21
    public void LoadRiverSharp(ContentManager content)
    {
        int[,] mapstore = new int[tileMap.MapWidth, tileMap.MapHeight];

        var tileId = 0; // Grass tile ID
        Random random = new Random();
        // Iterate over the entire map and assign grass tiles initially (tileId = 0)
        for (int y = 0; y < tileMap.MapHeight; y++)
        {
            for (int x = 0; x < tileMap.MapWidth; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);
                // Example: Create a river path (for simplicity, we make it horizontal or vertical)
                if (y == tileMap.MapHeight / 2) // Horizontal river at the middle
                {
                    tileId = 2; // Water tile
                }
                // Create river banks (rock tiles) next to water
                else if (y == tileMap.MapHeight / 2 - 1 || y == tileMap.MapHeight / 2 + 1)
                {
                    tileId = 1; // Rock tile next to the water (riverbank)
                }
                else if (y == tileMap.MapHeight / 2 - 2 || y == tileMap.MapHeight / 2 + 2)
                {
                    tileId = random.Next(0, 10) >= 6 ? 0 : 1; // Rock tile next to rock tile next to the water (riverbank)
                }
                else
                {
                    tileId = 0;
                }
                // Create a new tile and add it to the TileMap's tiles list
                Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                // Store the tile id in the mapstore
                mapstore[x, y] = tileId;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            int y = 0;
            y = i == 0 ? tileMap.MapHeight / 2 - 3 : tileMap.MapHeight / 2 + 3;
            for (int x = 1; x < tileMap.MapWidth - 1; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);
                if (x - 2 >= 0 && x + 2 < tileMap.MapWidth)
                {
                    if ((((mapstore[x - 1, y + 1] == 1 && mapstore[x, y + 1] == 1)
                        && (mapstore[x + 1, y + 1] == 1 && mapstore[x, y + 1] == 1))
                        || ((mapstore[x - 1, y - 1] == 1 && mapstore[x, y - 1] == 1)
                        && (mapstore[x + 1, y - 1] == 1 && mapstore[x, y - 1] == 1)))
                        && (mapstore[x - 1, y] == 0 && mapstore[x + 1, y] == 0))
                    {
                        if (mapstore[x - 2, y] == 0 && mapstore[x + 2, y] == 0)
                        {
                            tileId = 1;
                        }
                        else
                        {
                            tileId = random.Next(0, 10) >= 6 ? 1 : 0;
                        }

                        Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                        tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                        mapstore[x, y] = tileId;
                    }
                }
            }
        }
    }
    // 2.2 water river with smoother 3sides = 22
    public void LoadRiverSmooth(ContentManager content)
    {
        int[,] mapstore = new int[tileMap.MapWidth, tileMap.MapHeight];

        var tileId = 0; // Grass tile ID
        Random random = new Random();
        // Iterate over the entire map and assign grass tiles initially (tileId = 0)
        for (int y = 0; y < tileMap.MapHeight; y++)
        {
            for (int x = 0; x < tileMap.MapWidth; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);
                // Example: Create a river path (for simplicity, we make it horizontal or vertical)
                if (y == tileMap.MapHeight / 2) // Horizontal river at the middle
                {
                    tileId = 2; // Water tile
                }
                // Create river banks (rock tiles) next to water
                else if (y == tileMap.MapHeight / 2 - 1 || y == tileMap.MapHeight / 2 + 1)
                {
                    tileId = 1; // Rock tile next to the water (riverbank)
                }
                else if (y == tileMap.MapHeight / 2 - 2 || y == tileMap.MapHeight / 2 + 2)
                {
                    tileId = random.Next(0, 10) >= 6 ? 0 : 1; // Rock tile next to rock tile next to the water (riverbank)
                }
                else
                {
                    tileId = 0;
                }
                // Create a new tile and add it to the TileMap's tiles list
                Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                // Store the tile id in the mapstore
                mapstore[x, y] = tileId;
            }
        }
        
        for (int i = 0; i < 2 ; i++)
        {
            int y = 0;
            y = i == 0 ? tileMap.MapHeight / 2 - 3 : tileMap.MapHeight / 2 + 3;
            for (int x = 1; x < tileMap.MapWidth-1; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);
                if (x - 2 >= 0 && x + 2 < tileMap.MapWidth)
                {
                    if (((mapstore[x - 1, y + 1] == 1 && mapstore[x, y + 1] == 1)
                        && (mapstore[x + 1, y + 1] == 1 && mapstore[x, y + 1] == 1)
                        || (mapstore[x - 1, y - 1] == 1 && mapstore[x, y - 1] == 1)
                        && (mapstore[x + 1, y - 1] == 1 && mapstore[x, y - 1] == 1))
                        && (mapstore[x - 1, y] == 0 && mapstore[x + 1, y] == 0))
                    {
                        if (mapstore[x - 2, y] == 0 && mapstore[x + 2, y] == 0)
                        {
                            tileId = 1;
                        }
                        else
                        {
                            tileId = random.Next(0, 10) >= 6 ? 1 : 0;
                        }

                        Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                        tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection
                        
                        mapstore[x, y] = tileId;
                    }
                }
            }
        }
    }
    // 2.3 water river with smoother 3sides random place = 23
    public void LoadRRiverSmooth(ContentManager content)
    {
        int[,] mapstore = new int[tileMap.MapWidth, tileMap.MapHeight];

    var tileId = 0; // Grass tile ID
    Random random = new Random();
        // Iterate over the entire map and assign grass tiles initially (tileId = 0)
        for (int y = 0; y<tileMap.MapHeight; y++)
        {
            for (int x = 0; x<tileMap.MapWidth; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);
                // Example: Create a river path (for simplicity, we make it horizontal or vertical)
                if (y == tileMap.MapHeight / 2) // Horizontal river at the middle
                {
                    tileId = 2; // Water tile
                }
                // Create river banks (rock tiles) next to water
                else if (y == tileMap.MapHeight / 2 - 1 || y == tileMap.MapHeight / 2 + 1)
        {
            tileId = 1; // Rock tile next to the water (riverbank)
        }
        else if (y == tileMap.MapHeight / 2 - 2 || y == tileMap.MapHeight / 2 + 2)
        {
            tileId = random.Next(0, 10) >= 6 ? 0 : 1; // Rock tile next to rock tile next to the water (riverbank)
        }
        else
        {
            tileId = 0;
        }
        // Create a new tile and add it to the TileMap's tiles list
        Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
        tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

        // Store the tile id in the mapstore
        mapstore[x, y] = tileId;
                    }
                }
        
                for (int i = 0; i < 2; i++)
        {
            int y = 0;
            y = i == 0 ? tileMap.MapHeight / 2 - 3 : tileMap.MapHeight / 2 + 3;
            for (int x = 1; x < tileMap.MapWidth - 1; x++)
            {
                var position = new Vector2(x * tileMap.TileSize, y * tileMap.TileSize);
                if (x - 2 >= 0 && x + 2 < tileMap.MapWidth)
                {
                    if (((mapstore[x - 1, y + 1] == 1 && mapstore[x, y + 1] == 1)
                        && (mapstore[x + 1, y + 1] == 1 && mapstore[x, y + 1] == 1)
                        || (mapstore[x - 1, y - 1] == 1 && mapstore[x, y - 1] == 1)
                        && (mapstore[x + 1, y - 1] == 1 && mapstore[x, y - 1] == 1))
                        && (mapstore[x - 1, y] == 0 && mapstore[x + 1, y] == 0))
                    {
                        if (mapstore[x - 2, y] == 0 && mapstore[x + 2, y] == 0)
                        {
                            tileId = 1;
                        }
                        else
                        {
                            tileId = random.Next(0, 10) >= 6 ? 1 : 0;
                        }

                        Tile newTile = CreateTile(tileId, position, new Vector2(tileMap.TileSize, tileMap.TileSize));
                        tileMap.AddTile(newTile);  // Add the tile to the TileMap's collection

                        mapstore[x, y] = tileId;
                    }
                }
            }
        }
    }
}
