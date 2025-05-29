

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Utillity
{
    #region Fields
    #endregion Fields



    #region Functions for World Saves

    public static bool createTileMapFiles(string worldName)
    {
        try
        {
            TileMap tilemap = new TileMap();
            SaveTileMapToBinary(worldName, tilemap.GetTileMapMatrix(),true);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR " + e.ToString);
            return false;
        } 
    }

    public static int[,] GetWorldBinaryFile(string worldName)
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory,"/save/worlds/" + worldName);
        return LoadTileMapFromBinarySaveFile(folderPath);
    }
    public static string[] GetWorldFileNames(bool isTesting)
    {
        string folderPath;

        if (isTesting)
        {
            string directory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            folderPath = Path.Combine(directory, "save\\worlds");
        }
        else
        {
            folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save\\worlds");
        }
        //return Directory.GetFiles(folderPath, "*.bat", SearchOption.AllDirectories);
        string[] directories = Directory.GetDirectories(folderPath);
        
        List<string> worldNameList = new List<string>();
        foreach (string directory in directories)
        {
            string tempName = "";
            for (int i = 0; i < directory.Length; i++)
            {
                char charToAdd = directory[directory.Length - 1 - i];
                if (charToAdd != '\\')
                {
                    tempName = charToAdd + tempName;
                }
                else
                {
                    break;
                }
                 
            }
            worldNameList.Add(tempName);
        }
        return worldNameList.ToArray();
    }

    public static void SaveTileMapToBinary(string worldName, int[,] map, bool isTesting)
    {
        string folderPath;
        if (isTesting)
        {
            string directory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            folderPath = Path.Combine(directory, "save\\worlds\\" + worldName);
        }
        else
        {
            folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save\\worlds" + worldName);
        }
        
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






