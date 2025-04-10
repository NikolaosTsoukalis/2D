using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

///<Summary>
/// Generation, Tile functions and Generation functions
///</Summary>
public class TileMap
{
    #region Fields

    private Vector2 worldSize;
    private int[,] tileMapMatrix; // >: ^)
    ///<Summary>
    /// Size of world map in tiles 
    ///</Summary>
    public int tileMapSize;

    #endregion Fields

    #region Constructor

    ///<Summary>
    /// everything about tile generation and private 
    ///</Summary>
    public TileMap()
    {
        worldSize.X = (int)Globals.WorldSize.X;
        worldSize.Y = (int)Globals.WorldSize.Y;
        tileMapMatrix = new int[(int)worldSize.X, (int)worldSize.Y];

        tileMapSize = tileMapMatrix.Length;

        GenerateMap();
    }

    #endregion Constructor

    ///<Summary>
    /// Generation with seeds 1 through X from plains to rivers with paths 
    ///</Summary>
    public void GenerateMap()
    {
        try
        {
            #region grass only
            if (Globals.seed == 1)
            {
                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        GenerateLushGrass4(x, y);
                    }
                }
            }
            #endregion
            #region river w/rocks
            else if (Globals.seed == 2)
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);

                // river logic Here
                Rectangle riverArea = new Rectangle(0, riverHeightRand, 25, rnd.Next(3, 7));

                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        if (IsInRectangles(x, 0, y, 0, riverArea))
                        {
                            GenerateWater1(x, y);
                        }
                        else
                        {
                            GenerateRocksInGrassV0(x, y);
                        }
                    }
                }
            }

            #endregion
            
            #region rnd river path

            else if (Globals.seed == 3) // random bridge path with 4 rectangles starting from north west and ending at south
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);

                // river logic Here
                Rectangle riverArea = new Rectangle(0, riverHeightRand, 25, rnd.Next(3, 7));

                int startOfPath = 2;
                int pathSize = rnd.Next(1, 3);

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
                else if (startOfPath == 2) // bottom-right to top
                {
                    int flag1 = rnd.Next(16, 21);
                    pathA = new Rectangle(25 - flag1, rnd.Next(riverArea.Bottom + 2, 17), flag1, pathSize);
                    int pathSizeB = pathA.Bottom - rnd.Next(3, riverArea.Y - 2);
                    pathB = new Rectangle(pathA.X, pathA.Y - pathSizeB, pathSize, pathSizeB);
                    if (pathB.Right >= 12)
                    {
                        int flag2 = rnd.Next(2, 25 - pathB.X);
                        pathC = new Rectangle(25 - flag2, pathB.Y, flag2, pathSize);
                        pathD = new Rectangle(pathC.X, 0, pathSize, pathC.Bottom);
                    }
                    else
                    {
                        int pathSizeC = rnd.Next(2, 25 - pathB.Right);
                        pathC = new Rectangle(pathB.X, pathB.Y, pathSizeC, pathSize);
                        pathD = new Rectangle(pathC.Right - pathSize, 0, pathSize, pathC.Bottom);
                    }
                }
                else if (startOfPath == 3) // top-right to bottom
                {
                    int flag1 = rnd.Next(5, 21);
                    pathA = new Rectangle(25 - flag1, rnd.Next(1, riverArea.Y - 4), flag1, pathSize);
                    pathB = new Rectangle(pathA.X, pathA.Bottom, pathSize, rnd.Next(riverArea.Bottom + 1, 18));
                    if (pathB.Right >= 12)
                    {
                        int flag2 = rnd.Next(2, pathB.X);
                        pathC = new Rectangle(25 - flag2, pathB.Bottom, flag2, pathSize);
                        pathD = new Rectangle(pathC.X, pathC.Bottom, pathSize, 25 - pathC.Bottom);
                    }
                    else
                    {
                        int pathSizeC = rnd.Next(2, 25 - pathB.Right);
                        pathC = new Rectangle(pathB.Right, pathB.Bottom + 1, pathSizeC, pathSize);
                        pathD = new Rectangle(pathC.X, pathC.Bottom, pathSize, 25 - pathC.Bottom);
                    }
                }

                // Create the map with river and random rocks
                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        if (IsInRectangle(x, 0, y, 0, riverArea) && IsInRectangles(x, 0, y, 0, pathA, pathB, pathC, pathD))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Wood;
                        }
                        else if (IsInRectangle(x, 0, y, 0, riverArea))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Water;
                        }
                        else if(IsInRectangles(x, 0, y, 0, pathA, pathB, pathC, pathD))
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

            else if (Globals.seed == 4) // random bridge path with 4 rectangles starting from north west and ending at south + randomed path
            {
                Random rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);

                // river logic Here
                Rectangle riverArea = new Rectangle(0, riverHeightRand, 25, rnd.Next(3, 7));

                // path seed here
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
                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        // Check to see for river + path to place wood tile 
                        if (IsInRectangle(x, 0, y, 0, riverArea) && IsInRectangles(x, 0, y, 0, pathA, pathB, pathC, pathD))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Wood;
                        }
                        // Check to see if river to place water tile
                        else if (IsInRectangle(x, 0, y, 0, riverArea))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Water;
                        }
                        // Check to see if in the inside of path
                        else if (IsInRectangles(x, 1, y, 1, pathA, pathB, pathC, pathD))
                        {
                            GeneratePathWithPercentage(x, y, 100);
                        }
                        // Check to see if on the path
                        else if (IsInRectangles(x, 0, y, 0, pathA, pathB, pathC, pathD))
                        {
                            GeneratePathWithPercentage(x, y, 95);
                        }
                        else if (IsInRectangles(x, -1, y, -1, pathA, pathB, pathC, pathD))
                        {
                            GeneratePathWithPercentage(x, y, 20);
                        }
                        else if (IsInRectangles(x, -2, y, -2, pathA, pathB, pathC, pathD))
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
            else if (Globals.seed == 5) // random path without river
            {
                var rnd = new Random();                
                var start = new Point(5, 20);
                var directions = new[] { 0, 3, 0, 2 }; // up:0 down:1 left:2 right:3
                var pathRects = GeneratePath(start, rnd.Next(2, 4), directions, rnd);

                Rectangle pathA = pathRects[0];
                Rectangle pathB = pathRects[1];
                Rectangle pathC = pathRects[2];
                Rectangle pathD = pathRects[3];

                // Create the map with river and random rocks
                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        if (IsInRectangles(x, 0, y, 0, pathA, pathB, pathC, pathD))
                        {
                            GeneratePathWithPercentage(x, y, 100);
                        }
                        else 
                        {
                            GenerateLushGrass4(x, y);
                        }
                    }
                }
            }
            else if (Globals.seed == 6) // random bridge path 
            {
                var rnd = new Random();
                int riverHeightRand = rnd.Next(5, 8);

                // river logic Here
                Rectangle riverArea = new Rectangle(0, riverHeightRand, 25, rnd.Next(3, 7));

                var start = new Point(15, 0);
                //var directions = new[] { 0, 3, 0, 2 }; // up:0 down:1 left:2 right:3
                //var directions = new[] { 0, 2, 0, 3 }; // up:0 down:1 right:3 left:2
                //var directions = new[] { 1, 3, 1, 2 }; // up:0 down:1 right:3 left:2
                var directions = new[] { 1, 2, 1, 3 }; // up:0 down:1 right:3 left:2
                
                var pathRects = GeneratePathThroughRiver(start, rnd.Next(1,3), directions, rnd, riverArea);

                Rectangle pathA = pathRects[0];
                Rectangle pathB = pathRects[1];
                Rectangle pathC = pathRects[2];
                Rectangle pathD = pathRects[3];

                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        if (IsInRectangle(x, 0, y, 0, riverArea) && IsInRectangles(x, 0, y, 0, pathA, pathB, pathC, pathD))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Wood;
                        }
                        else if (IsInRectangle(x, 0, y, 0, riverArea))
                        {
                            tileMapMatrix[x, y] = (int)TileDataHandler.TileType.Water;
                        }
                        else if(IsInRectangles(x, 0, y, 0, pathA, pathB, pathC, pathD))
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
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }

    #endregion

    #region Functions

    ///<Summary>
    /// Change tile to new tile 
    ///</Summary>
    public void ChangeTile(int x, int y, TileDataHandler.TileType newTile) // >: ^)
    {
        tileMapMatrix[x, y] = 0;
        tileMapMatrix[x, y] = (int)newTile; // >:    ^)
    }

    ///<Summary>
    /// remove tile
    ///</Summary>
    public void RemoveTile(int x, int y)
    {
        tileMapMatrix[x, y] = 0;
    }

    ///<Summary>
    /// add a tile
    ///</Summary>
    public void AddTile(int x, int y, TileDataHandler.TileType newType)
    {
        tileMapMatrix[x, y] = (int)newType;
    }

    ///<Summary>
    /// get the type of a tile at position x,y
    ///</Summary>
    public int GetTileTypeAt(int x, int y)
    {
        return tileMapMatrix[x, y];
    }

    ///<Summary>
    /// check all the tiles that need updating
    ///</Summary>
    public void Update()
    {
        // ότι αλλάζει στο tileMapMatrix ΕΔΩ
    }

    ///<Summary>
    /// Draws the tilemap only seen by the camera and one radius larger
    ///</Summary>
    public void Draw(Matrix cameraMatrix)
    {
        Vector2 Position = new Vector2 (0, 0);
        int percievedWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        int percievedHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

        Matrix inverseView = Matrix.Invert(cameraMatrix);
        Vector2 topLeftWorld = Vector2.Transform(Vector2.Zero, inverseView);

        int x_flag = (int)topLeftWorld.X / 32; 
        int y_flag = (int)topLeftWorld.Y / 32;

        for (int y = y_flag - 2; y < percievedHeight/32 + y_flag + 2; y ++)
        {
            for (int x = x_flag - 2; x < percievedWidth/32 + x_flag + 2; x ++)
            {
                Position.X = x * Globals.TileSize;
                Position.Y = y * Globals.TileSize;
                Globals.SpriteBatch.Draw(Globals.TileDataHandler.GetTileTextureData(tileMapMatrix[x, y]), Position, Color.White);
            }
        }
    }

    public void DebugDraw(Game game,Matrix cameraMatrix)
    {
        Vector2 Position = new Vector2 (0, 0);
        int percievedWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        int percievedHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

        Matrix inverseView = Matrix.Invert(cameraMatrix);
        Vector2 topLeftWorld = Vector2.Transform(Vector2.Zero, inverseView);

        int x_flag = (int)topLeftWorld.X / 32; 
        int y_flag = (int)topLeftWorld.Y / 32;

        for (int y = y_flag - 2; y < percievedHeight/32 + y_flag + 2; y ++)
        {
            for (int x = x_flag - 2; x < percievedWidth/32 + x_flag + 2; x ++)
            {
                Position.X = x * Globals.TileSize;
                Position.Y = y * Globals.TileSize;
                if(Globals.TileDataHandler.GetTileCollidability(GetTileTypeAt(x, y)) == true)
                {
                    Texture2D tileTexture = Globals.TileDataHandler.GetTileTextureData(tileMapMatrix[x, y]);
                    Texture2D tileDebugTexture = new Texture2D(game.GraphicsDevice, 1,1);
                    Rectangle tileDebugRectangle = new Rectangle((int)Position.X,(int)Position.Y,tileTexture.Width, tileTexture.Height);
                    tileDebugTexture.SetData(new[] { Color.Yellow });
                    Globals.SpriteBatch.Draw(tileDebugTexture,tileDebugRectangle, Color.Yellow);
                    Globals.SpriteBatch.DrawString(Main.MyFont,GetTileTypeAt(x, y).ToString(),new Vector2 (tileDebugRectangle.X,tileDebugRectangle.Y), Color.White);
                }
                else
                    Globals.SpriteBatch.Draw(Globals.TileDataHandler.GetTileTextureData(tileMapMatrix[x, y]), Position, Color.White);
            }
        }
    }

    #endregion Functions

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

    private bool IsInRectangle(int x, int offsetx, int y, int offsety, Rectangle rectangle) // offset > 0 => smaller rectangle, offset < 0 => larger
    { 
        return x >= rectangle.X + offsetx && x <= rectangle.Right - offsetx && y >= rectangle.Y + offsety && y <= rectangle.Bottom - offsety;
    }

    private bool IsInRectangles(int x, int offsetx, int y, int offsety, params Rectangle[] rectangles)
    {
        foreach (var rect in rectangles)
        {
            if (IsInRectangle(x, offsetx, y, offsety, rect))
                return true;
        }
        return false;
    }

    private List<Rectangle> GeneratePath(Point start, int pathSize, int[] directions, Random rnd)
    {
        var path = new List<Rectangle>();
        var current = start;
        int last_dir = -1;

        foreach (int dir in directions)
        {
            Rectangle segment;
            int a = 6;
            int b = 16;
            if (dir == 0) // up
            {
                if (last_dir == 3)
                {
                    current.X -= pathSize;
                }

                int height = rnd.Next(a, b);
                segment = new Rectangle(current.X, current.Y - height, pathSize, height);
                current.Y -= height;

                last_dir = 0;
            }
            else if (dir == 1) // down
            {
                int height = rnd.Next(a, b);
                segment = new Rectangle(current.X, current.Y, pathSize, height);
                current.Y += height;

                last_dir = 1;
            }
            else if (dir == 2) // left
            {
                if (last_dir == 1)
                {
                    current.X += pathSize;
                }

                int width = rnd.Next(a, b);
                segment = new Rectangle(current.X - width, current.Y, width, pathSize);
                current.X -= width;

                last_dir = 2;
            }
            else if (dir == 3) // right
            {
                int width = rnd.Next(a, b);
                segment = new Rectangle(current.X, current.Y, width, pathSize);
                current.X += width;

                last_dir = 3;
            }
            else
            {
                throw new ArgumentException("Invalid direction. Use 0=up, 1=right, 2=down, 3=left");
            }
            path.Add(segment);
        }
    return path;
    }

    private List<Rectangle> GeneratePathThroughRiver(Point start, int pathSize, int[] directions, Random rnd, Rectangle riverArea)
    {
        var path = new List<Rectangle>();
        var current = start;
        int last_dir = -1;
        int index = 0;

        foreach (int dir in directions)
        {
            index += 1;
            Rectangle segment;
            int a = 6;
            int b = 16;
            
            if (dir == 0) // up
            {
                int height = rnd.Next(a, b);
                int rndSpace = rnd.Next(2, 4);

                if (last_dir == -1)
                {
                    height = current.Y - riverArea.Bottom - rndSpace;
                }
                else if (last_dir == 2)
                {
                    height = current.Y - riverArea.Y + rnd.Next(2 + pathSize, 4 + pathSize);                    
                }
                else if (last_dir == 3)
                {
                    current.X -= pathSize;
                    height = current.Y - riverArea.Y + rnd.Next(2 + pathSize, 4 + pathSize);
                }
                
                if (index == directions.Length)
                {
                    current.Y = height;
                }

                segment = new Rectangle(current.X, current.Y - height, pathSize, height);
                current.Y -= height;

                last_dir = 0;
            }
            else if (dir == 1) // down
            {
                int height = rnd.Next(a, b);

                if (last_dir == -1)
                {
                    height = riverArea.Y - rnd.Next(2, 4) - pathSize;
                }
                else if (last_dir == 2)
                {
                    height = rnd.Next(riverArea.Bottom + 1, 20 - pathSize) - current.Y;                     
                }
                else if (last_dir == 3)
                {
                    height = rnd.Next(riverArea.Bottom + 1, 20 - pathSize) - current.Y; 
                }

                segment = new Rectangle(current.X, current.Y, pathSize, height);
                current.Y += height;

                last_dir = 1;
            }
            else if (dir == 2) // left
            {
                int width = rnd.Next(a, b);
                if (last_dir == 1)
                {
                    current.X += pathSize;
                }

                if (index == directions.Length)
                {
                    width = current.X;
                    //current.X = current.X + width;
                }
                
                segment = new Rectangle(current.X - width, current.Y, width, pathSize);
                current.X -= width;

                last_dir = 2;
            }
            else if (dir == 3) // right
            {
                int width = rnd.Next(a, b);
                if (index == directions.Length)
                {
                    width = 25 - current.X;
                }

                segment = new Rectangle(current.X, current.Y, width, pathSize);
                current.X += width;

                last_dir = 3;
            }
            else
            {
                throw new ArgumentException("Invalid direction. Use 0=up, 1=right, 2=down, 3=left");
            }
            path.Add(segment);
        }
    return path;
    }

    #endregion Gen Functions
}   