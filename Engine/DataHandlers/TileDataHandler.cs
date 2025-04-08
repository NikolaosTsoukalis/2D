
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

///<Summary>
/// class to handle all tile data shenanigans
///</Summary>
public class TileDataHandler
{
    #region Enums

    ///<Summary>
    /// tiletypes to differenciate tiles by name a value stored in tilematrix   
    ///</Summary>
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

    ///<Summary>
    /// constructor with data initialization 
    ///</Summary>
    public TileDataHandler()
    {
        data = null;
    }

    #endregion Constructors

    #region General Functions

    ///<Summary>
    /// Get the tile texture data 
    ///</Summary>
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
