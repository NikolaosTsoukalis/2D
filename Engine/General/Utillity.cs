

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
            SaveTileMap(worldName, tilemap.GetTileMapMatrix(), true);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR " + e.ToString);
            return false;
        }
    }

    public static int[,] GetWorldBinaryFile(string worldName, bool isTesting)
    {
        string pathToFile;

        if (isTesting)
        {
            string directory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            pathToFile = Path.Combine(directory, "save\\worlds\\" + worldName + "\\" + "TileMap.dat");
        }
        else
        {
            pathToFile = Path.Combine(AppContext.BaseDirectory, "\\save\\worlds\\" + worldName + "TileMap.dat");
        }
        return ReadTileMapFromBinaryFile(pathToFile);
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

    public static void SaveTileMap(string worldName, int[,] map, bool isTesting)
    {
        string folderPath;
        if (isTesting)
        {
            string directory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            folderPath = Path.Combine(directory, "save\\worlds\\" + worldName);
        }
        else
        {
            folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save\\worlds\\" + worldName);
        }

        Directory.CreateDirectory(folderPath);
        WriteTileMapToBinaryFile(folderPath, map);
    }

    public static int[,] ReadTileMapFromBinaryFile(string path)
    {
        try
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
            {
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
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR IN FILE READER: " + e);
            return null;
        }
    }

    public static void WriteTileMapToBinaryFile(string folderPath, int[,] tileMap)
    {
        try
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(folderPath, "TileMap.dat"), FileMode.Create)))
            {
                int rows = tileMap.GetLength(0);
                int cols = tileMap.GetLength(1);
                writer.Write(rows);
                writer.Write(cols);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write(tileMap[i, j]);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR IN FILE WRITER: " + e);    
        }     
    }


    #endregion Functions for World Saves


}






