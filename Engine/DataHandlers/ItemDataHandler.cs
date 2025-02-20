
using System;
using System.Collections.Generic;
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

    public enum ArmorItemTypes
    {
        Helmet,
        Chestpiece,
        Legguard,
        Boots
    }

    public enum SpecialItems{}

    public enum RangedWeapons{}

    public enum MagicWeapons{}

    #endregion Enums
    

    #region MeleeWeaponData

    public enum WeaponTypes
    {
        Melee,
        Ranged,
        Magic
    }

    public enum MeleeWeapons
    {
        ShortSword,
        Fist
    }

    private static Dictionary<string,int[]> MeleeWeaponAttributeData {get;set;}
    private static Dictionary<string,int[]> MeleeWeaponHitboxData {get;set;}
    private static Dictionary<string,int[]> MeleeWeaponInventoryData {get;set;}

    #endregion MeleeWeaponData

    #region MeleeWeaponFunctions

    public static void LoadMeleeWeaponAttributeDataDictionary() // {damage, x, y, z}
    {
        MeleeWeaponAttributeData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[10] },
            { MeleeWeapons.Fist.ToString(),[2] }
        };
    }

    public static void LoadMeleeWeaponHitboxDataDictionary() // x,y,width,height
    {
        MeleeWeaponHitboxData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[50,50,50,100] },
            { MeleeWeapons.Fist.ToString(),[20,20,20,40] }
        };
    }

    public static void LoadMeleeWeaponInventoryDataDictionary() // x,y,width,height
    {
        MeleeWeaponInventoryData = new Dictionary<string, int[]> 
        {
            { MeleeWeapons.ShortSword.ToString(),[] }
        };
    }
    
    #endregion MeleeWeaponFunctions

    #region ChestpieceData

    public enum ChestpieceTypes
    {
        LeatherTunic,
        IronChestPlate
    }

    private static Dictionary<string,int[]> ChestpieceAttributeData {get;set;}
    private static Dictionary<string,int[]> ChestpieceInventoryData {get;set;}

    #endregion ChestpieceData

    #region ChestpieceFunctions

    public static void LoadChestpieceDictionary() // {defence, x, y, z}
    {
        ChestpieceAttributeData = new Dictionary<string, int[]> 
        {
            { ChestpieceTypes.LeatherTunic.ToString(),[50] }
        };
    }

    #endregion ChestpieceFunctions

    public static Dictionary<string,string[]> FoodData {get;set;}

    public ItemDataHandler()
    {
        //Weapons
        LoadMeleeWeaponAttributeDataDictionary();
        LoadMeleeWeaponHitboxDataDictionary();

        //Armor
        LoadChestpieceDictionary();

        //Consumables
        LoadFoodDictionary();
    }

    #region GeneralFunctions

    public static void LoadFoodDictionary()
    {
        FoodData = new Dictionary<string, string[]> {};
    }    

    public int[] GetEquippableItemAttributeData(string itemName)
    {
        int[] tempData = null;

        if (Enum.TryParse(itemName, true, out MeleeWeapons meleeWeapons))
        {
            //LoadMeleeWeaponDictionary();
            tempData = MeleeWeaponAttributeData.FirstOrDefault( item => item.Key == itemName ).Value;
        }
        else if (Enum.TryParse(itemName, true, out ChestpieceTypes chestpieceTypes))
        {
            //LoadMeleeWeaponDictionary();
            tempData = ChestpieceAttributeData.FirstOrDefault( item => item.Key == itemName ).Value;
        }
            
        return tempData;
    }

    public Rectangle getHitBox(Globals.Directions direction,Vector2 position, string itemName) 
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

            case Globals.Directions.UpRight:
                return new Rectangle((int)(position.X + variables[0] ),(int)(position.Y - variables[1]),variables[2],variables[3]);

            case Globals.Directions.DownLeft:
                return new Rectangle((int)(position.X - variables[0] ),(int)(position.Y + variables[1]),variables[2],variables[3]);

            case Globals.Directions.DownRight:
                return new Rectangle((int)(position.X + variables[0] ),(int)(position.Y - variables[1]),variables[2],variables[3]);
                
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

    #endregion GeneralFunctions
}