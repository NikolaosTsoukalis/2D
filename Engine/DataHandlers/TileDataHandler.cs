
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class TileDataHandler
{
    #region Enums
    public enum TileType
    {
        Grass,
        Grass1,
        Grass2,
        Grass3,
        Water,
        Sand,
        Wall,
        Stone,
        Wood
    }
    #endregion Enums

    #region Fields

    private Texture2D data;

    #endregion Fields

    #region Constructors

    public TileDataHandler()
    {
        data = null;
    }

    #endregion Constructors

    #region General Functions

    /*
    private static Dictionary<TileType, Tuple<Texture2D, bool>> TileData;

    public TileDataHandler()
    {
        LoadTileData();
    }

    public static void LoadTileData()
    {
        // Format: {Texture2D}, bool (IsWalkable)
        TileData = new Dictionary<TileType, Tuple<Texture2D, bool>> // split dictionaries to name-texture and all the other abilities (walkability dmg)
        {
            { TileType.Grass, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Grass"), true) },
            { TileType.Grass1, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Grass1"), true) },
            { TileType.Grass2, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Grass2"), true) },
            { TileType.Grass3, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Grass3"), true) },
            { TileType.Water, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Water"), false) },
            { TileType.Sand, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Sand"), true) },
            { TileType.Wall, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Wall"), false) },
            { TileType.Stone, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Stone"), true) },
            { TileType.Wood, new Tuple<Texture2D, bool>(Globals.ContentManager.Load<Texture2D>("Tiles/Wood"), true) }
        };
    }

    public static void UnloadTileData()
    {
        TileData = new();
    }

    public static Tuple<Texture2D, bool> GetTileData(TileType tileType)
    {
        if (TileData.TryGetValue(tileType, out var tileData))
        {
            return tileData;
        }
        return null;
    }
    */
    public Texture2D GetTileTextureData(int tileType)
    {
        try
        {
            if (AssignTileTextureData(tileType))
            {
                return data;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return null;
        }

        Console.WriteLine("Tile Name: " + tileType.ToString() + " is invalid.");
        return null;
    }
    #endregion General Functions

    #region Assign Data Functions
    private bool AssignTileTextureData(int type)
    {
        try
        {
            switch(type)
            {
                case (int)TileType.Grass:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Grass");
                    break;
                case (int)TileType.Grass1:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Grass1");
                    break;
                case (int)TileType.Grass2:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Grass2");
                    break;
                case (int)TileType.Grass3:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Grass3");
                    break;
                case (int)TileType.Sand:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Sand");
                    break;
                case (int)TileType.Stone:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Stone");
                    break;
                case (int)TileType.Wall:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Wall");
                    break;
                case (int)TileType.Water:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Water");
                    break;
                case (int)TileType.Wood:
                    data = Globals.ContentManager.Load<Texture2D>("Tiles/Wood");
                    break;
                default:
                    return false;
            }
            if(data != null)
            {
                return true;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR: " + e);
            return false;
        }
        return false;
    }
    #endregion Assign Data Functions

}
