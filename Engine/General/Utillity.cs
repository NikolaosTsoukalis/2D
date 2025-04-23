

using System;
using System.IO;

namespace _2D_RPG;

public class Utillity
{
    #region Fields
    #endregion Fields



    #region Functions for World Saves

    public TileMap createTileMap()
    {
        
    }

    public static string[] GetWorldFiles()
    {
        return Directory.GetFiles(Path.Combine(AppContext.BaseDirectory,"/save/worlds/"), ".bat", SearchOption.AllDirectories);
    }

    public static void SaveTileMapToBinary(string worldName, int[,] map)
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory,"/save/worlds/" + worldName);
        Directory.CreateDirectory(folderPath);
        BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(folderPath,"Tilemap.dat") , FileMode.Create));
        
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);
        writer.Write(rows);
        writer.Write(cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                writer.Write(map[i, j]);
            }    
        }
    }

    public static int[,] LoadTileMapFromBinarySaveFile(string path)
    {
        BinaryReader reader = new BinaryReader(File.OpenRead(path));
        
        int rows = reader.ReadInt32();
        int cols = reader.ReadInt32();
        int[,] map = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                map[i, j] = reader.ReadInt32();
            }
        }

        return map;
    }

    #endregion Functions for World Saves


}






