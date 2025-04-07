using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

public class TileMap
{
    #region Fields
    public int worldHeight;
    public int worldWidth;
    private int[,] tileMapMatrix; // >: ^)
    public int tileMapSize;

    #endregion Fields

    #region Constructor

    public TileMap()
    {
        worldWidth = Globals.GraphicsDeviceManager.PreferredBackBufferWidth / Globals.TileSize;
        worldHeight = Globals.GraphicsDeviceManager.PreferredBackBufferHeight / Globals.TileSize;
        // WorldSize = new Tuple<int, int>(x, y);
        tileMapMatrix = new int[worldWidth, worldHeight];

        tileMapSize = tileMapMatrix.Length;

        GenerateMap();
    }

    #endregion Constructor

    public void GenerateMap()
    {
        try
        {
            #region grass only
            if (Globals.seed == 1)
            {
                for (int y = 0; y < worldHeight; y++)
                {
                    for (int x = 0; x < worldWidth; x++)
                    {
                        GenerateLushGrass4(x, y);
                    }
                }
            }
            #endregion
            #region river w/rocks
            else if (Globals.seed == 2)
            {
                // Define the river area (in the middle)
                int riverStartX = 0;
                int riverEndX = worldWidth;
                int riverStartY = 2 * worldHeight / 6;
                int riverEndY = 3 * worldHeight / 6;

                // Create the map with river and random rocks
                for (int y = 0; y < worldHeight; y++)
                {
                    for (int x = 0; x < worldWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverStartX && x <= riverEndX && y >= riverStartY && y <= riverEndY;

                        if (isRiver)
                        {
                            // If it's the river area, use water tiles
                            GenerateWater1(x, y);
                        }
                        else
                        {
                            // Randomly place rocks on non-river areas
                            GenerateRocksInGrassV0(x, y);
                        }
                    }
                }
            }
            #endregion
            #region river path
            else if (Globals.seed == 3) // random bridge path with 4 rectangles starting from north west and ending at south
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);
                int riverSizeRand = rnd.Next(riverHeightRand + 2, riverHeightRand + 5);

                // Define the river area rectangle
                int riverStartX = 0;
                int riverEndX = worldWidth;
                int riverStartY = riverHeightRand;
                int riverEndY = riverSizeRand;

                // path logic here
                int pathRecStartAX = 0;
                int pathRecEndAX = rnd.Next(14, 23);
                int pathRecStartAY = rnd.Next(1, riverStartY - 3);
                int pathSize = rnd.Next(1, 3);
                int pathRecEndAY = pathRecStartAY + pathSize;
                // vertical path
                int pathRecStartBX = pathRecEndAX - pathSize;
                int pathRecEndBX = pathRecEndAX;
                int pathRecStartBY = pathRecStartAY;
                int pathRecEndBY = rnd.Next(riverEndY + 2, 17);
                // horizontal path 2
                int pathRecEndCX = rnd.Next(8, 23); // can you rando it ? instead of abs ? [condition ? value_if_true : value_if_false;]
                int pathRecStartCX = pathRecEndCX < pathRecStartBX ? pathRecEndBX : pathRecStartBX;
                int pathRecStartCY = pathRecEndBY;
                int pathRecEndCY = pathRecStartCY + pathSize;
                // vertical path 2
                int pathRecStartDX = pathRecEndCX < pathRecStartCX ? pathRecEndCX : pathRecEndCX - pathSize;
                // int pathRecStartDX = pathRecEndCX - pathSize;
                int pathRecEndDX = pathRecEndCX < pathRecStartCX ? pathRecEndCX + pathSize : pathRecEndCX;
                // int pathRecEndDX = pathRecEndCX;
                int pathRecStartDY = pathRecStartCY;
                int pathRecEndDY = 20;
                if (pathRecStartCX > pathRecEndCX)
                {
                    int flag = pathRecEndCX;
                    pathRecEndCX = pathRecStartCX;
                    pathRecStartCX = flag;
                }

                // Create the map with river and random rocks
                for (int y = 0; y < worldHeight; y++)
                {
                    for (int x = 0; x < worldWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverStartX && x <= riverEndX && y >= riverStartY && y <= riverEndY;
                        // Check if the current position is within the path's area
                        bool isPath = (x >= pathRecStartAX && x <= pathRecEndAX && y >= pathRecStartAY && y <= pathRecEndAY) ||
                                       (x >= pathRecStartBX && x <= pathRecEndBX && y >= pathRecStartBY && y <= pathRecEndBY) ||
                                       (x >= pathRecStartCX && x <= pathRecEndCX && y >= pathRecStartCY && y <= pathRecEndCY) ||
                                       (x >= pathRecStartDX && x <= pathRecEndDX && y >= pathRecStartDY && y <= pathRecEndDY);

                        if (isRiver && isPath)
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Wood;
                        }
                        else if (isRiver)
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Water;
                        }
                        else if(isPath)
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Stone;
                        }
                        else  // Otherwise, use grass
                        { 
                            GenerateLushGrass4(x, y);
                        }
                    }
                }
            }
            #endregion
            #region rnd river path
            else if (Globals.seed == 4) // random bridge path with 4 rectangles starting from north west and ending at south
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);

                // river logic Here
                Rectangle riverArea = new Rectangle(0, riverHeightRand, 25, rnd.Next(3, 7));

                // path logic here
                int startOfPath = 1;
                //          int endOfPath = rnd.Next(0, 4); 
                int pathSize = rnd.Next(1, 3);
                // public Rectangle(int x, int y, int width, int height); coords of top left corner + the width and height

                // Declare rectangles first (default values to prevent errors)
                Rectangle pathA = new Rectangle(0, 0, 0, 0);
                Rectangle pathB = new Rectangle(0, 0, 0, 0);
                Rectangle pathC = new Rectangle(0, 0, 0, 0);
                Rectangle pathD = new Rectangle(0, 0, 0, 0);

                if (startOfPath == 0) // 0 - 3 is x, 0 is top left corner
                {
                    pathA = new Rectangle(0, rnd.Next(1, riverArea.Y - 4), rnd.Next(5, 21), pathSize);
                    pathB = new Rectangle(pathA.Right - pathSize, pathA.Bottom, pathSize, rnd.Next(riverArea.Bottom + 1, 18));
                    if (pathB.X <= 12)
                    {
                        pathC = new Rectangle(pathB.X, pathB.Bottom, rnd.Next(2, 25 - 2 - pathA.Right), pathSize);
                        pathD = new Rectangle(pathC.Right - pathSize, pathC.Bottom, pathSize, 25 - pathC.Bottom);
                    } 
                    else
                    {
                        int pathSizeC = rnd.Next(2, pathB.Right);
                        pathC = new Rectangle(pathB.Right - pathSizeC, pathB.Bottom + 1, pathSizeC, pathSize);
                        pathD = new Rectangle(pathC.X, pathC.Bottom, pathSize, 25 - pathC.Bottom);
                    }
                }
                else if (startOfPath == 1) // for bottom left start to top finish
                {
                    pathA = new Rectangle(0, rnd.Next(riverArea.Bottom + 2, 17), rnd.Next(16, 21), pathSize);
                    int pathSizeB = pathA.Bottom - rnd.Next(3, riverArea.Y - 2);
                    pathB = new Rectangle(pathA.Right - pathSize, pathA.Y - pathSizeB, pathSize, pathSizeB);
                    if (pathB.X <= 12)
                    {
                        pathC = new Rectangle(pathB.X, pathB.Y, rnd.Next(2, 25 - 2 - pathB.Right), pathSize);
                        pathD = new Rectangle(pathC.Right - pathSize, 0, pathSize, pathC.Bottom);
                    } 
                    else
                    {
                        int pathSizeC = rnd.Next(2, pathB.Right);
                        pathC = new Rectangle(pathB.Right - pathSizeC, pathB.Y, pathSizeC, pathSize);
                        pathD = new Rectangle(pathC.X, 0, pathSize, pathC.Bottom);
                    }
                }
                else if (startOfPath == 2)
                {

                }
                else if (startOfPath == 3)
                {

                }

                // Create the map with river and random rocks
                for (int y = 0; y < worldHeight; y++)
                {
                    for (int x = 0; x < worldWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverArea.X && x <= riverArea.Right && y >= riverArea.Y && y <= riverArea.Bottom; //done
                        // Check if the current position is within the path's area
                        bool isPath = (x >= pathA.X && x <= pathA.Right && y >= pathA.Y && y <= pathA.Bottom) ||
                                       (x >= pathB.X && x <= pathB.Right && y >= pathB.Y && y <= pathB.Bottom) ||
                                       (x >= pathC.X && x <= pathC.Right && y >= pathC.Y && y <= pathC.Bottom) ||
                                       (x >= pathD.X && x <= pathD.Right && y >= pathD.Y && y <= pathD.Bottom);

                        if (isRiver && isPath)
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Wood;
                        }
                        else if (isRiver)
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Water;
                        }
                        else if(isPath)
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Stone;
                        }
                        else
                        {
                            GenerateLushGrass4(x, y);
                        }
                    }
                }
            }
            #endregion
            #region textured path
            else if (Globals.seed == 5) // random bridge path with 4 rectangles starting from north west and ending at south + randomed path
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);

                // river logic Here
                Rectangle riverArea = new Rectangle(0, riverHeightRand, 25, rnd.Next(3, 7));

                // path logic here
                int startOfPath = 1;
                //          int endOfPath = rnd.Next(0, 4); 
                int pathSize = rnd.Next(1, 3);
                // public Rectangle(int x, int y, int width, int height); coords of top left corner + the width and height

                // Declare rectangles first (default values to prevent errors)
                Rectangle pathA = new Rectangle(0, 0, 0, 0);
                Rectangle pathB = new Rectangle(0, 0, 0, 0);
                Rectangle pathC = new Rectangle(0, 0, 0, 0);
                Rectangle pathD = new Rectangle(0, 0, 0, 0);

                if (startOfPath == 0) // 0 - 3 is x, 0 is top left corner
                {
                    pathA = new Rectangle(0, rnd.Next(1, riverArea.Y - 4), rnd.Next(5, 21), pathSize);
                    pathB = new Rectangle(pathA.Right - pathSize, pathA.Bottom, pathSize, rnd.Next(riverArea.Bottom + 1, 18));
                    if (pathB.X <= 12)
                    {
                        pathC = new Rectangle(pathB.X, pathB.Bottom, rnd.Next(2, 25 - 2 - pathA.Right), pathSize);
                        pathD = new Rectangle(pathC.Right - pathSize, pathC.Bottom, pathSize, 25 - pathC.Bottom);
                    } 
                    else
                    {
                        int pathSizeC = rnd.Next(2, pathB.Right);
                        pathC = new Rectangle(pathB.Right - pathSizeC, pathB.Bottom + 1, pathSizeC, pathSize);
                        pathD = new Rectangle(pathC.X, pathC.Bottom, pathSize, 25 - pathC.Bottom);
                    }
                }
                else if (startOfPath == 1) // for bottom left start to top finish
                {
                    pathA = new Rectangle(0, rnd.Next(riverArea.Bottom + 2, 17), rnd.Next(16, 21), pathSize);
                    int pathSizeB = pathA.Bottom - rnd.Next(3, riverArea.Y - 2);
                    pathB = new Rectangle(pathA.Right - pathSize, pathA.Y - pathSizeB, pathSize, pathSizeB);
                    if (pathB.X <= 12)
                    {
                        pathC = new Rectangle(pathB.X, pathB.Y, rnd.Next(2, 25 - 2 - pathB.Right), pathSize);
                        pathD = new Rectangle(pathC.Right - pathSize, 0, pathSize, pathC.Bottom);
                    } 
                    else
                    {
                        int pathSizeC = rnd.Next(2, pathB.Right);
                        pathC = new Rectangle(pathB.Right - pathSizeC, pathB.Y, pathSizeC, pathSize);
                        pathD = new Rectangle(pathC.X, 0, pathSize, pathC.Bottom);
                    }
                }
                else if (startOfPath == 2)
                {

                }
                else if (startOfPath == 3)
                {

                }

                // Create the map with river and random rocks
                for (int y = 0; y < worldHeight; y++)
                {
                    for (int x = 0; x < worldWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverArea.X && x <= riverArea.Right && y >= riverArea.Y && y <= riverArea.Bottom;
                        // Check if the current position is within the path's inner area
                        bool isInnerPath = (x >= pathA.X + 1 && x <= pathA.Right - 1 && y >= pathA.Y + 1 && y <= pathA.Bottom - 1) ||
                                       (x >= pathB.X + 1 && x <= pathB.Right - 1 && y >= pathB.Y + 1 && y <= pathB.Bottom - 1) ||
                                       (x >= pathC.X + 1 && x <= pathC.Right - 1 && y >= pathC.Y + 1 && y <= pathC.Bottom - 1) ||
                                       (x >= pathD.X + 1 && x <= pathD.Right - 1 && y >= pathD.Y + 1 && y <= pathD.Bottom - 1);
                        // Check if the current position is within the path's area
                        bool isPath = (x >= pathA.X && x <= pathA.Right && y >= pathA.Y && y <= pathA.Bottom) ||
                                       (x >= pathB.X && x <= pathB.Right && y >= pathB.Y && y <= pathB.Bottom) ||
                                       (x >= pathC.X && x <= pathC.Right && y >= pathC.Y && y <= pathC.Bottom) ||
                                       (x >= pathD.X && x <= pathD.Right && y >= pathD.Y && y <= pathD.Bottom);
                        // Check if next to a path but not on path
                        bool isCloserToPath = (x >= pathA.X - 1 && x <= pathA.Right + 1 && y >= pathA.Y - 1 && y <= pathA.Bottom + 1) ||
                                             (x >= pathB.X - 1 && x <= pathB.Right + 1 && y >= pathB.Y - 1 && y <= pathB.Bottom + 1) ||
                                             (x >= pathC.X - 1 && x <= pathC.Right + 1 && y >= pathC.Y - 1 && y <= pathC.Bottom + 1) ||
                                             (x >= pathD.X - 1 && x <= pathD.Right + 1 && y >= pathD.Y - 1 && y <= pathD.Bottom + 1);
                        // Check if near a path but not on path
                        bool isCloseToPath = (x >= pathA.X - 2 && x <= pathA.Right + 2 && y >= pathA.Y - 2 && y <= pathA.Bottom + 2) ||
                                             (x >= pathB.X - 2 && x <= pathB.Right + 2 && y >= pathB.Y - 2 && y <= pathB.Bottom + 2) ||
                                             (x >= pathC.X - 2 && x <= pathC.Right + 2 && y >= pathC.Y - 2 && y <= pathC.Bottom + 2) ||
                                             (x >= pathD.X - 2 && x <= pathD.Right + 2 && y >= pathD.Y - 2 && y <= pathD.Bottom + 2);

                        if (IsInRectangle(x, y, riverArea) && IsInRectangles(x, y, pathA, pathB, pathC, pathD))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Wood;
                        }
                        else if (IsInRectangle(x, y, riverArea))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Water;
                        }
                        else if (isInnerPath)
                        {
                            GeneratePathWithPercentage(x, y, 100);
                        }
                        else if (isPath)
                        {
                            GeneratePathWithPercentage(x, y, 95);
                        }
                        else if (isCloserToPath)
                        {
                            GeneratePathWithPercentage(x, y, 20);
                        }
                        else if (isCloseToPath)
                        {
                            GeneratePathWithPercentage(x, y, 5);
                        }
                        else 
                        {
                            GenerateLushGrass4(x, y);
                        }
                    }
                }
            }
            #endregion
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }

    public void ChangeTile(int x, int y, TileDataHandler.TileType newTile) // >: ^)
    {
        tileMapMatrix[x, y] = 0;
        tileMapMatrix[x, y] = (int)newTile; // >:    ^)
    }

    public void RemoveTile(int x, int y)
    {
        tileMapMatrix[x, y] = 0;
    }

    public void AddTile(int x, int y, TileDataHandler.TileType newType)
    {
        tileMapMatrix[x, y] = (int)newType;
    }

    public int GetTileTypeAt(int x, int y)
    {
        return tileMapMatrix[x, y];
    }

    public void Update()
    {
        // check all the tiles that need updating, ότι αλλάζει στο tileMapMatrix ΕΔΩ
    }

    public void Draw()
    {
        Vector2 Position = new Vector2 (0, 0);
        for (int y = 0; y < worldHeight; y++)
        {
            for (int x = 0; x < worldWidth; x++)
            {
                Position.X = x * Globals.TileSize;
                Position.Y = y * Globals.TileSize;
                Globals.SpriteBatch.Draw(Globals.TileDataHandler.GetTileTextureData(tileMapMatrix[x, y]), Position, Color.White);
            }
        }
    }

    #region Gen Functions

    private void GenerateLushGrass4(int x, int y)
    {
        Random rnd = new Random();
        int flag = rnd.Next(0, 100);
        tileMapMatrix[x, y] = flag < 50 ? flag < 25 ? (int)TileDataHandler.TileType.Grass : (int)TileDataHandler.TileType.Grass1 : flag < 75 ? (int)TileDataHandler.TileType.Grass1 : (int)TileDataHandler.TileType.Grass3;
    }

    private void GenerateWater1(int x, int y)
    {   
        tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Water;
    }

    private void GenerateRocksInGrassV0(int x, int y)
    { 
        if (new Random().Next(0, 10) > 8)  // 20% chance of placing a rock
        {
            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Stone; // Rock tile
        }
        else 
        {
            GenerateLushGrass4(x, y);
        }
    }

    private void GeneratePathWithPercentage(int x, int y, int z)
    { 
        Random rnd = new Random();
        int flag = rnd.Next(0, 100);
        if (flag < z)  // chance of placing path is z
        {
            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Stone; // Rock tile
        }
        else 
        {
            GenerateLushGrass4(x, y);
        }
    }

    private bool IsInRectangle(int x, int y, Rectangle rectangle)
    { 
        return x >= rectangle.X && x <= rectangle.Right && y >= rectangle.Y && y <= rectangle.Bottom;
    }

    private bool IsInRectangles(int x, int y, params Rectangle[] rectangles)
    {
        foreach (var rect in rectangles)
        {
            if (IsInRectangle(x, y, rect))
                return true;
        }
        return false;
    }

    #endregion Gen Functions
}   