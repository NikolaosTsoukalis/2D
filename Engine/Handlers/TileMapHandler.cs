using System;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

///<Summary>
/// Magic of the tilemap handling
///</Summary>
public class TileMapHandler
{
    #region Fields
    private TileMap tileMap;

    #endregion Fields

    #region Constructors

    ///<Summary>
    /// constructor with new tilemap
    ///</Summary>
    public TileMapHandler()
    {
        tileMap = new TileMap();
    }    

    #endregion Constructors

    #region Functions
    ///<Summary>
    /// update 
    ///</Summary>
    public void Update()
    {
        try
        {
            // If any tile needs updating (e.g., animations or interactions), implement that logic here
            tileMap.Update();
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }

    ///<Summary>
    /// request to draw tilemap
    ///</Summary>
    public void DrawTileMap(Matrix cameraMatrix)
    {
        try
        {
            tileMap.Draw(cameraMatrix);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }

    public void DebugDraw(Game game, Matrix cameraMatrix) // for testing purposes
    {
        tileMap.DebugDraw(game,cameraMatrix);
        //tileCollisionMap.DebugDraw(main,"Entity");
    }

    ///<Summary>
    /// get the tile map data
    ///</Summary>
    public TileMap GetTileMap()
    {
        try
        {
            if (AssignTileMap())
            {    
                return tileMap;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error" + e.ToString());
            return tileMap;
        }
    }

    ///<Summary>
    /// proper bool logic, try catch included, gets map from folder TODO
    ///</Summary>
    public bool AssignTileMap()
    {
        try
        {
            if (tileMap == null || tileMap.tileMapSize == 0) // >: ^)
            {
                tileMap = new TileMap(); 
            }
            else
            {
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error" + e.ToString());
            return false;
        }
        return false;
    }

    #endregion
}
