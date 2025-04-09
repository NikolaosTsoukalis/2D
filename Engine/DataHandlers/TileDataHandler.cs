
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

    private Texture2D TextureData;
    private bool? IsCollidable;

    #endregion Fields

    #region Constructors

    ///<Summary>
    /// constructor with data initialization 
    ///</Summary>
    public TileDataHandler()
    {
        TextureData = null;
        IsCollidable = false;
    }

    #endregion Constructors

    #region General Functions


    public Texture2D GetTileTextureData(int tileType)
    {
        try
        {
            if (AssignTileTextureData(tileType))
            {
                return TextureData;
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

    public bool? GetTileCollidability(int tileType)
    {
        try
        {
            if (AssignTileIsCollidable(tileType))
            {
                return IsCollidable;
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
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Grass");
                    break;
                case (int)TileType.Grass1:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Grass1");
                    break;
                case (int)TileType.Grass2:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Grass2");
                    break;
                case (int)TileType.Grass3:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Grass3");
                    break;
                case (int)TileType.Sand:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Sand");
                    break;
                case (int)TileType.Stone:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Stone");
                    break;
                case (int)TileType.Wall:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Wall");
                    break;
                case (int)TileType.Water:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Water");
                    break;
                case (int)TileType.Wood:
                    TextureData = Globals.ContentManager.Load<Texture2D>("Tiles/Wood");
                    break;
                default:
                    return false;
            }
            if(TextureData != null)
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

    private bool AssignTileIsCollidable(int type)
    {
        try
        {
            IsCollidable = null;
            switch(type)
            {
                case (int)TileType.Grass:
                case (int)TileType.Grass1:
                case (int)TileType.Grass2:
                case (int)TileType.Grass3:
                    IsCollidable = false;
                    break;
                case (int)TileType.Sand:
                    IsCollidable = false;
                    break;
                case (int)TileType.Stone:
                    IsCollidable = false;
                    break;
                case (int)TileType.Wall:
                    IsCollidable = true;
                    break;
                case (int)TileType.Water:
                    IsCollidable = true;
                    break;
                case (int)TileType.Wood:
                    IsCollidable = false;
                    break;
                default:
                    return false;
            }
            if(IsCollidable != null)
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
