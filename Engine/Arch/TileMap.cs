using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2D_RPG;

public class TileMap
{
    private static Dictionary<TileDataHandler.TileType, Tuple<int, int>> WorldMap;

    private Tuple<int, int> WorldSize;

    public TileMap()
    {

    }

    public void GenerateTiles(int index)
    {
        try
        {
            #region grass only
            if (index == 1)
            {
                // Clear the current tile list
                CurrentTiles.Clear();

                // Create a 50x50 map of grass tiles
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int x = 0; x < MapWidth; x++)
                    {
                        // Get the tile data for grass
                        var tileData = TileDataHandler.GetTileData(TileDataHandler.TileType.Grass);
                        if (tileData != null)
                        {
                            // Create a new Tile with the texture and properties from the tileData
                            var tile = new Tile(
                                tileData.Item1, // Texture
                                new Vector2(x * Globals.TILE_SIZE, y * Globals.TILE_SIZE), // Position (scaled by TILE_SIZE)
                                tileData.Item2, // IsWalkable (true for grass)
                                (int)TileDataHandler.TileType.Grass // TileID (use enum value for unique identification)
                            );

                            // Add the created tile to the list of current tiles
                            CurrentTiles.Add(tile);
                        }
                    }
                }
            }
            #endregion
            #region river w/rocks
            else if (index == 2)
            {
                // Clear the current tile list
                CurrentTiles.Clear();

                // Define the river area (in the middle)
                int riverStartX = 0;
                int riverEndX = MapWidth;
                int riverStartY = 2 * MapHeight / 6;
                int riverEndY = 3 * MapHeight / 6;

                // Create the map with river and random rocks
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int x = 0; x < MapWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverStartX && x <= riverEndX && y >= riverStartY && y <= riverEndY;
                        TileDataHandler.TileType tileType;

                        if (isRiver)
                        {
                            // If it's the river area, use water tiles
                            tileType = TileDataHandler.TileType.Water;
                        }
                        else
                        {
                            // Otherwise, use grass or random rocks
                            tileType = TileDataHandler.TileType.Grass;

                            // Randomly place rocks on non-river areas
                            if (new Random().Next(0, 10) > 8)  // 20% chance of placing a rock
                            {
                                tileType = TileDataHandler.TileType.Stone; // Rock tile
                            }
                        }

                        // Get the tile data for the chosen tile type
                        var tileData = TileDataHandler.GetTileData(tileType);
                        if (tileData != null)
                        {
                            // Create a new Tile with the texture and properties from the tileData
                            var tile = new Tile(
                                tileData.Item1, // Texture
                                new Vector2(x * Globals.TILE_SIZE, y * Globals.TILE_SIZE), // Position (scaled by TILE_SIZE)
                                tileData.Item2, // IsWalkable (true for grass, false for water/rocks)
                                (int)tileType // TileID (use enum value for unique identification)
                            );

                            // Add the created tile to the list of current tiles
                            CurrentTiles.Add(tile);
                        }
                    }
                }
            }
            #endregion
            #region river path
            else if (index == 3) // random bridge path with 4 rectangles starting from north west and ending at south
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);
                int riverSizeRand = rnd.Next(riverHeightRand + 2, riverHeightRand + 5);
                // Clear the current tile list
                CurrentTiles.Clear();

                // Define the river area rectangle
                int riverStartX = 0;
                int riverEndX = MapWidth;
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
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int x = 0; x < MapWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverStartX && x <= riverEndX && y >= riverStartY && y <= riverEndY;
                        // Check if the current position is within the path's area
                        bool isPath = (x >= pathRecStartAX && x <= pathRecEndAX && y >= pathRecStartAY && y <= pathRecEndAY) ||
                                       (x >= pathRecStartBX && x <= pathRecEndBX && y >= pathRecStartBY && y <= pathRecEndBY) ||
                                       (x >= pathRecStartCX && x <= pathRecEndCX && y >= pathRecStartCY && y <= pathRecEndCY) ||
                                       (x >= pathRecStartDX && x <= pathRecEndDX && y >= pathRecStartDY && y <= pathRecEndDY);
                        TileDataHandler.TileType tileType;

                        if (isRiver && isPath)
                        {
                            tileType = TileDataHandler.TileType.Wood;
                        }
                        else if (isRiver)
                        {
                            tileType = TileDataHandler.TileType.Water;
                        }
                        else if(isPath)
                        {
                            tileType = TileDataHandler.TileType.Stone;
                        }
                        else
                        {
                            // Otherwise, use grass 
                            tileType = TileDataHandler.TileType.Grass;
                        }

                        // Get the tile data for the chosen tile type
                        var tileData = TileDataHandler.GetTileData(tileType);
                        if (tileData != null)
                        {
                            // Create a new Tile with the texture and properties from the tileData
                            var tile = new Tile(
                                tileData.Item1, // Texture
                                new Vector2(x * Globals.TILE_SIZE, y * Globals.TILE_SIZE), // Position (scaled by TILE_SIZE)
                                tileData.Item2, // IsWalkable (true for grass, false for water/rocks)
                                (int)tileType // TileID (use enum value for unique identification)
                            );

                            // Add the created tile to the list of current tiles
                            CurrentTiles.Add(tile);
                        }
                    }
                }
            }
            #endregion
            #region rnd river path
            else if (index == 4) // random bridge path with 4 rectangles starting from north west and ending at south
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);
                // Clear the current tile list
                CurrentTiles.Clear();

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
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int x = 0; x < MapWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverArea.X && x <= riverArea.Right && y >= riverArea.Y && y <= riverArea.Bottom; //done
                        // Check if the current position is within the path's area
                        bool isPath = (x >= pathA.X && x <= pathA.Right && y >= pathA.Y && y <= pathA.Bottom) ||
                                       (x >= pathB.X && x <= pathB.Right && y >= pathB.Y && y <= pathB.Bottom) ||
                                       (x >= pathC.X && x <= pathC.Right && y >= pathC.Y && y <= pathC.Bottom) ||
                                       (x >= pathD.X && x <= pathD.Right && y >= pathD.Y && y <= pathD.Bottom);
                        TileDataHandler.TileType tileType;

                        if (isRiver && isPath)
                        {
                            tileType = TileDataHandler.TileType.Wood;
                        }
                        else if (isRiver)
                        {
                            tileType = TileDataHandler.TileType.Water;
                        }
                        else if(isPath)
                        {
                            tileType = TileDataHandler.TileType.Stone;
                        }
                        else
                        {
                            // Otherwise, use grass 
                            tileType = TileDataHandler.TileType.Grass;
                        }

                        // Get the tile data for the chosen tile type
                        var tileData = TileDataHandler.GetTileData(tileType);
                        if (tileData != null)
                        {
                            // Create a new Tile with the texture and properties from the tileData
                            var tile = new Tile(
                                tileData.Item1, // Texture
                                new Vector2(x * Globals.TILE_SIZE, y * Globals.TILE_SIZE), // Position (scaled by TILE_SIZE)
                                tileData.Item2, // IsWalkable (true for grass, false for water/rocks)
                                (int)tileType // TileID (use enum value for unique identification)
                            );

                            // Add the created tile to the list of current tiles
                            CurrentTiles.Add(tile);
                        }
                    }
                }
            }
            #endregion
            #region textured path
            else if (index == 5) // random bridge path with 4 rectangles starting from north west and ending at south + randomed path
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);
                // Clear the current tile list
                CurrentTiles.Clear();

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
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int x = 0; x < MapWidth; x++)
                    {
                        // Check if the current position is within the river's area
                        bool isRiver = x >= riverArea.X && x <= riverArea.Right && y >= riverArea.Y && y <= riverArea.Bottom; //done
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
                        // Check if near a path but not on path
                        bool isCloserToPath = (x >= pathA.X - 1 && x <= pathA.Right + 1 && y >= pathA.Y - 1 && y <= pathA.Bottom + 1) ||
                                             (x >= pathB.X - 1 && x <= pathB.Right + 1 && y >= pathB.Y - 1 && y <= pathB.Bottom + 1) ||
                                             (x >= pathC.X - 1 && x <= pathC.Right + 1 && y >= pathC.Y - 1 && y <= pathC.Bottom + 1) ||
                                             (x >= pathD.X - 1 && x <= pathD.Right + 1 && y >= pathD.Y - 1 && y <= pathD.Bottom + 1);
                        // Check if near a path but not on path
                        bool isCloseToPath = (x >= pathA.X - 2 && x <= pathA.Right + 2 && y >= pathA.Y - 2 && y <= pathA.Bottom + 2) ||
                                             (x >= pathB.X - 2 && x <= pathB.Right + 2 && y >= pathB.Y - 2 && y <= pathB.Bottom + 2) ||
                                             (x >= pathC.X - 2 && x <= pathC.Right + 2 && y >= pathC.Y - 2 && y <= pathC.Bottom + 2) ||
                                             (x >= pathD.X - 2 && x <= pathD.Right + 2 && y >= pathD.Y - 2 && y <= pathD.Bottom + 2);
                        TileDataHandler.TileType tileType;

                        if (isRiver && isPath)
                        {
                            tileType = TileDataHandler.TileType.Wood;
                        }
                        else if (isRiver)
                        {
                            tileType = TileDataHandler.TileType.Water;
                        }
                        else if (isInnerPath)
                        {
                            int flag = rnd.Next(0, 100);
                            tileType = flag < 100 ? TileDataHandler.TileType.Stone : TileDataHandler.TileType.Grass;
                        }
                        else if (isPath)
                        {
                            int flag = rnd.Next(0, 100);
                            tileType = flag < 95 ? TileDataHandler.TileType.Stone : TileDataHandler.TileType.Grass;
                        }
                        else if (isCloserToPath)
                        {
                            int flag = rnd.Next(0, 100);
                            tileType = flag < 20 ? TileDataHandler.TileType.Stone : TileDataHandler.TileType.Grass;
                        }
                        else if (isCloseToPath)
                        {
                            int flag = rnd.Next(0, 100);
                            tileType = flag < 5 ? TileDataHandler.TileType.Stone : TileDataHandler.TileType.Grass;
                        }
                        else 
                        {
                            // Otherwise, use grass 
                            tileType = TileDataHandler.TileType.Grass;
                        }

                        if (tileType == TileDataHandler.TileType.Grass)
                        {
                            int flag = rnd.Next(0, 100);
                            tileType = flag < 50 ? flag < 25 ? TileDataHandler.TileType.Grass : TileDataHandler.TileType.Grass1 : flag < 75 ? TileDataHandler.TileType.Grass1 : TileDataHandler.TileType.Grass3;
                        }

                        // Get the tile data for the chosen tile type
                        var tileData = TileDataHandler.GetTileData(tileType);
                        if (tileData != null)
                        {
                            // Create a new Tile with the texture and properties from the tileData
                            var tile = new Tile(
                                tileData.Item1, // Texture
                                new Vector2(x * Globals.TILE_SIZE, y * Globals.TILE_SIZE), // Position (scaled by TILE_SIZE)
                                tileData.Item2, // IsWalkable (true for grass, false for water/rocks)
                                (int)tileType // TileID (use enum value for unique identification)
                            );

                            // Add the created tile to the list of current tiles
                            CurrentTiles.Add(tile);
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
}