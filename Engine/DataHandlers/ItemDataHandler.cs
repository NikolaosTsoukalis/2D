
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

public class ItemDataHandler
{
    #region Enums
    public enum Potions{}

    public enum Food
    {
        Mutton,
        Strawberry
    }

    public enum Materials{}
    
    public enum MeleeWeapons
    {
        ShortSword
    }

    public enum RangedWeapons{}

    public enum MagicWeapons{}

    public enum WeaponTypes
    {
        Melee,
        Ranged,
        Magic
    }

    public enum SpecialItems{}

    #endregion Enums
    

    #region MeleeWeaponDictionaries
    private static Dictionary<string,string[]> meleeWeaponData;
    public static Dictionary<string,string[]> MeleeWeaponData
    {
        get{return meleeWeaponData;}
        
    }

    private static Dictionary<string,int[]> meleeWeaponHitboxData;
    public static Dictionary<string,int[]> MeleeWeaponHitboxData
    {
        get{return meleeWeaponHitboxData;}
        
    }

    private static Dictionary<string,int[]> meleeWeaponInventoryData;
    public static Dictionary<string,int[]> MeleeWeaponInventoryData
    {
        get{return meleeWeaponInventoryData;}
        
    }

    #endregion MeleeWeaponDictionaries

    private static Dictionary<string,string[]> foodData;
    public static Dictionary<string,string[]> FoodData
    {
        get{return foodData;}
        
    }

    public ItemDataHandler()
    {
        LoadMeleeWeaponDictionary();
        LoadMeleeWeaponHitboxDictionary();
        LoadFoodDictionary();
    }

    #region MeleeWeaponFunctions

    public static void LoadMeleeWeaponDictionary()
    {
        meleeWeaponData = new Dictionary<string, string[]> {};
    }

    public static void LoadMeleeWeaponHitboxDictionary() // x,y,width,height
    {
        meleeWeaponHitboxData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[50,50,50,100] }
        };
    }

    public static void LoadMeleeWeaponInventoryDictionary() // x,y,width,height
    {
        meleeWeaponInventoryData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[50,50,50,100] }
        };
    }
    
    #endregion MeleeWeaponFunctions

    public static void LoadFoodDictionary()
    {
        foodData = new Dictionary<string, string[]> {};
    }    

    public static string[] getItemData(string itemName)
    {
        
        if (Enum.TryParse(itemName, true, out MeleeWeapons meleeWeapons))
        {
            //LoadMeleeWeaponDictionary();
            return MeleeWeaponData.FirstOrDefault( item => item.Key == itemName ).Value;
        }
        else if (Enum.TryParse(itemName, true, out Food food))
        {
            //LoadFoodDictionary();
            return FoodData.FirstOrDefault( item => item.Key == itemName ).Value;
        }
        return null;
    }

    public Rectangle getWeaponHitBox(Globals.Directions direction,Vector2 position, string itemName) 
    {
        int[] variables = ItemDataHandler.getItemHitboxData(itemName); // pass player weapon 
        
        switch(direction)
        {
            case Globals.Directions.Up:
                return new Rectangle((int)(position.X),(int)(position.Y - variables[1]),variables[2],variables[3]);

            case Globals.Directions.Left:
                return new Rectangle((int)(position.X - variables[0]),(int)(position.Y),variables[2],variables[3]);

            case Globals.Directions.Down:
                return new Rectangle((int)(position.X),(int)(position.Y + variables[1]),variables[2],variables[3]);
                
            case Globals.Directions.Right:
                return new Rectangle((int)(position.X + variables[0]),(int)(position.Y),variables[2],variables[3]);
                
            case Globals.Directions.UpLeft:
                return new Rectangle((int)(position.X - variables[0] ),(int)(position.Y - variables[1]),variables[2],variables[3]);
            default:
                return new();
        }
    }

    public static int[] getItemHitboxData(string itemName)
    {
        try
        {
            if (Enum.TryParse(itemName, true, out MeleeWeapons meleeWeapons))
            {
                //LoadMeleeWeaponDictionary();
                return MeleeWeaponHitboxData.FirstOrDefault( item => item.Key == itemName ).Value;
            }
            return null;
        }
        catch(Exception e)
        {
            Microsoft.Xna.Framework.Input.MessageBox.Show("Error",e.ToString(),new List<string> {"OK"});
            return null;
        }
    }
}