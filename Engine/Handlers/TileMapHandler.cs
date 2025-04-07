using System;

namespace _2D_RPG;

public class TileMapHandler
{
    #region Fields
    private TileMap tileMap;
    #endregion Fields

    #region Constructors
    public TileMapHandler()
    {
        tileMap = new TileMap();
    }    

    #endregion Constructors

    #region Functions
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

    public void Draw()
    {
        try
        {
            tileMap.Draw();
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e);
        }
    }

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

    public bool AssignTileMap() // proper bool logic (use bool instead of void) 
    {
        try
        {
            if (true) // >: ^)
            {
                tileMap = new TileMap(); 
            }
            else
            {
                // tileMap = get map from folder
            }
            if (tileMap != null || tileMap.tileMapSize != 0) // >:^)
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
