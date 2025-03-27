using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class TileDataHandler
{
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
}
